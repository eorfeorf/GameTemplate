using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScreenFader : MonoBehaviour, IScreenFader
{
    [SerializeField] private UniversalRendererData rendererData;
    
    private readonly Color defaultColor = new Color(255f/32f,255f/32f,255f/32f,1f);
    private readonly float defaultTime = 0.5f;
    
    private Material mat;
    private float timer;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        
        var feature = rendererData.rendererFeatures.Find(item => item is ScreenFadeFeature);
        if (feature is ScreenFadeFeature screenFade)
        {
            mat = Instantiate(screenFade.settings.material);
            screenFade.settings.runTimeMaterial = mat;
        }
    }

    public void FadeIn(float time, Color color)
    {
        Debug.Log("[Fade] In Start");
        mat.SetColor("_BaseColor", color);
        timer = 0;
        
        StartCoroutine(FadeIn_Impl(time, mat));
    }

    public void FadeOut(float time, Color color)
    {
        Debug.Log("[Fade] Out Start");
        mat.SetColor("_BaseColor", color);
        timer = 0;

        StartCoroutine(FadeOut_Impl(time, mat));
    }

    public void FadeIn(float time)
    {
        FadeIn(time, defaultColor);
    }

    public void FadeOut(float time)
    {
        FadeOut(time, defaultColor);
    }

    public void FadeIn()
    {
        FadeIn(defaultTime, defaultColor);
    }

    public void FadeOut()
    {
        FadeOut(defaultTime, defaultColor);
    }

    #region Implement

    private IEnumerator FadeIn_Impl(float time, Material mat)
    {
        for (;;)
        {
            if (timer >= time)
            {
                Debug.Log("[Fade] In End");
                yield break;
            }

            timer += Time.deltaTime;
            var alpha = timer / time;
            mat.SetFloat("_Alpha", alpha);

            yield return null;
        }
    }
    
    private IEnumerator FadeOut_Impl(float time, Material mat)
    {
        for (;;)
        {
            if (timer >= time)
            {
                Debug.Log("[Fade] Out End");
                yield break;
            }

            timer += Time.deltaTime;
            var ratio = timer / time;
            var alpha = 1f - ratio;
            mat.SetFloat("_Alpha", alpha);

            yield return null;
        }
    }
    #endregion
}
