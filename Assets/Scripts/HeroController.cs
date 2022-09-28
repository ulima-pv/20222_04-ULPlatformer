using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float raycastDistance;

    private float mMovement = 0f;    
    private bool mIsJumpPressed = false;
    private bool mIsJumping = true;
    private Rigidbody2D mRb;
    private Transform mRaycastPoint;
    private CapsuleCollider2D mCollider;
    private Vector3 mRaycastPointCalculated;

    void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mRaycastPoint = transform.Find("RaycastPoint");
        mCollider = GetComponent<CapsuleCollider2D>();
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

        mRaycastPointCalculated = new Vector3(
            mCollider.bounds.center.x,
            mCollider.bounds.center.y - mCollider.bounds.extents.y,
            transform.position.z
        );

        IsJumping();

        // Informativo
        Debug.DrawRay(
            mRaycastPointCalculated,
            Vector2.down * raycastDistance,
            mIsJumping == true ? Color.green : Color.white
        );
    }

    void Update()
    {
        mMovement = Input.GetAxis("Horizontal"); 
        //mIsJumpPressed = Input.GetKeyDown(KeyCode.Space);
        if (!mIsJumping && Input.GetKeyDown(KeyCode.Space))
        {
            mIsJumpPressed = true;
        }

    }

    private void Jump()
    {
        mRb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
        mIsJumping = true;
        mIsJumpPressed = false;
    }

    private void IsJumping()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            mRaycastPointCalculated,// Posicion origen
            Vector2.down,// Direccion
            raycastDistance// Distancia
        );
        if (hit)
        {
            // Hay una colision, esta en el suelo
            mIsJumping = false;
        }
    }
}