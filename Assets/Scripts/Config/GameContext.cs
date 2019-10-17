﻿using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class GameContext : MVCSContext
{
    private ObjectReferences objectReferences;

    public GameContext(MonoBehaviour contextView, ContextStartupFlags flag, ObjectReferences objectReferences) : base(contextView, flag)
    {
        this.objectReferences = objectReferences;
    }


    protected override void mapBindings()
    {
        injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();
        injectionBinder.Bind<IProjectileFactory>().To<ProjectileFactory>().ToValue(objectReferences.projectileFactory);

        injectionBinder.Bind<StartSignal>().ToSingleton();
        injectionBinder.Bind<MoveAxisSignal>().ToSingleton();
        injectionBinder.Bind<LookAxisSignal>().ToSingleton();
        injectionBinder.Bind<FireButtonSignal>().ToSingleton();
        injectionBinder.Bind<UltimateButtonSignal>().ToSingleton();
        injectionBinder.Bind<EnemyKilledSignal>().ToSingleton();
        injectionBinder.Bind<PlayerKilledSignal>().ToSingleton();
        injectionBinder.Bind<UltimateUsedSignal>().ToSingleton();

        commandBinder.Bind<StartSignal>().To<StartCommand>();

        mediationBinder.Bind<InputView>().To<InputViewMediator>();
        mediationBinder.Bind<PlayerView>().To<PlayerViewMediator>();
        mediationBinder.Bind<EnemyView>().To<EnemyViewMediator>();
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
