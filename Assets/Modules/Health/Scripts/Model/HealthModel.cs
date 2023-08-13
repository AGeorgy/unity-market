using System.Collections.Generic;
using Core;
using Health.Setting;

namespace Health.Model
{
    public class HealthModel : IHealthModel
    {
        private List<INotifyUpdateModel> _updateObservers;
        private int _health;

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                UpdateObservers();
            }
        }

        public HealthModel(HealthSetting setting)
        {
            _health = setting.Health;
            _updateObservers = new List<INotifyUpdateModel>();
        }

        public void AddModelUpdateObserver(INotifyUpdateModel observer)
        {
            _updateObservers.Add(observer);
        }

        private void UpdateObservers()
        {
            foreach (var observer in _updateObservers)
            {
                observer.NotifyUpdateModel();
            }
        }
    }
}