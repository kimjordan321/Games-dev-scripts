using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    private Rigidbody2D rb2d;
    public Collider2D Coll;
    public static bool inWater;


    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Coll = GetComponent<Collider2D>();
        Coll.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.attachedRigidbody.gravityScale = 0.5f;
            movement.moveSpeed = 5;
            inWater = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.attachedRigidbody.gravityScale = 5f;
            movement.moveSpeed = 10;
            inWater = false;
        }
           
    }

}
