using System;

namespace SingUpSystem.Infrastructure.Utils
{
    public static class HolyGuard
    {
        public static void ThrowExceptionIfStringIsNullOrEmpty(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Wrong argument.");
        }

        public static void ThrowExceptionIfObjectIsNull(object input)
        {
            if (input == null)
                throw new ArgumentException("Object is null.");
        }
    }
}
