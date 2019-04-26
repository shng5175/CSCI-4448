using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public float jumpTime;
    public float jumpTimeCounter;

    private Rigidbody2D myRigidBody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    public GameManager theGameManager;

    //private Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        jumpTimeCounter = jumpTime;

    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)){
            jumpTimeCounter = 0;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        //myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        //myAnimator.SetBool("Grounded", grounded);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "killbox"){
            theGameManager.Restart();
        }
    }
}
