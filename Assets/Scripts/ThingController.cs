using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ThingController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxHealth;

    private Rigidbody2D mRb;
    private Animator mAnimator;
    private float mHealth;

    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mHealth = maxHealth;
        
    }

    private void Update()
    {
        mRb.velocity = new Vector2(-speed, mRb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            mHealth -= 25f;
            Debug.Log($"Enemy Health: {mHealth}");
            if (mHealth <= 0)
            {
                // Morir
                mRb.velocity = Vector2.zero;
                mAnimator.SetTrigger("Die");
            }
        }
        
    }
}
