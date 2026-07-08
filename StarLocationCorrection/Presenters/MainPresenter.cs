using StarLocationCorrection.Views;
using TelescopePosCorrection.Data;
using TelescopePosCorrection.Models;
using TelescopePosCorrection.Services;

namespace StarLocationCorrection.Presenters
{
    public class MainPresenter
    {
        private readonly TelescopePositionCorrectionModel model;
        private readonly IMainView mainView;

        public MainPresenter(TelescopePositionCorrectionModel model, IMainView mainView)
        {
            this.model = model;
            this.mainView = mainView;
        }

        public void CalculatePositionDelta()
        {
            model.PositionDeltaRA = CorrectionUtils.GetDelta(mainView.TelescopePosition.RA, mainView.ObjectPosition.RA);
            model.PositionDeltaDEC = CorrectionUtils.GetDelta(mainView.TelescopePosition.DEC, mainView.ObjectPosition.DEC);

            mainView.SetPositionDelta(AngleHMS.FromFloat(model.PositionDeltaRA), AngleHMS.FromFloat(model.PositionDeltaDEC));
        }

        public void CorrectPosition()
        {
            var correctedRA = CorrectionUtils.AddDeltaRA(mainView.ObjectPosition.RA, model.PositionDeltaRA);
            var correctedDEC = CorrectionUtils.AddDeltaDEC(mainView.ObjectPosition.DEC, model.PositionDeltaDEC);

            mainView.TelescopePosition = new Position() { RA = correctedRA, DEC = correctedDEC };
        }
    }
}
