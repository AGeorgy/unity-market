using UnityEngine;
using UnityEngine.UIElements;
using Core;
using Rating.Model;

namespace Rating.View
{
    public class RatingCounterController : MonoBehaviour, INotifyUpdateModel
    {
        private const string NAME = "Name";
        private const string VALUE = "Value";
        private const string RATING = "Rating";

        [SerializeField]
        private UIDocument _view;
        private IRatingModel _model;
        private Label _value;

        void Start()
        {
            _model.AddModelUpdateObserver(this);
            var name = _view.rootVisualElement.Q<Label>(NAME);
            _value = _view.rootVisualElement.Q<Label>(VALUE);
            name.text = RATING;
            NotifyUpdateModel();
        }

        public void Init(IRatingModel model)
        {
            _model = model;
        }

        public void NotifyUpdateModel()
        {
            _value.text = _model.Rating.ToString();
        }
    }
}
