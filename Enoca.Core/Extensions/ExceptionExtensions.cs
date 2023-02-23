using Enoca.Core.Exceptions;
using System;

namespace Enoca.Core.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Get excpetion message for FrameworkException type.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="resourcesService"></param>
        /// <returns>localized message if IsLocalized is true or Excpetion.Message value</returns>
        public static string GetMessage(this FrameworkException exception)
        {
            return exception.IsLocalized
                ? exception.ResourceKey : exception.Message;
        }

        /// <summary>
        /// Get excpetion message for BusinessLogicException type.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>localized message</returns>
        public static string GetMessage(this BusinessLogicException exception)
            => exception.ResourceKey;

    }
}
