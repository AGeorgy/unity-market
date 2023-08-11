using UnityEngine.SceneManagement;

namespace Core.Loader
{
    public class SceneLoader : ISceneLoader
    {
        public void Load(string path)
        {
            SceneManager.LoadScene(path, LoadSceneMode.Additive);
        }
    }
}