using Game.Scripts.Core;
using Game.Scripts.Scene.Game;
using GameFramework.Scene;
using UnityEngine;

namespace Game.Scripts.Scene.Title
{
    public class TitlePresenter : ScenePresenterBase<TitleModel>
    {
        private void Awake()
        {
            var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameSceneManager = gameManager.GameSceneManager;

            Debug.Log("Scene:Create TitlePresenter !!!");
        }

        void Update()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.Return))
            {
                GameSceneData data = new GameSceneData();
                gameSceneManager.ChangeScene(data);
            }
        }
    }
}