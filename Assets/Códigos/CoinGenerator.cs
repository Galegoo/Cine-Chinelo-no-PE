using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool;

	public float distanceBetweenCoins;

	public void SpawnCoins (Vector3 startPosition){

		GameObject coin1 = coinPool.GetPooledObject();
		coin1.transform.position = new Vector3(startPosition.x , startPosition.y, 35);
		coin1.SetActive (true);

		GameObject coin2 = coinPool.GetPooledObject();
		coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, 35);
		coin2.SetActive (true);

		GameObject coin3 = coinPool.GetPooledObject();
		coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y,35 );
		coin3.SetActive (true);
	}

}
