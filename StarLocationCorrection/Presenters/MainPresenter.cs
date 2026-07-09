using StarLocationCorrection.Views;
using TelescopePosCorrection.Data;
using TelescopePosCorrection.Models;
using TelescopePosCorrection.Services;

namespace StarLocationCorrection.Presenters
{
    public class MainPresenter : IMainPresenter
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
            if (mainView.TryGetObjectPosition(out Position objectPosition) && mainView.TryGetTelescopePosition(out Position telescopePosition))
            {
                model.PositionDeltaRA = CorrectionUtils.GetDelta(telescopePosition.RA, objectPosition.RA);
                model.PositionDeltaDEC = CorrectionUtils.GetDelta(telescopePosition.DEC, objectPosition.DEC);

                mainView.SetPositionDelta(AngleHMS.FromFloat(model.PositionDeltaRA), AngleHMS.FromFloat(model.PositionDeltaDEC));
            }
        }

        public void CorrectPosition()
        {
            if (mainView.TryGetObjectPosition(out Position objectPosition))
            {
                var correctedRA = CorrectionUtils.AddDeltaRA(objectPosition.RA, model.PositionDeltaRA);
                var correctedDEC = CorrectionUtils.AddDeltaDEC(objectPosition.DEC, model.PositionDeltaDEC);

                mainView.SetTelescopePosition(new Position() { RA = correctedRA, DEC = correctedDEC });
            }
        }
    }
}
