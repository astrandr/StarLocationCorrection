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
            if(AngleHMS.TryParse(form.txtObjectPositionRA.Text, out AngleHMS ra) && AngleHMS.TryParse(form.txtObjectPositionDEC.Text, out AngleHMS dec))
            { 
                objectPosition = new Position { RA = ra, DEC = dec };
                return true;
            }
            else
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
            if (AngleHMS.TryParse(form.txtTelescopePositionRA.Text, out AngleHMS ra) && AngleHMS.TryParse(form.txtTelescopePositionDEC.Text, out AngleHMS dec))
            {
                telescopePosition = new Position { RA = ra, DEC = dec };
                return true;
            }
            else
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
            get
            {
                if (AngleHMS.TryParse(form.txtDeltaPositionRA.Text, out AngleHMS ra) && AngleHMS.TryParse(form.txtDeltaPositionDEC.Text, out AngleHMS dec))
                {
                    return new Position { RA = ra, DEC = dec };
                }
                else
                {
                    messageBox.ShowError("Invalid delta values. Please enter valid RA and DEC values with format 00:00:00");
                    return null;
                }
            }

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
