using UnityEngine;
using System.Collections;

public class PlataformDestroyer : MonoBehaviour {

	public GameObject plataformDestructionPoint;

	// Use this for initialization
	void Start () {
	
		plataformDestructionPoint = GameObject.Find ("PlataformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.x < plataformDestructionPoint.transform.position.x) {

			//Destroy (gameObject);
			gameObject.SetActive(false);
		}
	}
}
