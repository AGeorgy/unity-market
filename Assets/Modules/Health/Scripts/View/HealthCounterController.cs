using UnityEngine;
using UnityEngine.UIElements;
using Core;
using Health.Model;

namespace Health.View
{
    public class HealthCounterController : MonoBehaviour, INotifyUpdateModel
    {
        private const string NAME = "Name";
        private const string VALUE = "Value";
        private const string HEALTH = "Health";

        [SerializeField]
        private UIDocument _view;
        private IHealthModel _model;
        private Label _value;

        void Start()
        {
            _model.AddModelUpdateObserver(this);
            var name = _view.rootVisualElement.Q<Label>(NAME);
            _value = _view.rootVisualElement.Q<Label>(VALUE);
            name.text = HEALTH;
            NotifyUpdateModel();
        }

        public void SetModel(IHealthModel model)
        {
            _model = model;
        }

        public void NotifyUpdateModel()
        {
            _value.text = _model.Health.ToString();
        }
    }
}
