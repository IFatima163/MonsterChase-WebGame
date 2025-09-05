using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;
    
    /*   for the following; we can: 
    1.   use [SerializeField] and drag their individual components or the player in the box,
    2.   make them public then drag their individual components or the player in the box,
    3.   or simply make an object to get direct reference. We'll make an object because
         the other two approaches have been tried already.    */ 
    
    private float movementX; //movement
    private Rigidbody2D myBody; //physics
    private SpriteRenderer sr; //to flip player's body when walking on left/right side
    private Animator anim; //animate walking or standing or jump
    private string WALK_ANIMATION = "Walk"; //to avoid misspelling
    private bool isGrounded; //to check if player is on the ground
    private string GROUND_TAG = "Ground"; //to avoid misspelling
    private string ENEMY_TAG = "Enemy"; //to avoid misspelling
    
    //making the objects mentioned in line 16
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate() //fixed update for physics 
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //gets horizontal axis b/w 0 or 1 for right and 0 or -1 for left side
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime; //shift player in the movementX axis
    }

    void AnimatePlayer()
    {
        if (movementX > 0) //going left
        {
            anim.SetBool (WALK_ANIMATION, true);
            sr.flipX = false; //player will be flipped to left
        }
        else if (movementX < 0) //going right
        {
            anim.SetBool (WALK_ANIMATION, true);
            sr.flipX = true; //player is facing right by default
        }
        else //idle
        {
            anim.SetBool (WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown ("Jump") && isGrounded) //if space is pressed and player is on the ground then:
        {
            isGrounded = false; //isGrounded is now false i.e; player is no longer on the ground
            myBody.AddForce(new Vector2 (0f, jumpForce), ForceMode2D.Impulse); //jump by adding impulsive force on Y axis only
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //sets isGrounded as true, i.e; player is touching the ground
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy (gameObject); //remove/ kill player if it touches the enemy
        }
    }

    //converting ghost into a trigger so things will pass through it and give it a "ghost" effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy (gameObject); //remove/ kill player if it touches the enemy
        }
    }
}
