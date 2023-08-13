using Health.Setting;

namespace Health.Model
{
    public class HealthModel : IHealthModel
    {
        public int Health { get; set; }

        public HealthModel(HealthSetting setting)
        {
            Health = setting.Health;
        }
    }
}