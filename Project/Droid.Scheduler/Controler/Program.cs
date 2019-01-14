namespace Droid.Scheduler
{
    using System;
    using System.ServiceProcess;

    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GUI());

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new TS_Scheduler(args)
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
