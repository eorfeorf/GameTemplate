using UnityEngine;

public sealed class InGame : SceneBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            IsEnd = true;
        }
    }
}
