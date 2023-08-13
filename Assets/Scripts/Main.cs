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
        var loaderFactory = new LoaderFactory();
        var prefabLoader = loaderFactory.GetLoader<IPrefabLoader>();

        HealthManager.Initialize(prefabLoader);
        GoldManager.Initialize(prefabLoader);
        RatingManager.Initialize(prefabLoader);

        ShopManager.Initialize(prefabLoader);
        ShopManager.Instance.SowShop();
    }
}
