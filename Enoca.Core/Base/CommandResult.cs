using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.Base
{
    /// <summary>
    /// This class is used as easy way to retrive commands successability results without return results
    /// </summary>
    /// <param name="IsSuccess"></param>
    /// <param name="ErrorMessage"></param>
    public record CommandResult(bool IsSuccess = true, string ErrorMessage = "");

    /// <summary>
    /// This class is used as easy way to retrive commands successability results with return results
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Result">Result</param>
    /// <param name="IsSuccess">IsSuccess</param>
    /// <param name="ErrorMessage">ErrorMessage</param>
    public record CommandResult<T>(T Result, bool IsSuccess = true, string ErrorMessage = "") : CommandResult(IsSuccess, ErrorMessage);
}
