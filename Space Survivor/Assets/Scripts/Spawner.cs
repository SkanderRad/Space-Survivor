using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{	
	[SerializeField]
	private GameObject enemy;
	
	[SerializeField]
	private GameObject [] powerups;
	private GameManager gManager;
	void Start ()
	{
		gManager = GameObject.Find("GameManager").GetComponent<GameManager>();			
	}

	public void spawn ()
	{
		StartCoroutine(spawn_enemy());
		StartCoroutine(spawn_power());
	}

	public IEnumerator spawn_enemy ()
	{	
		while (gManager.over == false)
		{	
			Instantiate (enemy, new Vector3 (Random.Range(-7.95f, 8.95f), 6.45f, 0), Quaternion.identity);
			yield return new WaitForSeconds (2.5f);
		}
	}

	public IEnumerator spawn_power ()
	{
		while (gManager.over == false)
		{	
			int randId = Random.Range (0,3);
			Instantiate(powerups[randId], new Vector3(Random.Range(-8,8), 5.5f, 0), Quaternion.identity);
			yield return new WaitForSeconds (7.0f);
		}
	}
}
