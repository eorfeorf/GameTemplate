using Cysharp.Threading.Tasks;

/// <summary>
/// 外部操作用のインターフェイス. 
/// </summary>
public interface IScene
{
    UniTask IsEndAsync();
    void Close();
}
