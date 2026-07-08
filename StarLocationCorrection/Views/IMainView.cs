using TelescopePosCorrection.Data;

namespace StarLocationCorrection.Views
{
    public interface IMainView
    {
        Position ObjectPosition { get; set; }
        Position TelescopePosition { get; set; }
        /// <summary>
        /// PositionCorrection - delta object position - telescope position
        /// </summary>
        Position PositionDelta { get; set; }

        void SetPositionDelta(AngleHMS deltaRA, AngleHMS deltaDEC);
    }
}
