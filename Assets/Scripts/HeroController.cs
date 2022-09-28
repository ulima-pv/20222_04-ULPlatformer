using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpSpeed;

    private float mMovement = 0f;    
    private bool mIsJumpPressed = false;
    private Rigidbody2D mRb;

    void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        //transform.position += mMovement * speed * Time.fixedDeltaTime * Vector3.right;
        mRb.velocity = new Vector2(
            mMovement * speed,
            mRb.velocity.y
        );

        if (mIsJumpPressed) 
        {
            // Comenzar salto
            Jump();
        }
    }

    void Update()
    {
        mMovement = Input.GetAxis("Horizontal"); 
        //mIsJumpPressed = Input.GetKeyDown(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mIsJumpPressed = true;
        }

    }

    private void Jump()
    {
        mRb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
        mIsJumpPressed = false;
    }
}
