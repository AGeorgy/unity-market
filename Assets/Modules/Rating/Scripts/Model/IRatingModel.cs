using Core;

namespace Rating.Model
{
    public interface IRatingModel
    {
        int Rating { get; set; }

        void AddModelUpdateObserver(INotifyUpdateModel observer);
    }
}