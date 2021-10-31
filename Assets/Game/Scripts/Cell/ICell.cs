using Game.Scripts.Cell;

public interface ICell : IMoveCheckable
{
    CellType Type { get; set; }
}
