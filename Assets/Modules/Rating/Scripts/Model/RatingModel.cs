using System.Collections.Generic;
using Core;
using Rating.Setting;

namespace Rating.Model
{
    public class RatingModel : IRatingModel
    {
        private List<INotifyUpdateModel> _updateObservers;
        private int _rating;

        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
                UpdateObservers();
            }
        }

        public RatingModel(RatingSetting setting)
        {
            _rating = setting.Rating;
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