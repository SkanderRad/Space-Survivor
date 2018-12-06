using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour 
{	private Animator anim;

	void Start () 
	{	
		anim = GetComponent<Animator>();		
	}
	void Update () 
	{
		if ((Input.GetKeyDown(KeyCode.Q)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
		{
			anim.SetBool("Left",true);
			anim.SetBool("Right",false);
		}
		else if ((Input.GetKeyUp(KeyCode.Q)) || (Input.GetKeyUp(KeyCode.LeftArrow)))
		{
			anim.SetBool("Left",false);
		}

		if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
		{
			anim.SetBool("Right",true);
			anim.SetBool("Left",false);
		}
		else if ((Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.RightArrow)))
		{
			anim.SetBool("Right",false);
		}

	}
}
