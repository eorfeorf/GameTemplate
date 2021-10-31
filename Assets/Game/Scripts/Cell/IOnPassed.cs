using System;

namespace Game.Scripts.Cell
{
    public interface IOnPassed
    {
        Action OnPassed { get; }
    }
}