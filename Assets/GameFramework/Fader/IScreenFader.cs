using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IScreenFader
{
    public UniTask FadeIn(float time, Color color);
    public UniTask FadeOut(float time, Color color);
    
    public UniTask FadeIn(float time);
    public UniTask FadeOut(float time);

    public UniTask FadeIn();
    public UniTask FadeOut();

}
