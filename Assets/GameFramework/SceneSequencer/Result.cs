using UnityEngine;

public sealed class Result : SceneBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isEnd = true;
        }
    }
}
