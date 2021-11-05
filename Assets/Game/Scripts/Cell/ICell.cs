using Game.Scripts.Cell;
using UnityEngine;

public interface ICell : IMoveCheckable
{
    CellType Type { get; set; }
    Vector2Int Pos { get; set; }
}
