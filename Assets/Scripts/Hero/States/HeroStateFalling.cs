

using UnityEngine;

public class HeroStateFalling : State<HeroController>
{
    private Animator mAnimator;
    private CapsuleCollider2D mCollider;

    public HeroStateFalling(
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

        if (!IsJumping()) mFsm.ChangeState(mController.idleState);
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
    }

    public override void OnStart()
    {
        base.OnStart();
        mAnimator = mController.transform.GetComponent<Animator>();
        mCollider = mController.transform.GetComponent<CapsuleCollider2D>();

        mAnimator.SetBool("isFalling", true);
    }

    public override void OnStop()
    {
        base.OnStop();
        mAnimator.SetBool("isFalling", false);
    }

    private bool IsJumping()
    {
        Vector3 mRaycastPointCalculated = new Vector3(
            mCollider.bounds.center.x,
            mCollider.bounds.center.y - mCollider.bounds.extents.y,
            mController.transform.position.z
        );

        RaycastHit2D hit = Physics2D.Raycast(
            mRaycastPointCalculated,// Posicion origen
            Vector2.down,// Direccion
            mController.raycastDistance// Distancia
        );
        if (hit)
        {
            return false;
        }else
        {
            return true;
        }
    }
}
