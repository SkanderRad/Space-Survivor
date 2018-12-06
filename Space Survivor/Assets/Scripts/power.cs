using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power : MonoBehaviour 
{
	[SerializeField]
	private int speedPow = 4;
	
	[SerializeField]
	private int id;

	[SerializeField]
	private AudioClip powerFX;
	void Start () 
	{		
	}
	
	void Update () 
	{
		transform.Translate(Vector3.down * Time.deltaTime * speedPow);	
		if (transform.position.y < -6)
			Destroy(this.gameObject);
	}

	private void OnTriggerEnter2D (Collider2D obj) 
	{	
		if (obj.tag == "Player")
		{	
			AudioSource.PlayClipAtPoint(powerFX, Camera.main.transform.position);
			Player player1 = obj.GetComponent<Player>();
			
			if(player1 != null)
			{	
				if (id == 0)	
					player1.tripleUp();	
				else if (id ==1)
					player1.speedUp();
				else if (id == 2)
					player1.shieldUp();			
			}
			Destroy (this.gameObject);
		}
	}
}
