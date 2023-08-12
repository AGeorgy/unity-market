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

        HealthManager.Initialize(loaderFactory.GetLoader<IPrefabLoader>());
        GoldManager.Initialize(loaderFactory.GetLoader<IPrefabLoader>());
        RatingManager.Initialize(loaderFactory.GetLoader<IPrefabLoader>());

        ShopManager.Initialize(loaderFactory.GetLoader<IPrefabLoader>());
        ShopManager.Instance.SowShop();
    }
}
