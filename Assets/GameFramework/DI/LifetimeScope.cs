using UnityEngine;

namespace GameFramework.DI
{
    /// <summary>
    /// コンテナ(スコープ)を表現
    /// </summary>
    public abstract class LifetimeScope : MonoBehaviour
    {
        protected abstract void Configure(IContainerBuilder builder);
    }
}
