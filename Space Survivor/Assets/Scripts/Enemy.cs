using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	[SerializeField]
	private float speedNpc = 6f;

	[SerializeField]
	private GameObject Explosion;
	
	[SerializeField]
	private AudioClip enemyFX;
	 private UI ui;
	 private GameManager gmanager;

	void Start () 
	{	
		ui = GameObject.Find("Canvas").GetComponent<UI>();
		transform.position = new Vector3 (Random.Range(-7.95f, 8.95f) , 3.65f, 0);
		gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update () 
	{
		transform.Translate (Vector3.down * Time.deltaTime * speedNpc);
		if (transform.position.y < -6.45f)
			transform.position = new Vector3 (Random.Range(-7.95f, 8.95f), 6.45f, 0);
		if(gmanager.over == true)
			Destroy(this.gameObject);

	}

	private void OnTriggerEnter2D (Collider2D objj)
	{
		if (objj.tag == "Player")
		{
			Player player2 = objj.GetComponent<Player>();
			if (player2 != null) 	
				player2.combat();
			Instantiate(Explosion, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(enemyFX, transform.position);
			ui.score();						
			Destroy(this.gameObject);	
		}
		else if (objj.tag == "Laser")
		{
			Destroy(objj.gameObject);
			Instantiate(Explosion, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(enemyFX, transform.position);
			ui.score();
			Destroy(this.gameObject);			
		}	
	}
}
