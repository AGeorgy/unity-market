using Rating.Setting;

namespace Rating.Model
{
    public class RatingModel : IRatingModel
    {
        public int Rating { get; set; }

        public RatingModel(RatingSetting setting)
        {
            Rating = setting.Rating;
        }
    }
}