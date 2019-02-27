using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour {


    private Rigidbody2D rb2d;
    private SpriteRenderer spRend;
    public static int moveSpeed = 10;
    private float jumpForce = 500f;
    public static int health;
    private bool jump;
    private bool isGrounded;
    [SerializeField] private Transform grouncheck;
    [SerializeField]
    private float GroundCheckRadius = 0.2f;
    public Transform WeaponPos;
    public GameObject player;
    public AudioSource jumpAudio;
    public AudioClip jumpSound;
    
    void Start()
    {
        jumpAudio = GetComponent<AudioSource>();
        jumpAudio.clip = jumpSound;
    }


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRend = GetComponent<SpriteRenderer>();

    }


    // Use this for initialization
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(grouncheck.position, GroundCheckRadius, LayerMask.GetMask("Ground"));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
        }

        else if (Water.inWater && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Move(horizontal);
    }

    private void Move(float horizontal)
    {
        rb2d.velocity = new Vector2(horizontal * moveSpeed, rb2d.velocity.y);

        if (jump)
        {
            jumpAudio.Play();
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

        if (horizontal > 0)
        {
            spRend.flipX = true;
            
        }

        else if (horizontal < 0)
        {
            spRend.flipX = false;
            

            
            
            }
    }

}

