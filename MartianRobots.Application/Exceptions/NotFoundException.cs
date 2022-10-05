using System;

namespace MartianRobots.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string type, int id)
            : base($"Unable to find {type} with id {id}")
        {
        }
    }
}
