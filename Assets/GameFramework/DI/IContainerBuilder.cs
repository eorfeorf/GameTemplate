using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace GameFramework.DI
{
    /// <summary>
    /// コンテナをつくる
    /// </summary>
    public interface IContainerBuilder
    {
        void Register<T>();

        T Resolve<T>() where T : new();
    }

    public class ContainerBuilder : IContainerBuilder
    {
        private List<Type> typeMap;

        public void Register<T>()
        {
            typeMap.Add(typeof(T));
        }

        public T Resolve<T>() where T : new()
        {
            var types = new[] {typeof(T)};

            var constructorInfo = typeof(T).GetConstructor(
                BindingFlags.Instance | BindingFlags.Public,
                null,
                CallingConventions.HasThis, types, null);

            // 引数なし or 引数がなくなった
            if (constructorInfo == null)
            {
                return Activator.CreateInstance<T>();
            }

            // 引数あり
            var args = new List<Type>();
            var parameterInfos = constructorInfo.GetParameters();
            // foreach (var info in parameterInfos)
            // {
            //     var type = info.GetType();
            //     args.Add(this.Resolve<type>());
            // }

            var map = new Dictionary<string, Color>();


            foreach (var type in typeMap)
            {
                if (type is T)
                {
                    return new T();
                }
            }

            return default;
        }
    }
}