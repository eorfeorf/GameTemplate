using UnityEngine;

public sealed class Result : SceneBase
{
    private void Update()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.C))
        {
            IsEnd = true;
=======
        protected override void Awake()
        {
            base.Awake();
        }

        private async void OnEnable()
        {
            await fader.FadeIn(ct);
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                await fader.FadeOut(ct);
                isEnd = true;
            }
>>>>>>> 22ce05d... リファクタリング
        }
    }
}
