using System.Collections.Generic;
using Gold.Setting;

namespace Gold
{
    public class GoldModel
    {
        public int Gold { get; private set; }

        public GoldModel(IGoldSetting setting)
        {
            Gold = setting.Gold;
        }
    }
}