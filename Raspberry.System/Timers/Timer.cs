#region References

using System.Threading;

#endregion

namespace Raspberry.Timers
{
    internal static class Timer
    {
        #region Methods

        /// <summary>
        /// Creates a timer.
        /// </summary>
        /// <returns>The timer.</returns>
        /// <remarks>
        /// The created timer is the most suitable for the current platform.
        /// </remarks>
        public static ITimer Create()
        {
            return Board.Current.IsRaspberryPi
                       ? (ITimer) new HighResolutionTimer()
                       : new StandardTimer();
        }

        /// <summary>
        /// Sleeps during the specified time.
        /// </summary>
        /// <param name="time">The time, in milliseconds.</param>
        public static void Sleep(decimal time)
        {
            if (time < 0)
                return;

            if (Board.Current.IsRaspberryPi)
                HighResolutionTimer.Sleep(time);
            else
                Thread.Sleep((int)time);
        }

        #endregion
    }
}