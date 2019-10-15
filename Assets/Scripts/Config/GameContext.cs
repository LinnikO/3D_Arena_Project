using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class GameContext : MVCSContext
{
    public GameContext(MonoBehaviour contextView, ContextStartupFlags flag) : base(contextView, flag)
    {}


    protected override void mapBindings()
    {
        injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();

        injectionBinder.Bind<StartSignal>().ToSingleton();
        injectionBinder.Bind<MoveAxisSignal>().ToSingleton();
        injectionBinder.Bind<LookAxisSignal>().ToSingleton();
        injectionBinder.Bind<FireButtonSignal>().ToSingleton();

        commandBinder.Bind<StartSignal>().To<StartCommand>();

        mediationBinder.Bind<InputView>().To<InputViewMediator>();
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    public override void Launch()
    {
        base.Launch();
        StartSignal startSignal = injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
    }
}
