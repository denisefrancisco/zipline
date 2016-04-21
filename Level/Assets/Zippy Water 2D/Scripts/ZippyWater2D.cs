using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(BuoyancyEffector2D))]


public class ZippyWater2D : MonoBehaviour {
	[Header("Appearance settings")]
	public Color topColor = Color.white;
	public Color bottomColor = Color.white;
	[Tooltip("Amount of points in wave, wave colliders and mesh vertexes.\nCannot be changed during runtime.")]
	[Range(1, 15)]
	public int resolution = 5;
	
	[Header("Size settings")]
	[Tooltip("Water width.\nCannot be changed during runtime.")]
	public float width = 10f;
	[Tooltip("Water height.\nCannot be changed during runtime.")]
	public float height = 10f;
	[Tooltip("Height of wave colliders.\nCannot be changed during runtime.")]
	public float colliderHeightOffset = -.1f;

	[Tooltip("Move wave colliders to match wave height. (Very high cpu usage.)")]
	public bool updateWaveColliders;
	[Range(0.04f, 0.5f)]
	public float updateWaveCollidersDelay = 0.2f;

	[Header("Water Splash Settings")]
	[Tooltip("Wave springyness.")]
	public float waterBounce = 0.04f;
	[Tooltip("Wave stoppage.")]
	public float waterDamping = 0.04f;
	[Tooltip("Splash ripple distance.")]
	[Range(0.005f, 0.05f)]
	public float waterWaveSpread = 0.05f;
	[Tooltip("Splash ripple distance.")]
	[Range(0, 15)]
	public int waveSpreadLength = 10;
	[Tooltip("Splash on collide multiplier.")]
	public float velocityMultiplier = .1f;
	[Tooltip("Reduces splash on collisions.")]
	[Range(1, 20)]
	public float maxForce = 10;
	[Tooltip("Minimum velocity to splash.")]
	[Range(0, 10)]
	public float minVelocity = 0;

	[Header("Water Wave Settings")]
	public bool enableWave;
	[Range(0, .05f)]
	public float noise = 0f;
	[Range(3, 20)]
	public int randomSplashDelay = 3;
	public float randomSplash = 0.1f;
	[Range(0f, .04f)]
	public float waveHeight = .002f;
	[Range(-10, 10)]
	public float waveSpeed = 3f;
	[Tooltip("Limit vertical wave speed.")]
	[Range(0.05f, 1f)]
	public float waveLimit = 1f;
	[Range(0f, 5f)]
	public float waveFrequency = .15f;

	[Header("Wave Force Settings")]
	public float wavePower = 50f;
	[Tooltip("Apply rotation to objects in the water.")]
	[Range(0f, 1f)]
	public float waveTorque = 0f;

	[Header("UV & Material Settings")]
	public bool CreateUV = true;
	public float UVScale = 1f;
	[Tooltip("Waves distorts UV map to simulate ripples.")]
	[Range(0f, 1f)]
	public float UVDistort = .25f;
	[Range(-.05f, .05f)]
	public float materialOffsetSpeed = 0f;
	public int sortingOrder = 0;
	public string sortingLayer;

	[Header("Particle Settings")]
	public ParticleSystem particles;
	[Tooltip("Particle speed on splash.")]
	public float particleSplashPower = 6f;
	[Tooltip("Particles emitted on splash.")]
	[Range(0, 5)]
	public int particleSplashEmit = 2;
	public ParticleSystem bubbleParticles;
	[Range(0, 100)]
	public float bubbleParticlesEmissionRate = 4;

	[Header("Sound Settings")]
	[Tooltip("Random clips to play on splash.")]
	public AudioClip[] splashSounds;
	[Tooltip("Random clips to play on exit.")]
	public AudioClip[] exitSounds;
	[Range(0f, 1f)]
	public float splashSoundVolume = .5f;
	[Tooltip("Delay between audio clips. (Avoid too many overlapping sounds)")]
	[Range(0.05f, 1f)]
	public float splashSoundDelay = .15f;

