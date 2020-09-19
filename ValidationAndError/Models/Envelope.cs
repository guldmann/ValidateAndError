using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationAndError.Models
{
    public class Envelope
    {
        public Envelope()
        {
            Errors = new List<Error>();
        }

        public int Status { get; set; }
        public string Request { get; set; }
        public string Path { get; set; }
        public string TraceId { get; set; }

        public Envelope(List<Error> errors)
        {
            Errors = errors;
        }

        public bool IsSuccess => !Errors.Any();

        public List<Error> Errors { get; set; }
    }

    public class Envelope<T> : Envelope
    {
        public Envelope(T payload)
        {
            Payload = payload;
        }

        public T Payload { get; set; }
    }
}