using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class ScreenFaderBase : MonoBehaviour, IScreenFader
{
    public abstract UniTask FadeIn(float time, Color color);
    public abstract UniTask FadeOut(float time, Color color);

    public abstract UniTask FadeIn(float time);
    public abstract UniTask FadeOut(float time);

    public abstract UniTask FadeIn();
    public abstract UniTask FadeOut();
}
