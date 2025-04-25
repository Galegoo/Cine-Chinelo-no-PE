using UnityEngine;
using System.Collections;

public class PlataformGenerator : MonoBehaviour {
	
	//public GameObject thePlataform;
	public Transform generationPoint;

	public float distanceBetween;
	//private float plataformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	//public ObjectPooler theObjectPool;
	private int plataformSelector;

	//public GameObject[] thePlataforms;
	private float [] plataformWidths;
	public ObjectPooler[] theObjectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator theCoinGenerator;
	public float randomCoinTreshold;

	public float randomObstaculo;
	public ObjectPooler[] obstaculosPool; 
	private int obstaculoSelector;

	// Use this for initialization
	void Start () {
		//plataformWidth = thePlataform.GetComponent<BoxCollider2D>().size.x;

		plataformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {

			plataformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theCoinGenerator = FindObjectOfType<CoinGenerator>();
	}
	
	// Update is called once per frame
	void Update () {


		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			plataformSelector = Random.Range(0, theObjectPools.Length);
			obstaculoSelector = Random.Range(0, obstaculosPool.Length);
			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
			if (heightChange > maxHeight)
			{
				heightChange = maxHeight;
			} else if (heightChange < minHeight)
			{
				heightChange = minHeight;
			}
			transform.position = new Vector3 (transform.position.x + (plataformWidths[plataformSelector] /2) + distanceBetween, heightChange, transform.position.z);

			//Instantiate (/*thePlataform*/ thePlataforms[plataformSelector], transform.position, transform.rotation);

			GameObject newPlataform = theObjectPools[plataformSelector].GetPooledObject();
			newPlataform.transform.position = transform.position;
			newPlataform.transform.rotation = transform.rotation;
			newPlataform.SetActive (true);

			if(Random.Range(0f, 100f) < randomCoinTreshold){

				theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.x));
			}

			if(Random.Range(0f, 100f) < randomObstaculo){

				GameObject newObstaculo = obstaculosPool[obstaculoSelector].GetPooledObject();
				float obstaculoXposition = Random.Range(- plataformWidths[plataformSelector] /2 + 1 , plataformWidths[plataformSelector]/2 - 1);
				Vector3 obstaculoPosition = new Vector3 (obstaculoXposition, 0.65625f,0f);
				newObstaculo.transform.position = transform.position + obstaculoPosition;
				newObstaculo.transform.rotation = transform.rotation;
				newObstaculo.SetActive (true);
			}


			
			transform.position = new Vector3 (transform.position.x + (plataformWidths[plataformSelector] /2), transform.position.y, transform.position.z);

		}
	}
}