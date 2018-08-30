using System;

namespace SingUpSystem.Infrastructure.Utils
{
    /// <summary>
    /// Interface removes dependancy on dates
    /// </summary>
    public interface ITimeProvider
    {
        DateTime Today { get; }
        DateTime Now { get; }
    }


    class DefaultTimeProvider : ITimeProvider
    {
        public DateTime Today => DateTime.Today;
        public DateTime Now => DateTime.Now;
    }


    public static class DateTimeProvider
    {
        private static ITimeProvider _timeProvider = new DefaultTimeProvider();

        public static void SetTimeProvider(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public static DateTime Now => _timeProvider.Now;

        public static DateTime Today => _timeProvider.Today;

        public static DateTime Tomorrow => _timeProvider.Today.AddDays(1);

        internal static ITimeProvider CurrentTimeProvider => _timeProvider;
    }
}
