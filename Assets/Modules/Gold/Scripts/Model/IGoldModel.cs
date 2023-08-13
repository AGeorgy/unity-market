using Core;

namespace Gold.Model
{
    public interface IGoldModel
    {
        int Gold { get; set; }

        void AddModelUpdateObserver(INotifyUpdateModel observer);
    }
}