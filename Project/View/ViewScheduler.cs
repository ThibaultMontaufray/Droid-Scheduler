using System;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.scheduler
{
    public partial class ViewScheduler : UserControlCustom
    {
        #region Attribute
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewScheduler()
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
