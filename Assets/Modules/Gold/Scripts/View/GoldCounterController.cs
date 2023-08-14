using UnityEngine;
using UnityEngine.UIElements;
using Core;
using Gold.Model;

namespace Gold.View
{
    public class GoldCounterController : MonoBehaviour, INotifyUpdateModel
    {
        private const string NAME = "Name";
        private const string VALUE = "Value";
        private const string GOLD = "Gold";

        [SerializeField]
        private UIDocument _view;
        private IGoldModel _model;
        private Label _value;

        void Start()
        {
            _model.AddModelUpdateObserver(this);
            var name = _view.rootVisualElement.Q<Label>(NAME);
            _value = _view.rootVisualElement.Q<Label>(VALUE);
            name.text = GOLD;
            NotifyUpdateModel();
        }

        public void SetModel(IGoldModel model)
        {
            _model = model;
        }

        public void NotifyUpdateModel()
        {
            _value.text = _model.Gold.ToString();
        }
    }
}
