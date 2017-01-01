using System;
using System.Windows.Forms;

namespace Droid_scheduler
{
    public partial class GUI : Tools4Libraries.Window
    {
        #region Attribute
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public GUI()
        {
            InitializeComponent();
            Initialize();
        }
        #endregion

        #region Methods private
        private void Initialize()
        {

        }
        #endregion

        #region Event
        private void buttonRevert_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonPersoCalCancel_Click(object sender, EventArgs e)
        {
            tabControlScheduler.SelectedTab = tabPageSettings;
        }
        private void buttonPersoCalApply_Click(object sender, EventArgs e)
        {
            tabControlScheduler.SelectedTab = tabPageSettings;
        }
        #endregion
    }
}
