using UnityEngine;
using Health;
using Gold;
using Rating;
using Shop;
using Core.Loader;

public class Main : MonoBehaviour
{
    void Start()
    {
        var loaderFabric = new LoaderFabric();

        var healthManager = new HealthManager();
        var goldManager = new GoldManager();
        var ratingManager = new RatingManager();

        var shopManager = ShopManager.Instance;
        shopManager.LoadSettings(loaderFabric.GetScriptableObjectLoader());

        shopManager.SowShop(loaderFabric.GetSceneLoader());
    }
}
