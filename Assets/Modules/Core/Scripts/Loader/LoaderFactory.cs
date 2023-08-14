
using System;
using System.Collections.Generic;

namespace Core.Loader
{
    public class LoaderFactory
    {
        private Dictionary<Type, object> _loaders;

        public LoaderFactory()
        {
            _loaders = new Dictionary<Type, object>
            {
                { typeof(IPrefabLoader), new PrefabLoader() },
                { typeof(ISceneLoader), new SceneLoader() }
            };
        }

        public T GetLoader<T>()
            where T : class
        {
            if (_loaders.TryGetValue(typeof(T), out var loader))
            {
                return (T)loader;
            }
            else
            {
                throw new Exception($"Loader {typeof(T)} not found");
            }
        }
    }
}
