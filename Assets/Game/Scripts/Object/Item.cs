using System;
using Game.Scripts.Cell;
using UnityEngine;

namespace Game.Scripts.Object
{
    public class Item : CellBase, IOnPassed
    {
        public Action OnPassed { get; }
    }
}
