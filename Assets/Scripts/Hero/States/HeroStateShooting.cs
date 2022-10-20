
public class HeroStateShooting : State<HeroController>
{
    public HeroStateShooting(
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
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
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
