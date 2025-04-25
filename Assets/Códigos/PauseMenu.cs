using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	public GameObject pauseMenu;

	public void PauseGame (){
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);
	}

	public void continuar(){
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		}

	public void RestartGame(){
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		FindObjectOfType<GameManager> ().Reset ();	
	}
	
	public void QuitToMain(){
		Time.timeScale = 1f;
		Application.LoadLevel (mainMenuLevel);
		
	}
}
