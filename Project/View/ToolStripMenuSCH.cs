using System;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_scheduler
{
    public class ToolStripMenuSCH : RibbonTab
    {
        #region Attributes
        public event EventHandlerAction ActionAppened;

        private RibbonPanel _panelMain;
        private RibbonButton _ts_main_home;
        private RibbonButton _ts_main_open;
        private RibbonButton _ts_main_new;
        
        private Interface_sheduler _intScheduler;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ToolStripMenuSCH(Interface_sheduler intScheduler)
        {
            _intScheduler = intScheduler;
            Init();
        }
        #endregion

        #region Methods public
        public void OnAction(EventArgs e)
        {
            if (ActionAppened != null) ActionAppened(this, e);
        }
        public void UpdateLanguage()
        {
            _ts_main_open.Text = GetText.Text(_ts_main_open.Name);
            _ts_main_new.Text = GetText.Text(_ts_main_new.Name);
            this.Text = GetText.Text("Scheduler");
            
            _panelMain.Text = GetText.Text(_panelMain.Name);
        }
        #endregion

        #region Methods private
        private void Init()
        {
            BuildPanelMain();
            this.Text = GetText.Text("Scheduler");
        }
        private void BuildPanelMain()
        {
            _ts_main_home = new RibbonButton();
            _ts_main_home.Name = "Home";
            _ts_main_home.Text = GetText.Text(_ts_main_home.Name);
            _ts_main_home.ToolTip = GetText.Text(_ts_main_home.Name);
            _ts_main_home.Click += new EventHandler(tsb_Click);
            _ts_main_home.Image = Tools4Libraries.Resources.ResourceIconSet32Default.open_folder;
            _ts_main_home.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.open_folder;
            _ts_main_home.MinSizeMode = RibbonElementSizeMode.Large;

            _ts_main_open = new RibbonButton();
            _ts_main_open.Name = "Open";
            _ts_main_open.Text = GetText.Text(_ts_main_open.Name);
            _ts_main_open.ToolTip = GetText.Text(_ts_main_open.Name);
            _ts_main_open.Click += new EventHandler(tsb_Click);
            _ts_main_open.Image = Tools4Libraries.Resources.ResourceIconSet32Default.open_folder;
            _ts_main_open.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.open_folder;
            _ts_main_open.MinSizeMode = RibbonElementSizeMode.Large;

            _ts_main_new = new RibbonButton();
            _ts_main_new.Name = "New";
            _ts_main_new.Text = GetText.Text(_ts_main_new.Name);
            _ts_main_new.ToolTip = GetText.Text(_ts_main_new.Name);
            _ts_main_new.Click += new EventHandler(tsb_Click);
            _ts_main_new.Image = Tools4Libraries.Resources.ResourceIconSet32Default.newProject32;
            _ts_main_new.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.newProject16;
            _ts_main_new.MinSizeMode = RibbonElementSizeMode.Large;
            
            _panelMain = new RibbonPanel();
            _panelMain.Image = Tools4Libraries.Resources.ResourceIconSet16Default.open;
            _panelMain.Name = "Main";
            _panelMain.Text = GetText.Text(_panelMain.Name);
            _panelMain.Items.Add(_ts_main_home);
            _panelMain.Items.Add(_ts_main_open);
            _panelMain.Items.Add(_ts_main_new);
            this.Panels.Add(_panelMain);
        }
        #endregion

        #region Event
        private void tsb_Click(object sender, EventArgs e)
        {
            if (sender is RibbonButton)
            { 
                RibbonButton rb = sender as RibbonButton;
                ToolBarEventArgs action = new ToolBarEventArgs(rb.Name);
                OnAction(action);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
