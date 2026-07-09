namespace StarLocationCorrection.Presenters
{
    public interface IMainPresenter
    {
        void CalculatePositionDelta();
        void CorrectPosition();
    }
}