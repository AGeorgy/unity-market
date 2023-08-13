using Core;

namespace Health.Model
{
    public interface IHealthModel
    {
        int Health { get; set; }

        void AddModelUpdateObserver(INotifyUpdateModel observer);
    }
}