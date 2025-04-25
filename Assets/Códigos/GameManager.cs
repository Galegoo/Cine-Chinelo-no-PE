using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform plataformGenerator;
	public Vector3 plataformStartPoint;

	public PlayerController thePlayer;
	public Vector3 playerStartPoint;

	public Transform prediosGenerator;
	public Vector3 prediosGeneratorOriginPoint;

	public Transform ceuGenerator;
	public Vector3 ceuGeneratorOriginPoint;

	public Transform rioGenerator;
	public Vector3 rioGeneratorOriginPoint;

	private PlataformDestroyer [] plataformList;
		
	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;

	// Use this for initialization
	void Start () {
		plataformStartPoint = plataformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		prediosGeneratorOriginPoint = prediosGenerator.transform.position;
		ceuGeneratorOriginPoint = ceuGenerator.transform.position;
		rioGeneratorOriginPoint = rioGenerator.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame()
	{
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive(false);

		theDeathScreen.gameObject.SetActive (true);

		//StartCoroutine ("RestartGameCo");
	}

	public void Reset(){
		theDeathScreen.gameObject.SetActive (false);
		plataformList = FindObjectsOfType<PlataformDestroyer> ();
		for (int i=0; i < plataformList.Length; i++)
		{
			plataformList[i].gameObject.SetActive(false);
			
		}
		
		thePlayer.transform.position = playerStartPoint;
		plataformGenerator.position = plataformStartPoint;
		rioGenerator.position = rioGeneratorOriginPoint;
		ceuGenerator.position = ceuGeneratorOriginPoint;
		prediosGenerator.position = prediosGeneratorOriginPoint;
		thePlayer.gameObject.SetActive (true);
		
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;

	}

	/*public IEnumerator RestartGameCo()
	{
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive(false);
		yield return new WaitForSeconds(1.5f);
		plataformList = FindObjectsOfType<PlataformDestroyer> ();
		for (int i=0; i < plataformList.Length; i++)
		{
			plataformList[i].gameObject.SetActive(false);

		}

		thePlayer.transform.position = playerStartPoint;
		plataformGenerator.position = plataformStartPoint;
		rioGenerator.position = rioGeneratorOriginPoint;
		ceuGenerator.position = ceuGeneratorOriginPoint;
		prediosGenerator.position = prediosGeneratorOriginPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}*/

}
