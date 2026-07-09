using StarLocationCorrection.Presenters;
using StarLocationCorrection.UI;
using System.Windows.Forms;
using TelescopePosCorrection.Models;

namespace StarLocationCorrection
{
    public partial class MainForm : Form
    {
        private IMainPresenter mainPresenter;

        public MainForm()
        {
            InitializeComponent();
        }

        public void SetPresenter(IMainPresenter presenter)
        {
            this.mainPresenter = presenter;
        }

        private void btnCalibrate_Click(object sender, System.EventArgs e)
        {
            try
            {
                mainPresenter.CalculatePositionDelta();
            }
            catch 
            {
                MessageBox.Show("Cannot calculate the delta. Check the values for object and telescope position. Expected format:'HH:MM:SS.ss");
            }
        }

        private void btnCorrect_Click(object sender, System.EventArgs e)
        {
            try
            {
                mainPresenter.CorrectPosition();
            }
            catch
            {
                MessageBox.Show("Cannot calculate corrected telescope position. Check the values for object position. Expected format:'HH:MM:SS.ss");

            }
        }
    }
}
