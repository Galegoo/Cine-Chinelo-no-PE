using UnityEngine;
using System.Collections;

public class BackGroundGenerator : MonoBehaviour {

	public Transform backGroundGenerator;
	public GameObject backGround;
	public Transform backGroundGenerationPoint;
	private float larguraDoBG;
	public ObjectPooler theObjectPool;

	// Use this for initialization
	void Start () {
		larguraDoBG = backGround.GetComponent<BoxCollider2D>().size.x;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < backGroundGenerationPoint.position.x) {

			transform.position = new Vector3 (transform.position.x + larguraDoBG, transform.position.y,  transform.position.z);
			GameObject newpredio = theObjectPool.GetPooledObject();
			newpredio.transform.position = transform.position;
			newpredio.transform.rotation = transform.rotation;
			newpredio.SetActive (true);
		}
	

	}
}
