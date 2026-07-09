using TelescopePosCorrection.Data;
using StarLocationCorrection.Views;

namespace StarLocationCorrection.UI
{
    public class MainView : IMainView
    {
        private readonly MainForm form;
        private readonly IMessageBox messageBox;

        public MainView(MainForm form, IMessageBox messageBox)
        {
            this.form = form;
            this.messageBox = messageBox;
        }

        public bool TryGetObjectPosition(out Position objectPosition)
        {
            AngleHMS RA, DEC;

            try
            {
                RA = AngleHMS.FromString(form.txtObjectPositionRA.Text);
                DEC = AngleHMS.FromString(form.txtObjectPositionDEC.Text);
                objectPosition = new Position { RA = RA, DEC = DEC };
                return true;
            }
            catch
            {
                messageBox.ShowError("Invalid object position. Please enter valid RA and DEC values with format 00:00:00");
                objectPosition = null;
                return false;
            }
        }

        public void SetObjectPosition(Position objectPosition)
        {
            form.txtObjectPositionRA.Text = objectPosition.RA.ToHMSString();
            form.txtObjectPositionDEC.Text = objectPosition.DEC.ToHMSString();
        }

        public bool TryGetTelescopePosition(out Position telescopePosition)
        {
            AngleHMS RA, DEC;

            try
            {
                RA = AngleHMS.FromString(form.txtTelescopePositionRA.Text);
                DEC = AngleHMS.FromString(form.txtTelescopePositionDEC.Text);
                telescopePosition = new Position { RA = RA, DEC = DEC };
                return true;
            }
            catch
            {
                messageBox.ShowError("Invalid telescope position. Please enter valid RA and DEC values with format 00:00:00");
                telescopePosition = null;
                return false;
            }
        }

        public void SetTelescopePosition(Position telescopePosition)
        {
            form.txtTelescopePositionRA.Text = telescopePosition.RA.ToHMSString();
            form.txtTelescopePositionDEC.Text = telescopePosition.DEC.ToHMSString();
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
