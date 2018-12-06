using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Sprite [] healths;
	public Image lives;
	public Text kills;
	public GameObject menu;
	public int kill = 0;
	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	public void health (int life)
	{
		lives.sprite = healths[life];
	}

	public void score ()
	{
		kill += 1;
		kills.text = "KILLS: " + kill;
	}

	public void menuUp ()
	{
		menu.SetActive(true);
	}

	public void menuDown ()
	{
		menu.SetActive(false);
		kills.text = "KILLS: ";
		kill = 0;
	}
}
