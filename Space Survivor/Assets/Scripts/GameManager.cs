using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public bool over = true;
	public GameObject player;
	private UI ui;
	void Start () 
	{
		ui = GameObject.Find("Canvas").GetComponent<UI>();
	}
	
	void Update () 
	{
		if (over == true) 
			if(Input.GetKeyDown(KeyCode.Return))
			{	
				over = false;
				Instantiate(player, new Vector3(0, -3.9f, 0), Quaternion.identity);
				ui.menuDown();
			}
			
		
	}
}
