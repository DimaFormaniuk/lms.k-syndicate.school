namespace CodeBase.Infrastructure.States
{
    public interface IState : IExitableState
    {
        public void Enter();
    }

    public interface IExitableState
    {
        public void Exit();
    }

    public interface IPayloadedState<Tpayload> : IExitableState
    {
        public void Enter(Tpayload payload);
    }
}