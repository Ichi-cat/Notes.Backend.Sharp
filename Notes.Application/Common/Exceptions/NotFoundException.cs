using System;

namespace Notes.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string key, object value)
            : base($"Object {key} - {value} is not found")
        {

        }
    }
}
