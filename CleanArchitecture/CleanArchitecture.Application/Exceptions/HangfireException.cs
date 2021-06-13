using System;
using System.Globalization;

namespace CleanArchitecture.Application.Exceptions
{
    public class HangfireException : Exception
    {
        public HangfireException()
        {
        }

        public HangfireException(string message) : base(message)
        {
        }

        public HangfireException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
