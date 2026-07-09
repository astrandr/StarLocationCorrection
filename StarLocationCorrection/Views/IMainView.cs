using TelescopePosCorrection.Data;

namespace StarLocationCorrection.Views
{
    public interface IMainView
    {
        bool TryGetObjectPosition(out Position objectPosition);

        void SetObjectPosition(Position objectPosition);

        bool TryGetTelescopePosition(out Position telescopePosition);

        void SetTelescopePosition(Position telescopePosition);

        Position PositionDelta { get; set; }

        void SetPositionDelta(AngleHMS deltaRA, AngleHMS deltaDEC);
    }
}
