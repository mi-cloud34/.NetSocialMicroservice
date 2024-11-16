using System;
using System.Collections.Generic;
using System.Text;

namespace Follow.Core.Utilities.Results
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}