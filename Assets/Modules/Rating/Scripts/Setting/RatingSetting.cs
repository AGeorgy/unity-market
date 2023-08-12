using UnityEngine;

namespace Rating.Setting
{
    [CreateAssetMenu(fileName = "RatingSetting", menuName = "Game/RatingSetting")]
    public class RatingSetting : ScriptableObject
    {
        [SerializeField]
        private int _rating;

        public int Rating => _rating;
    }
}
