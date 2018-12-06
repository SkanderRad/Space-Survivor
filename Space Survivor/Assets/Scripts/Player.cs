using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    public int health = 3;
    public float fire = 0.5f;

    [SerializeField]
    private float speedVal = 8.0f;
    
    [SerializeField]
    private bool speed = false;
    public bool shieldval = false;
    public bool triple = false;

    [SerializeField]
    private GameObject laserPrefab;
    
    [SerializeField]
    private GameObject triplePrefab;
    
    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private GameObject shields;

    [SerializeField]
    private GameObject thrusters;
    private float fireTime = 0.0f;
    private UI ui;
    private GameManager manager;
    private Spawner spawns;

    private AudioSource laserFX;


    void Start ()
    {   manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        spawns = GameObject.Find("Spawner").GetComponent<Spawner>();
        laserFX = GetComponent<AudioSource>();
       
        if(spawns != null)
            spawns.spawn();
        if (ui != null)
            ui.health(health);
        
        transform.position = new Vector3(0, -3.9f, 0);

	}

	void Update ()
    {
        movement();

        if ((Input.GetKeyDown(KeyCode.Space)) && (triple == true))
        {   
            tripleShoot();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
           // StartCoroutine(FadeColor(Color.red));
        }

    } 
    
    private void shoot ()
    {   
        if (Time.time > fireTime) 
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity);
                laserFX.Play();
                fireTime = Time.time + fire;
            }
    }

    //LASER POWER UP
    private void tripleShoot ()
    {
        if (Time.time > fireTime) 
            {
                Instantiate(triplePrefab, transform.position, Quaternion.identity);
                laserFX.Play();
                fireTime = Time.time + fire;

            }
    }

    private void movement ()
    {   
        //PLAYER MOVEMENT
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        transform.Translate(Vector3.right * Time.deltaTime * speedVal * horizon);
        transform.Translate(Vector3.up * Time.deltaTime * speedVal * vertical);

        //SPEED POWER UP
        if (speed == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedVal* 1.1f * horizon);
            transform.Translate(Vector3.up * Time.deltaTime * speedVal * 1.1f * vertical); 
        }

        //MAP MECHANICS
        if (transform.position.y > 4.2)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        }
        else if (transform.position.y < -4.2)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
        else if (transform.position.x > 8.3)
        {
            transform.position = new Vector3(-8.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.3)
        {
            transform.position = new Vector3(8.3f, transform.position.y, 0);
        }
    } 

    //COMBAT MECHANICS
    public void combat ()
    {
        if (shieldval == false)
            damage();         
    }
    public void damage ()
    {
	    health --;
        ui.health(health);
        if (health < 1)
        {   
            Instantiate(explosion, transform.position, Quaternion.identity);
            manager.over = true;
            ui.menuUp();			
            Destroy(this.gameObject);
        }
    }

    //POWER UPS
    public void speedUp ()
    {
        thrusters.SetActive(true);
        speed = true;
        StartCoroutine (speedDown());
    }
    public IEnumerator speedDown()
    {
        yield return new WaitForSeconds (2.0f);
        thrusters.SetActive(false);
        speed = false;
    }
    public void tripleUp ()
    {
        triple = true;
        StartCoroutine(tripleDown());
    }
    public IEnumerator tripleDown ()
    {
        yield return new WaitForSeconds (3.0f);
        triple = false;
    }
    public void shieldUp ()
    {   shields.SetActive(true);
        shieldval = true;
        StartCoroutine(shieldDown());
    }
    public IEnumerator shieldDown ()
    {
        yield return new WaitForSeconds (2.0f);
        shields.SetActive(false);
        shieldval = false;
    }

    //FUHRER FUNCTION
    public SpriteRenderer spriteRenderer;
    IEnumerator FadeColor(Color col)
    {
         while(spriteRenderer.color != col)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color , col , Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
 