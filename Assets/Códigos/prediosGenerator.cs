using UnityEngine;
using System.Collections;

public class prediosGenerator : MonoBehaviour {
	
	public Transform backGroundGenerator;
	public GameObject backGround;
	public Transform backGroundGenerationPoint;
	public float larguraDoBG = 16;
	public ObjectPooler theObjectPooler;
	
	// Use this for initialization
	void Start () {
		//larguraDoBG = backGround.GetComponent<BoxCollider2D>().size.x;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x < backGroundGenerationPoint.position.x) {
			
			transform.position = new Vector3 (transform.position.x + larguraDoBG, transform.position.y,  transform.position.z);
			GameObject newpredio = theObjectPooler.GetPooledObject();
			newpredio.transform.position = transform.position;
			newpredio.transform.rotation = transform.rotation;
			newpredio.SetActive (true);
		}
	}
}