using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

    public float speed;
    GameObject[] Player;
    public int fishHealth;
    private Merchant merchantscript;
    private weapon weaponscript;
    public static int fishCount;
    public GameObject merchant;
    public int fishWorth;
    private int lWepDmg;
    public GameObject weapons;
    public Vector2 PlayArea;
    private float seconds = 10.0f;
    public AudioClip MusicClip;
    public AudioSource MusicSource;



    private Transform target;

    void Awake()
    {
        Player = GameObject.FindGameObjectsWithTag("Weapon");
        







    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        
        
        if (Col.collider.tag == "Weapon" && Merchant.wepDmg >= fishHealth)
        {
            MusicSource.Play();
            print("hi");
            fishCount = fishCount + 1;
            Merchant.FishWorth += fishWorth;
            print(Merchant.FishWorth);
            print(fishWorth);
            spawner.fish = spawner.fish - 1;
            MusicSource.Play();
            
            Destroy(this.gameObject, 0.3f);
            
        }

        

        



    }

    void FixedUpdate()
    {
        //lWepDmg = merchant.GetComponent<Merchant>().wepDmg;
        seconds -= Time.deltaTime;
        
        if(seconds <= 0)
        {
            Destroy(this.gameObject);
            spawner.fish = spawner.fish - 1;
        }

        //lWepDmg = merchant.GetComponent<Merchant>().wepDmg;
    }






    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("SetRandomPos", 0, 1);
        MusicSource.clip = MusicClip;
        MusicSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        
        PlayArea.x = Random.Range(-10, 25);
        PlayArea.y = Random.Range(-25, -40);

        
        /*if (Water.inWater == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (target.position.x > transform.position.x)
            {

                transform.localScale = new Vector2(3, 3);
            }
            else if (target.position.x < transform.position.x)
            {

                transform.localScale = new Vector2(3, 3);
            }*/
        }
    }


//}   
        

        