using UnityEngine;
using Health;
using Gold;
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

public class Main : MonoBehaviour
{
    private const string SETTING_GOLD_NAME = "GoldSetting";
    private const string SETTING_HEALTH_NAME = "HealthSetting";
    private const string SETTING_RATING_NAME = "RatingSetting";
    private const string SETTING_SHOP_NAME = "ShopSetting";

    private const string VIEW_NAME = "ShopView";
    private IShopModel _shopModel;

    private void Start()
    {
        var loaderFactory = new LoaderFactory();
        var prefabLoader = loaderFactory.GetLoader<IPrefabLoader>();

        var goldSetting = prefabLoader.Load<GoldSetting>(SETTING_GOLD_NAME);
        var goldModel = new GoldModel(goldSetting);

        var healthSetting = prefabLoader.Load<HealthSetting>(SETTING_HEALTH_NAME);
        var healthModel = new HealthModel(healthSetting);

        var ratingSetting = prefabLoader.Load<RatingSetting>(SETTING_RATING_NAME);
        var ratingModel = new RatingModel(ratingSetting);

        var validator = new Validator(goldModel, healthModel, ratingModel);
        var spender = new Spender(goldModel, healthModel, ratingModel);
        var rewarder = new Rewarder(goldModel, healthModel, ratingModel);

        var shopSetting = prefabLoader.Load<ShopSetting>(SETTING_SHOP_NAME);
        _shopModel = new ShopModel(shopSetting, validator, spender, rewarder);
        var shopController = prefabLoader.Load<ShopController>(VIEW_NAME);
        shopController.Init(_shopModel);
    }
}
