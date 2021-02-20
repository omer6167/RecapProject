using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
        //IEnumerator GetEnumerator();
    }
    
}
