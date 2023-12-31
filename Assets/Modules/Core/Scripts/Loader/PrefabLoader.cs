namespace Core.Loader
{
    public class PrefabLoader : IPrefabLoader
    {
        public T Load<T>(string path) where T : UnityEngine.Object
        {
            var prefab = UnityEngine.Resources.Load<T>(path);
            return UnityEngine.Object.Instantiate(prefab);
        }
    }
}