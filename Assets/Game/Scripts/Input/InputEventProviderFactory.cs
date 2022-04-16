using GameFramework.Input;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Scripts.Input
{
    /// <summary>
    /// Unityから入力イベントを生成するクラス
    /// </summary>
    public class InputEventProviderFactory : MonoBehaviour
    {
        private IInputEventProvider inputEventProvider;
    
        public IInputEventProvider Initialize()
        {
            
            // TODO:ランタイムで入力タイプを切り替えられるようにする.
            inputEventProvider = gameObject.AddComponent<PlayerInputEventProvider>();   
        
#if UNITY_EDITOR
            inputEventProvider = gameObject.AddComponent<DebugKeyInputEventProvider>();
#endif
        
            Assert.IsNotNull(inputEventProvider);

            return inputEventProvider;
        }
    }
}
