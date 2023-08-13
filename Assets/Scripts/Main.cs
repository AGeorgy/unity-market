using UnityEngine;
using Health;
using Gold.View;
using Rating;
using Core.Loader;
using Shop.Setting;
using Shop.Model;
using Shop.View;
using Gold.Setting;
using Gold.Model;
using Health.Setting;
using Health.Model;
using Rating.Setting;
using Rating.Model;
using Health.View;
using Rating.View;

public class Main : MonoBehaviour
{
    private const string SETTING_GOLD_NAME = "GoldSetting";
    private const string SETTING_HEALTH_NAME = "HealthSetting";
    private const string SETTING_RATING_NAME = "RatingSetting";
    private const string SETTING_SHOP_NAME = "ShopSetting";

    private const string VIEW_SHOP = "ShopView";
    private const string PANEL = "Panel";
    private const string VIEW_GOLD_COUNTER = "GoldCounterView";
    private const string VIEW_HEALTH_COUNTER = "HealthCounterView";
    private const string VIEW_RATING_COUNTER = "RatingCounterView";

    private IShopModel _shopModel;

    private void Start()
    {
        var loaderFactory = new LoaderFactory();
        var prefabLoader = loaderFactory.GetLoader<IPrefabLoader>();


        var panel = prefabLoader.Load<GameObject>(PANEL);

        var goldSetting = prefabLoader.Load<GoldSetting>(SETTING_GOLD_NAME);
        var goldModel = new GoldModel(goldSetting);
        var goldCounterController = prefabLoader.Load<GoldCounterController>(VIEW_GOLD_COUNTER);
        goldCounterController.transform.SetParent(panel.transform);
        goldCounterController.Init(goldModel);

        var healthSetting = prefabLoader.Load<HealthSetting>(SETTING_HEALTH_NAME);
        var healthModel = new HealthModel(healthSetting);
        var healthCounterController = prefabLoader.Load<HealthCounterController>(VIEW_HEALTH_COUNTER);
        healthCounterController.transform.SetParent(panel.transform);
        healthCounterController.Init(healthModel);

        var ratingSetting = prefabLoader.Load<RatingSetting>(SETTING_RATING_NAME);
        var ratingModel = new RatingModel(ratingSetting);
        var ratingCounterController = prefabLoader.Load<RatingCounterController>(VIEW_RATING_COUNTER);
        ratingCounterController.transform.SetParent(panel.transform);
        ratingCounterController.Init(ratingModel);

        var validator = new Validator(goldModel, healthModel, ratingModel);
        var spender = new Spender(goldModel, healthModel, ratingModel);
        var rewarder = new Rewarder(goldModel, healthModel, ratingModel);

        var shopSetting = prefabLoader.Load<ShopSetting>(SETTING_SHOP_NAME);
        _shopModel = new ShopModel(shopSetting, validator, spender, rewarder);
        var shopController = prefabLoader.Load<ShopController>(VIEW_SHOP);
        shopController.Init(_shopModel);
    }
}
