using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.Common
{
    // <summary>
    /// Use this class to wrap all web APIs results
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        public const string GENERAL_KEY = "general";

        /// <summary>
        /// Data response.
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Check if an exception occurred.
        /// </summary>
        public bool Status => !Errors.Any();

        /// <summary>
        /// Return list of errors if exists.
        /// </summary>
        public Dictionary<string, string> Errors { get; private set; }

        /// <summary>
        /// Request Id
        /// </summary>
        public string RequestId => Guid.NewGuid().ToString("D");

        /// <summary>
        /// Time Stamp
        /// </summary>
        public DateTime TimeStamp => DateTime.UtcNow;

        private ApiResponse()
        {
            Errors = new Dictionary<string, string>();
        }

        private ApiResponse(T data) : this()
        {
            Data = data;
        }

        private ApiResponse(Dictionary<string, string> errors) : this()
        {
            Errors = errors ?? new();
        }

        /// <summary>
        /// Create Response Object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApiResponse<T> Create(T data)
            => new(data);

        /// <summary>
        /// Create Failure object with single error message and general key
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ApiResponse<T> Failure(string msg)
            => new(new Dictionary<string, string>() { { GENERAL_KEY, msg } });

        /// <summary>
        /// Create Failure object with single error message and key
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ApiResponse<T> Failure(string key, string msg)
            => new(new Dictionary<string, string>() { { key, msg } });

        /// <summary>
        /// Create Failure object with list of keys and error messages
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ApiResponse<T> Failure(Dictionary<string, string> msg)
            => new(msg);
    }
}