	//Component references
	[HideInInspector]	public Transform cacheTransform;
	[HideInInspector]	public Transform cacheParticleTransform;
	[HideInInspector]	public MeshFilter cacheMeshFilter;
	[HideInInspector]	public MeshRenderer cacheMeshRenderer;
	[HideInInspector]	public BoxCollider2D cacheCollider;

	//Arrays
	Vector2[] points;
	float[] posX;
	float[] posY;
	float[] velY;
	float[] accY;
	GameObject[] waveColliders;
	[HideInInspector]	public List<Collider2D> forced;     // Used to keep track of objects in the water so that the water waveColliders only apply force once per update.
	int colliderAmount;
	int pointAmount;
	Mesh waterMesh;
	bool audioPlayed;

	void CacheComponents() {
		cacheMeshFilter = GetComponent<MeshFilter>();
		cacheTransform = transform;
		cacheMeshRenderer = GetComponent<MeshRenderer>();
	}

	void Init() {
		colliderAmount = Mathf.RoundToInt(width) * resolution;
		pointAmount = colliderAmount + 1;
		posX = new float[pointAmount];
		posY = new float[pointAmount];
		velY = new float[pointAmount];
		accY = new float[pointAmount];
		points = new Vector2[pointAmount * 2];
		waveColliders = new GameObject[colliderAmount];
		for (int i = 0; i < pointAmount; i++) {
			posY[i] = cacheTransform.position.y;
			posX[i] = cacheTransform.position.x + width * i / colliderAmount;
			accY[i] = 0;
			velY[i] = 0;
			if(i < colliderAmount) { 
				waveColliders[i] = new GameObject();
				waveColliders[i].name = "ZippyWater2DCollider";
				waveColliders[i].transform.parent = transform;
				waveColliders[i].transform.position = new Vector2(cacheTransform.position.x + width * (i + 0.5f) / colliderAmount, cacheTransform.position.y + colliderHeightOffset - (height +colliderHeightOffset )* .5f);
				waveColliders[i].transform.localScale = new Vector2(width / colliderAmount *.9f, height + colliderHeightOffset);
				ZippyWater2DCollider col = waveColliders[i].AddComponent<ZippyWater2DCollider>();
				col.index = i;
				BoxCollider2D bx = waveColliders[i].AddComponent<BoxCollider2D>();
				col.height = bx.bounds.size.y;
				bx.isTrigger = true;
			}
		}
		BoxCollider2D bigc = GetComponent<BoxCollider2D>();
		bigc.offset = new Vector2(width * 0.5f, colliderHeightOffset - (height+ colliderHeightOffset) * .5f);
		bigc.size = new Vector2(width, height + colliderHeightOffset);
		SetBubbleParticles();
		if (waterMesh == null) waterMesh = new Mesh();
		
	}
	
	void SetBubbleParticles() {
		if (bubbleParticles == null) return;
		bubbleParticles.transform.localScale = new Vector2(width, height * .5f);
		bubbleParticles.transform.position = new Vector2(transform.position.x + width* 0.5f, transform.position.y  - height  * .75f);
		SetEmissionRate(bubbleParticles, width * bubbleParticlesEmissionRate);
	}

	void Awake () {
		CacheComponents();
		Init();
		Invoke("UpdateWaveColliderPositions", .1f);
	}

	void SetEmissionRate(ParticleSystem particleSystem, float emissionRate) {
		var emission = particleSystem.emission;
		var rate = emission.rate;
		rate.constantMax = emissionRate;
		emission.rate = rate;
	}

	public void GenerateMeshColors() {
		List<Color> colors = new List<Color>();
		for (var i = 0; i < points.Length * .5f; i++) {
			colors.Add(bottomColor);
			colors.Add(topColor);
		}
		waterMesh.colors = colors.ToArray();
	}

