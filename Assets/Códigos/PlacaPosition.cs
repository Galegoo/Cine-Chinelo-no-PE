using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlacaPosition : MonoBehaviour {

	public GameObject placa;
	public GameObject highSc;
	
	// Use this for initialization
	void Start () {

		//placa = GameObject.Find ("placa")();
		//highSc = GameObject.Find ("HighScoreText")();

	}

	
	// Update is called once per frame
	void Update () {
   		highSc.transform.position = placa.transform.position;
	}
}
