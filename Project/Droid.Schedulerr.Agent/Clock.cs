using Droid.Scheduler.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Droid.Scheduler.Agent
{
    public static class Clock
    {
        private static Timer _timer;
        private static Timer _timerConfig;
        private static Queue<string> _queue;
        private static Dictionary<Box, DateTime> _boxes;

        static Clock()
        {
            Init();
        }

        #region Methods private
        private static void Init()
        {
            _queue = new Queue<string>();
            _boxes = new Dictionary<Box, DateTime>();

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;

            _timerConfig = new Timer();
            _timerConfig.Interval = 1000 * 60 * 5; // 5Min
            _timerConfig.Elapsed += _timerConfig_Elapsed;
        }
        private static async void Process()
        {
            Console.WriteLine(" -> heart beat " + DateTime.Now);
            

            while(_queue.Count > 0 && _queue.Peek() != null)
            {
                await RunActionAsync(_queue.Dequeue());
            }

            // TODO : delete the object boxes
            // see in database the table (create it) nextlaunches
            // poderation of the agent + raz if the priority one
            // if highest run the one he select
            // or not, this all can be really inefficient
        }
        private static void LoadConfig()
        {
            List<Box> lstBox = Box.LoadAllTask();
            Dictionary<Box, DateTime> finalBow = new Dictionary<Box, DateTime>();
            foreach (var box in lstBox)
            {
                finalBow.Add(box, box.GetNextExecution(DateTime.Now));
            }

            _timer.Stop();
            _boxes.Clear();
            _boxes = finalBow;
            _timer.Start();

            //_queue.Enqueue("Program-" + DateTime.Now.Ticks);
        }
        private static async Task<int> RunActionAsync(string actionId)
        {
            var t = Task.Run(() => RunAction(actionId));
            return await t;
        }
        private static int RunAction(string actionId)
        {
            Console.WriteLine(" ### Run job  " + actionId + " ###");

            LaunchDemo(actionId);

            Console.WriteLine(" ### End job  " + actionId + " ###");
            return 0;
        }
        private static void LaunchDemo(string batchName)
        {
            Random r = new Random();
            System.Threading.Thread.Sleep(r.Next(1000, 10000));
        }
        private static void LaunchBatch(string batchName)
        {
            Box box = Box.Load(batchName);
            Job job = new Job(box);

            System.Threading.Thread thread = new System.Threading.Thread(job.Execute);
            thread.Start();
        }
        #endregion

        #region Methods public
        public static void Start()
        {
            _timerConfig.Start();
            _timer.Start();
        }
        public static void Stop()
        {
            _timer.Stop();
        }
        #endregion

        #region Event
        private static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Process();
        }
        private static void _timerConfig_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timerConfig.Stop();
            try
            {
                LoadConfig();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error while loading the configuration : " + exp.Message);
            }
            _timerConfig.Start();
        }
        #endregion
    }
}
