

using UnityEngine;

public class HeroStateRunning : State<HeroController>
{
    private float mMovement;
    private bool mIsJumpPressed = false;
    private bool mIsShootPressed = false;
    private Animator mAnimator;
    private Rigidbody2D mRb;


    public HeroStateRunning(
        HeroController controller, 
        FiniteStateMachine<HeroController> fsm) : base(controller, fsm)
    {}

    public override void HandleInput()
    {
        base.HandleInput();
        mMovement = Input.GetAxis("Horizontal");
        mIsJumpPressed = Input.GetKeyDown(KeyCode.Space);
        mIsShootPressed = Input.GetMouseButtonDown(0);
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
        // Cambiar Running -> Idle
        if (mMovement == 0f) mFsm.ChangeState(mController.idleState);
        // Cambiamos de estado: RunningState -> JumpingState
        if (mIsJumpPressed) mFsm.ChangeState(mController.jumpingState);
        // Cambiamos de estado: RunningState -> ShootingState
        if (mIsShootPressed) mFsm.ChangeState(mController.shootingState);

        if (mMovement > 0f || mMovement < 0f )
        {
            mAnimator.SetBool("isMoving", true);
        }else
        {
            mAnimator.SetBool("isMoving", false);
        }
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
        mRb.velocity = new Vector2(
            mMovement * mController.speed,
            mRb.velocity.y
        );

        if (mRb.velocity.x != 0f)
        {
            mController.transform.localScale = new Vector3(
                mRb.velocity.x < 0f ? -1f : 1f,
                mController.transform.localScale.y,
                mController.transform.localScale.z
            );
        }
    }

    public override void OnStart()
    {
        base.OnStart();
        mAnimator = mController.transform.GetComponent<Animator>();
        mRb = mController.transform.GetComponent<Rigidbody2D>();
    }

    public override void OnStop()
    {
        base.OnStop();
    }
}
