using System;

namespace Ioasys.Domain.Shared.Exceptions
{
    public class CoreException : Exception
    {
        public new readonly string Message;

        public CoreException(string message)
        {
            Message = message;
        }
    }
}
