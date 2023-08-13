using System.Collections.Generic;
using Core;
using Gold.Setting;

namespace Gold.Model
{
    public class GoldModel : IGoldModel
    {
        private List<INotifyUpdateModel> _updateObservers;
        private int _gold;

        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
                UpdateObservers();
            }
        }

        public GoldModel(GoldSetting setting)
        {
            _gold = setting.Gold;
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