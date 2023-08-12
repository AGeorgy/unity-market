
using System;

namespace Core.Loader
{
    public class LoaderFactory
    {
        private static readonly Lazy<IPrefabLoader> _prefabLoader = new(() => new PrefabLoader());
        private static readonly Lazy<ISceneLoader> _sceneLoader = new(() => new SceneLoader());

        public T GetLoader<T>()
            where T : class
        {
            if (typeof(T) == typeof(IPrefabLoader))
            {
                return (T)_prefabLoader.Value;
            }
            else if (typeof(T) == typeof(ISceneLoader))
            {
                return (T)_sceneLoader.Value;
            }
            else
            {
                throw new Exception($"Loader {typeof(T)} not found");
            }
        }
    }
}
