using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishmovement : MonoBehaviour
{


    public Rigidbody2D rb;
    public float speed = 1;
    // Use this for initialization
    private SpriteRenderer spRend;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spRend = GetComponent<SpriteRenderer>();
    }









    void FixedUpdate()
    {
        Vector2 Movement = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
        rb.AddForce(Movement);
        print(Movement);
        



    }

    
}
    /*public float moveSpeed = 1f;
    public float maxX = 28.0f;
    public float minX = -12.0f;
    public float maxY = -7f;
    public float minY = -37.0f;
    public float minZ = -37.0f;
    public float maxZ = -7f;
    public Transform fish;
    

 private float tChange = 0; 
    private float randomX;
    private float randomY;
    private float randomZ;
 
 void FixedUpdate()
    {
        
        if (Time.time >= tChange)
        {
            StartCoroutine(wait());
            randomX = Random.Range(-5f, 5f); 
            randomY = Random.Range(-5f, 5f);
            randomZ = Random.Range(-5f, 5f); 
                                               
            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }

        StartCoroutine(wait());
        transform.Translate(new Vector2(randomX, randomY) * moveSpeed * Time.deltaTime);
        
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            StartCoroutine(wait());
            randomX = -randomX;
            print(randomX);
        }
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            StartCoroutine(wait());
            randomY = -randomY;
            print(randomY);
        }

        /*if (transform.position.z >=maxZ || transform.position.z <= minZ)
        {
            randomZ = -randomZ;
        }*/




