using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private int speed = 20;

    void Start ()
    {
        
	}
	

	void Update ()
    {
        transform.Translate (Vector3.up * speed * Time.deltaTime);	
        if (transform.position.y > 5.5)
        {
            Destroy (this.gameObject);       
        }
	}
}
