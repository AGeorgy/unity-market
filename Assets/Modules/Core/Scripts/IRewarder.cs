namespace Core
{
    public interface IRewarder
    {
        void AddReward<T>(T reward) where T : IReward;
    }
}