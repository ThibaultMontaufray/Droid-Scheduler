namespace Droid.Scheduler
{
    using System;
    using System.ComponentModel;
    using Tools.Utilities;

    /// <summary>
    /// Interface for Tobi Assistant application : take care, some french word here to allow Tobi to speak with natural langage.
    /// </summary>            
    public class InterfaceSheduler : GPInterface
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public InterfaceSheduler()
        {
            Init();
        }
        #endregion

        #region Methods public
        public override void GoAction(string action)
        {
            switch (action)
            {
                case "Home":
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
        }
        #endregion

        #region Event
        #endregion
    }
}
