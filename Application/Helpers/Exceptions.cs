using System;
using System.Collections.Generic;

namespace Application.Helpers
{
    public class NotFoundException : Exception
    {
        public string Entity { get; set; }

        public NotFoundException(string entity, string message) : base(message)
        {
            Entity = entity;
        }
    }

    public class UnprocessableEntityException : Exception
    {

        public UnprocessableEntityException(IEnumerable<string> messages) : base(string.Join(", ", messages))
        {
            Errors.Add(string.Empty, messages);
        }

        public UnprocessableEntityException(string name, IEnumerable<string> messages) : base(string.Join(", ", messages))
        {
            Errors.Add(name, messages);
        }

        public UnprocessableEntityException(Dictionary<string, IEnumerable<string>> errors) : base(string.Join(", ", errors.Values))
        {

            foreach (var error in errors)
            {
                errors.TryAdd(error.Key, error.Value);
            }
        }

        public Dictionary<string, IEnumerable<string>> Errors { get; } = new Dictionary<string, IEnumerable<string>>();
    }

    public class PreconditionFailedException : Exception
    {

        public string Code { get; set; }

        public PreconditionFailedException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}
