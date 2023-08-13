using Gold.Setting;

namespace Gold.Model
{
    public class GoldModel : IGoldModel
    {
        public int Gold { get; set; }

        public GoldModel(GoldSetting setting)
        {
            Gold = setting.Gold;
        }
    }
}