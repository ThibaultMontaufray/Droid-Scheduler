using System.Drawing;
using System.Windows.Forms;

namespace Droid.Scheduler.UI
{
    public class PanelScheduler : UserControl
    {
        #region Attribute
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public PanelScheduler()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods private
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PanelScheduler
            // 
            this.Name = "PanelScheduler";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.BackColor = Color.Black;
        }
        #endregion
    }
}
