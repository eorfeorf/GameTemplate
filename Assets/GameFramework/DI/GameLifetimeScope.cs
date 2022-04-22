using System.Collections;
using System.Collections.Generic;
using GameFramework.DI;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<HelloWorldService>();
        builder.Register<GamePresenter>();
    }
}
