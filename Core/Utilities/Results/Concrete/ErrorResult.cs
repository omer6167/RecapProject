using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(success:false)
        {
        }

        public ErrorResult( string messages) : base(success:false, messages)
        {
        }
    }
}
