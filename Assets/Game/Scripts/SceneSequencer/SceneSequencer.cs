using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public sealed class SceneSequencer : MonoBehaviour
{
    [SerializeField] private Title titleScenePrefab;
    [SerializeField] private InGame inGameScenePrefab;
    [SerializeField] private Result resultScenePrefab;

    //private IScreenFader fader;

    private void Awake()
    {
        //fader = FindObjectOfType<ScreenFader>();
    }

    private async void Start()
    {
        for (;;)
        {
            // タイトル.
            var title = Instantiate(titleScenePrefab, transform) as IScene;
            await title.IsEndAsync();
            title.Close();

            // インゲーム.
            var inGame = Instantiate(inGameScenePrefab, transform) as IScene;
            await inGame.IsEndAsync();
            inGame.Close();

            // リザルト.
            var result = Instantiate(resultScenePrefab, transform) as IScene;
            await result.IsEndAsync();
            result.Close();
        }
    }
}