using Ardalis.GuardClauses;

namespace Enoca.Core.Exceptions
{
    public class BusinessLogicException : Exception
    {
        /// <summary>
        /// Resource Type that contain the resource record
        /// </summary>
        public Type ResourceType { get; private set; }

        /// <summary>
        /// Resource Key to retrive resource value in Resource Type
        /// </summary>
        public string ResourceKey { get; private set; }

        private BusinessLogicException() { }
        private BusinessLogicException(string resourceKey)
        {
            ResourceKey = Guard.Against.NullOrEmpty(resourceKey, nameof(resourceKey)); ;
        }

        /// <summary>
        /// Create instance of BusinessLogicException
        /// </summary>
        /// <typeparam name="TResourceType">Resource Type that contain the resource record</typeparam>
        /// <param name="resourceKey">Resource Key to retrive resource value in Resource Type</param>
        /// <returns></returns>
        public static BusinessLogicException Create(string resourceKey)
            => new(resourceKey);
    }
}
