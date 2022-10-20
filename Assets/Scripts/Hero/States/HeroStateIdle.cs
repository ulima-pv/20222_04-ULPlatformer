
using UnityEngine;

public class HeroStateIdle : State<HeroController>
{
    private float mMovement;
    private bool mIsJumpPressed = false;
    private bool mIsShootPressed = false;

    public HeroStateIdle(
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
        // Cambiamos de estado: IdleState -> RunningState
        if (mMovement != 0f) mFsm.ChangeState(mController.runningState);
        // Cambiamos de estado: IdleState -> JumpingState
        if (mIsJumpPressed) mFsm.ChangeState(mController.jumpingState);
        // Cambiamos de estado: IdleState -> ShootingState
        if (mIsShootPressed) mFsm.ChangeState(mController.shootingState);
        
    }

    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnStop()
    {
        base.OnStop();
    }

}
