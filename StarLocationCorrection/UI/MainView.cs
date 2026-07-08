using TelescopePosCorrection.Data;
using StarLocationCorrection.Views;

namespace StarLocationCorrection.UI
{
    public class MainView : IMainView
    {
        private readonly MainForm form;

        public MainView(MainForm form)
        {
            this.form = form;
        }

        public Position ObjectPosition
        {
            get => new Position
            {
                RA = AngleHMS.FromString(form.txtObjectPositionRA.Text),
                DEC = AngleHMS.FromString(form.txtObjectPositionDEC.Text)
            };
            set
            {
                form.txtTelescopePositionRA.Text = value.RA.ToHMSString();
                form.txtTelescopePositionDEC.Text = value.DEC.ToHMSString();
            }
        }

        public Position TelescopePosition
        {
            get => new Position
            {
                RA = AngleHMS.FromString(form.txtTelescopePositionRA.Text),
                DEC = AngleHMS.FromString(form.txtTelescopePositionDEC.Text)
            };
            set
            {
                form.txtTelescopePositionRA.Text = value.RA.ToHMSString();
                form.txtTelescopePositionDEC.Text = value.DEC.ToHMSString();
            }
        }

        public Position PositionDelta
        {
            get => new Position
            {
                RA = AngleHMS.FromString(form.txtDeltaPositionRA.Text),
                DEC = AngleHMS.FromString(form.txtDeltaPositionDEC.Text)
            };
            set
            {
                form.txtDeltaPositionRA.Text = value.RA.ToHMSString();
                form.txtDeltaPositionDEC.Text = value.DEC.ToHMSString();
            }
        }

        public void SetPositionDelta(AngleHMS deltaRA, AngleHMS deltaDEC)
        {
            form.txtDeltaPositionRA.Text = deltaRA.ToHMSString();
            form.txtDeltaPositionDEC.Text = deltaDEC.ToHMSString();
        }
    }
}
