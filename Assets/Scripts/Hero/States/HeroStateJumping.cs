

using UnityEngine;

public class HeroStateJumping : State<HeroController>
{
    private Rigidbody2D mRb;
    private Animator mAnimator;
    
    public HeroStateJumping(
        HeroController controller, 
        FiniteStateMachine<HeroController> fsm
    ) : base(controller, fsm)
    {
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
        // Cambio de estado: Jumping -> Falling
        if (mRb.velocity.y < 0) mFsm.ChangeState(mController.fallingState);
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
    }

    public override void OnStart()
    {
        base.OnStart();
        mRb = mController.transform.GetComponent<Rigidbody2D>();
        mAnimator = mController.transform.GetComponent<Animator>();

        mRb.AddForce(
            Vector3.up * mController.jumpSpeed, 
            ForceMode2D.Impulse
        );
        mAnimator.SetBool("isJumping", true);
    }

    public override void OnStop()
    {
        base.OnStop();
        mAnimator.SetBool("isJumping", false);
    }
}
