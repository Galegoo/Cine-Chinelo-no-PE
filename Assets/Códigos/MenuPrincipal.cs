using UnityEngine;
using System.Collections;

public class MenuPrincipal : MonoBehaviour {

	public string playGameLevel;
	public string playGameLevel2;
	public string playGameLevel3;
	public string playGameLevel4;
	public string playGameLevel5;

	public void JogarNivel1()
	{
		Application.LoadLevel (playGameLevel);
		}
	public void JogarNivel2()
	{
		Application.LoadLevel (playGameLevel5);
	}
	public void Jogar()
	{
		Application.LoadLevel (playGameLevel4);
	}

	public void Instrucoes()
	{
		Application.LoadLevel (playGameLevel2);
	}

	public void Creditos()
	{
		Application.LoadLevel (playGameLevel3);
		
	}

	public void Sair()
	{
		Application.Quit ();
		
	}
	
	
}
