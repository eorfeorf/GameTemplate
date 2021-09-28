using UnityEngine;

public interface IScreenFader
{
    public void FadeIn(float time, Color color);
    public void FadeOut(float time, Color color);
    
    public void FadeIn(float time);
    public void FadeOut(float time);

    public void FadeIn();
    public void FadeOut();

}