	void GenerateMesh() {
		List<Vector3> verts = new List<Vector3>();
		for (var i = points.Length -1; i >= 0; i--) verts.Add(cacheTransform.InverseTransformPoint(points[i]));
		waterMesh.vertices = verts.ToArray();
		if(waterMesh.colors.Length == 0) GenerateMeshColors();
		if (waterMesh.triangles.Length == 0) {
			List<int> tris = new List<int>();
				for (var i = 0; i < verts.Count - 2; i++) {
					if (i % 2 == 0) {
						tris.Add(i + 2);
						tris.Add(i + 1);
						tris.Add(i);
					} else {
						tris.Add(i + 2);
						tris.Add(i);
						tris.Add(i + 1);
					}
				}		
			waterMesh.triangles = tris.ToArray();
			cacheMeshFilter.mesh = waterMesh;
		}
		if (waterMesh.bounds.extents.x == 0) waterMesh.RecalculateBounds();
		if (!CreateUV) return;
		if (waterMesh.uv.Length > 0 && UVDistort == 0) return;
		Vector2[] u = new Vector2[verts.Count];
		int ui =0;
		for (int i = 0; i < verts.Count; i++) {			
			if (i % 2 == 1) {
				u[i] = new Vector2(verts[i].x / width * UVScale, 1 * UVScale) * (1 - velY[velY.Length - 1 - ui] * UVDistort);
				ui++;
			} else {
				u[i] = new Vector2(verts[i].x / width * UVScale, 0) * (1 - velY[velY.Length - 1 - ui] * UVDistort);
			}				
		}
		waterMesh.uv = u;
	}

	public void Splash(int index, float velocity) {
		if (Mathf.Abs(velocity) < minVelocity) return;
			if (velocity < -0f && splashSounds.Length > 0) PlaySound(velocity);
			if (velocity > 0f && exitSounds.Length > 0) PlaySound(velocity, true);
		velY[index] = velocity * velocityMultiplier * Random.Range(.8f, .9f);
		if (!particles) return;
		float power = Mathf.Pow(Mathf.Abs(velocity), .5f);
		particles.startSpeed = particleSplashPower * power;
		particles.startLifetime = power * .5f;
		Vector3 position = new Vector2(posX[index],posY[index]-.5f);
		particles.transform.position = position;
		particles.Emit(particleSplashEmit * (int)power);
	}

	void PlaySound(float vel, bool exit = false) {
		if (!audioPlayed) {
			if (!exit) PlayClipAtPoint(splashSounds[Random.Range(0, splashSounds.Length)], transform.position, Mathf.Abs(vel * .1f));
			else PlayClipAtPoint(exitSounds[Random.Range(0, exitSounds.Length)], transform.position, Mathf.Abs(vel * .1f));
			audioPlayed = true;
			Invoke("ResetAudio", splashSoundDelay);
		}
	}

	void PlayClipAtPoint(AudioClip clip, Vector3 pos, float vol) {
		GameObject temp  = new GameObject("TempAudio");
#if UNITY_EDITOR
		temp.hideFlags = HideFlags.HideInHierarchy;
#endif
		temp.transform.position = pos;
		AudioSource audioS = temp.AddComponent<AudioSource>();
		audioS.clip = clip;
		audioS.pitch = Random.Range(.9f, 1.1f);
		audioS.volume = vol * splashSoundVolume;
		audioS.priority = 10;
		audioS.Play();
		Destroy(temp, clip.length);
	}

	void ResetAudio() {
		audioPlayed = false;
	}

