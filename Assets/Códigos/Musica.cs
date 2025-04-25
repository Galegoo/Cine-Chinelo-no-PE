using UnityEngine;
using System.Collections;

public class Musica : MonoBehaviour {
	public AudioSource trilha;

	private static Musica instance = null;
	
	public static Musica Instance {
		get { return instance; }
	}
	
	void Awake() 
	{
		if (instance != null && instance != this) 
		{
			if(instance.trilha.clip != trilha.clip)
			{
				instance.trilha.clip = trilha.clip;
				instance.trilha.volume = trilha.volume;
				instance.trilha.Play();
			}
			
			Destroy(this.gameObject);
			return;
		} 
		instance = this;
		trilha.Play ();
		DontDestroyOnLoad(this.gameObject);
	}
}