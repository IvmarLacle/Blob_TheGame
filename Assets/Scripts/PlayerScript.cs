using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    [HideInInspector] public Vector2 spawnPos;
    
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform groundCheckLeft;
    [SerializeField] private Transform groundCheckRight;
   
    private bool isGroundedLeft;
    private bool isGroundedRight;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    public Transform firePoint;
    public GameObject projectilePrefab;
    
    public AudioClip[] audioClip;
    
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CancelAnim();
        Shoot();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
            Move(movingLeft: false);
        else if (Input.GetKey(KeyCode.A))
            Move(movingLeft: true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(audioClip[1], transform.position, 1f);
            anim.SetBool("IsJumping", true);
            Jump();
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("WeaponSpawn", false);
        }
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("WeaponSpawn", true);
            
       
            if (Input.GetButtonDown("Fire1"))
            {
                AudioSource.PlayClipAtPoint(audioClip[2],transform.position,1f);
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
    

    private void CancelAnim()
    {
        if (rb.velocity.y == 0)
        {
            anim.SetBool("IsJumping", false);
        }
    }

    private void Move(bool movingLeft)
    {
        
        if (movingLeft)
        {
            transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);
            sr.flipX = true; //Can change to false
        }
        else
        {
            transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
            sr.flipX = false; //Can change to true
        }
    }

    private void Jump()
    {
        if (!isGroundedLeft && !isGroundedRight)
        {
            return;
        }
        
        
        rb.velocity = Vector2.up * jumpVelocity;
    }
    
    private void FixedUpdate()
    {
        isGroundedLeft = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground"));
        isGroundedRight = Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground"));
        

        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
    
  

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Goal"))
        {
            AudioSource.PlayClipAtPoint(audioClip[0],transform.position, 2f);
            GameManager.instance.LoadNextLevel();
            spawnPos = GameObject.Find("SpawnPos").transform.position;
            GameManager.instance.player.transform.position = spawnPos;
        }
    }
}
