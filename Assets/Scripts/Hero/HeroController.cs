using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float jumpSpeed;
    [SerializeField]
    public float raycastDistance;
    [SerializeField]
    private GameObject prefabBullet;

    private float mMovement = 0f;    
    private bool mIsJumpPressed = false;
    private bool mIsJumping = false;
    private Rigidbody2D mRb;
    private Transform mRaycastPoint;
    private CapsuleCollider2D mCollider;
    private Vector3 mRaycastPointCalculated;
    private Animator mAnimator;
    private Transform mBulletSpawnPoint;

    private FiniteStateMachine<HeroController> mFsm;

    // Estados (instancias)
    public HeroStateIdle idleState;
    public HeroStateJumping jumpingState;
    public HeroStateFalling fallingState;
    public HeroStateRunning runningState;
    public HeroStateShooting shootingState;


    void Awake()
    {
        mFsm = new FiniteStateMachine<HeroController>();
        idleState = new HeroStateIdle(this, mFsm);
        jumpingState = new HeroStateJumping(this, mFsm);
        fallingState = new HeroStateFalling(this, mFsm);
        runningState = new HeroStateRunning(this, mFsm);
        shootingState = new HeroStateShooting(this, mFsm);
    }

    void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mRaycastPoint = transform.Find("RaycastPoint");
        mCollider = GetComponent<CapsuleCollider2D>();
        mAnimator = GetComponent<Animator>();
        mBulletSpawnPoint = transform.Find("BulletSpawnPoint");

        mFsm.Start(idleState);
    }

    void FixedUpdate()
    {
        mFsm.CurrentState.OnPhysicsUpdate();
    }

    void Update()
    {
        mFsm.CurrentState.HandleInput();
        mFsm.CurrentState.OnLogicUpdate();

        /*if (Input.GetMouseButtonDown(0))
        {
            // Animacion de disparo
            mAnimator.SetTrigger("shoot");
            Fire();
        }*/
    }

    private void Fire()
    {
        Instantiate(
            prefabBullet, 
            mBulletSpawnPoint.position, 
            Quaternion.identity
        );
    }

    public int GetPointDirection()
    {
        return (int)transform.localScale.x;
    }
}