	void UpdateWater() {
		int ii = 0;
		for (int i = 0; i < pointAmount; i++) {
			points[i + ii] = new Vector3(posX[i], posY[i]);
			points[i + ii + 1] = new Vector3(posX[i], transform.position.y - height);
			ii++;
		}
		float h = cacheTransform.position.y - height * .9f;
		float hh = cacheTransform.position.y + height * .9f;
		for (int i = 0; i < posX.Length; i++) {
			float f = waterBounce * (posY[i] - cacheTransform.position.y) + velY[i]*waterDamping ;
			velY[i] = Mathf.Clamp(velY[i], -waveLimit, waveLimit);
			accY[i] = -f;
			posY[i] += velY[i];
			velY[i] += accY[i];
			posY[i] = Mathf.Clamp(posY[i], h,  hh);
		}
		float[] waveSpreadLeft = new float[posX.Length];
		float[] waveSpreadRight = new float[posX.Length];
		for (int i = 0; i < waveSpreadLength; i++) {
			for (int o = 1; o < posX.Length -1; o++) {
				waveSpreadLeft[o] = waterWaveSpread * (posY[o] - posY[o - 1]);
				velY[o - 1] += waveSpreadLeft[o];
				waveSpreadRight[o] = waterWaveSpread * (posY[o] - posY[o + 1]);
				velY[o + 1] += waveSpreadRight[o];
			}
		}
		for (int i = 1; i < posX.Length-1; i++) {
			posY[i - 1] += waveSpreadLeft[i];			
			posY[i + 1] += waveSpreadRight[i];
		}
		for (int i = 0; i < waveColliders.Length; i++) {
			ZippyWater2DCollider c = waveColliders[i].GetComponent<ZippyWater2DCollider>();
			c.waveForce = velY[i];
		}
	}

	void UpdateWaveColliderPositions() {
		if (!updateWaveColliders) {
			Invoke("UpdateWaveColliderPositions", updateWaveCollidersDelay);
			return;
		}
		for (int i = 0; i<waveColliders.Length; i++) {
			ZippyWater2DCollider c = waveColliders[i].GetComponent<ZippyWater2DCollider>();
			c.cacheTransform.position = new Vector2(c.cacheTransform.position.x, cacheTransform.position.y +  colliderHeightOffset +posY[i] - c.height * .75f);
		}
		Invoke("UpdateWaveColliderPositions", updateWaveCollidersDelay);
	}

	void Wave() {
		if (!enableWave) return;
		float h =  waveHeight;
		float f =  waveFrequency / resolution;
		for (int i = 0; i < waveColliders.Length; i++) velY[i] +=h * Mathf.Sin((Time.time * waveSpeed) + i * f);
	}

	void Noise() {
		if (noise <= 0) return;
		for (int i = 0; i < waveColliders.Length; i++) 	velY[i] += Random.Range(-noise, noise);
	}

	void RandomSplash() {
		if (randomSplash <= 0) return;
		if (Time.frameCount % randomSplashDelay != 0) return;
		int r = Random.Range(0, waveColliders.Length -2);
		float rr  =  Random.Range(-randomSplash, randomSplash);
		Splash(r, rr);
		Splash(r+1, rr);
		Splash(r+2, rr);
	}

	void OffsetMaterial() {
		if (materialOffsetSpeed == 0) return;
		Vector2 o = new Vector2((cacheMeshRenderer.material.mainTextureOffset.x + materialOffsetSpeed)%1, cacheMeshRenderer.material.mainTextureOffset.y);
		cacheMeshRenderer.material.mainTextureOffset = o;
	}

	void SpriteSorting() {
		cacheMeshRenderer.sortingOrder = sortingOrder;
		cacheMeshRenderer.sortingLayerName = sortingLayer;
	}

	void FixedUpdate () {
		if (!cacheMeshRenderer.isVisible) return;
		SpriteSorting();
		RandomSplash();
		Noise();
		OffsetMaterial();
		Wave();
		UpdateWater();
		GenerateMesh();
	}

#if UNITY_EDITOR
	void OnDrawGizmos() {
		if (Application.isPlaying) return;
		Color col;
		if (bottomColor.r + bottomColor.g + bottomColor.g < topColor.r + topColor.g + topColor.g)
			col = bottomColor;
		else
			col = topColor;
		col.a = .8f;
		Gizmos.color = col; 
		Gizmos.DrawCube(new Vector3(transform.position.x + width * .5f, transform.position.y - height * .5f, 0), new Vector3(width, height, 0));
		SetBubbleParticles();
		cacheCollider = GetComponent<BoxCollider2D>();
		cacheCollider.offset = new Vector2(width * .5f, colliderHeightOffset - (height + colliderHeightOffset) * .5f);
		cacheCollider.size = new Vector2(width, height + colliderHeightOffset);
		cacheCollider.isTrigger = true;
		cacheCollider.usedByEffector = true;
	}
#endif
}
