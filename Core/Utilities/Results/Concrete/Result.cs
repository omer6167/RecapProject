using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Messages { get; }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success,string messages) : this(success)
        {
            Messages = messages;
        }
    }
}
