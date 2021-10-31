using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IInputProvider
{
    public IReadOnlyReactiveProperty<Unit> OnPushedLeft { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedRight { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedUp { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedDown { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedDecide { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedCancel { get; }
}
