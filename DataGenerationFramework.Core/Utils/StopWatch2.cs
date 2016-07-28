using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace DataGenerationFramework.Core
{
    /// <summary>
    /// Extension too the stopwatch class
    /// </summary>
    public class StopWatch2 : Stopwatch

    {
        private List<StopWatchLog> _logs;
        private StopWatchLog _average;
        private StopWatchLog _minimum;
        private StopWatchLog _maximum;

        /// <summary>
        /// How accurate is the timer in nanoseconds
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <returns>Timer is accurate within n nanoseconds</returns>
        public long Accuracy
        {
            get
            {
                long frequency = Frequency;
                long retval = (1000L * 1000L * 1000L) / frequency;
                return retval;
            }
        }

        /// <summary>
        /// Get  basic properties of the timer.
        /// </summary>
        /// <returns></returns>
        public string DisplayTimerProperties()
        {

            // Display the timer frequency and resolution. 
            var sb = new StringBuilder();
            sb.AppendLine(IsHighResolution
                ? "Operations timed using the system's high-resolution performance counter.\r\n"
                : "Operations timed using the DateTime class.\r\n");

            long frequency = Frequency;
            sb.AppendFormat("  Timer frequency in ticks per second = {0}\r\n", frequency);

            //long nanosecPerTick = (1000L*1000L*1000L) / frequency;
            sb.AppendFormat("  Timer is accurate within {0} nanoseconds\r\n", Accuracy);

            return sb.ToString();
        }

        /// <summary>
        /// Adds the current elapsed time to the log.
        /// </summary>
        public void RestartAndLog()
        {
            if (!base.IsRunning) throw new ApplicationException("Stop watch must be started.");
            base.Stop();
            _average = new StopWatchLog();
            _minimum = new StopWatchLog();
            _maximum = new StopWatchLog();

            var log = new StopWatchLog();
            log.Accuracy = Accuracy;
            log.Ticks = base.ElapsedTicks;
            log.MilliSeconds = base.ElapsedMilliseconds;

            if (_logs == null) _logs = new List<StopWatchLog>();
            _logs.Add(log);
            Console.WriteLine(string.Format("Loop {0} Acc {1}\t ms{2}\t Ticks {3}",
                                            _logs.Count,
                                            log.Accuracy,
                                            log.MilliSeconds,
                                            log.Ticks));

            base.Restart();

        }

        public struct StopWatchLog
        {
            /// <summary>
            /// The number of TicksElapsed
            /// </summary>
            public long Ticks { get; internal set; }
            /// <summary>
            /// How accurate is the timer in nanoseconds.
            /// </summary>
            public long Accuracy { get; internal set; }
            /// <summary>
            /// Elapsed time in milliseconds
            /// </summary>
            public long MilliSeconds { get; internal set; }

            public override string ToString()
            {
                return string.Format("Acc {0}\t ms{1} \t Ticks {2}", Accuracy, MilliSeconds, Ticks);
            }
        }

        /// <summary>
        /// Get the average exercution times
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <returns></returns>
        public StopWatchLog Average
        {
            get
            {
                if (base.IsRunning) return new StopWatchLog();
                if (_logs.Any() && _average.Ticks == 0)
                {
                    _average = new StopWatchLog()
                    {
                        Accuracy = Convert.ToInt64(_logs.Average(a => a.Accuracy)),
                        MilliSeconds = Convert.ToInt64(_logs.Average(b => b.MilliSeconds)),
                        Ticks = Convert.ToInt64(_logs.Average(b => b.Ticks))
                    };

                }
                return _average;
            }
        }

        /// <summary>
        /// Get the maximum exercution times 
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <returns></returns>
        public StopWatchLog Maximum
        {
            get
            {
                if (base.IsRunning) return new StopWatchLog();
                if (_logs.Any() && _maximum.Ticks == 0)
                {
                    _maximum = new StopWatchLog()
                    {
                        Accuracy = Convert.ToInt64(_logs.Max(a => a.Accuracy)),
                        MilliSeconds = Convert.ToInt64(_logs.Max(b => b.MilliSeconds)),
                        Ticks = Convert.ToInt64(_logs.Max(b => b.Ticks))
                    };

                }
                return _maximum;
            }
        }

        /// <summary>
        /// Get the Minimum exercution times 
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <returns></returns>
        public StopWatchLog Minimum
        {
            get
            {
                if (base.IsRunning) return new StopWatchLog();
                if (_logs.Any() && _minimum.Ticks == 0)
                {
                    _minimum = new StopWatchLog()
                    {
                        Accuracy = Convert.ToInt64(_logs.Min(a => a.Accuracy)),
                        MilliSeconds = Convert.ToInt64(_logs.Min(b => b.MilliSeconds)),
                        Ticks = Convert.ToInt64(_logs.Min(b => b.Ticks))
                    };

                }
                return _minimum;
            }
        }

    }
}
