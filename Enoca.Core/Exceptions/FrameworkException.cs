

namespace Enoca.Core.Exceptions
{
    /// <summary>
    /// Use this exception type only to throw localized error globally in the solution
    /// The global exception handler will handle this exception and return
    /// Toaster model response with error details via MVC response
    /// or return failed ApiResponse model via web Api response
    /// </summary>
    public class FrameworkException : Exception
    {
        /// <summary>
        /// This flag determine how to get exception message.
        /// if false: get exception message from Exception.Message
        /// else retrive resource value in Resource Type by Resource Key
        /// </summary>
        public bool IsLocalized { get; private set; }

        /// <summary>
        /// Resource Type that contain the resource record
        /// </summary>
        public Type ResourceType { get; private set; }

        /// <summary>
        /// Resource Key to retrive resource value in Resource Type
        /// </summary>
        public string ResourceKey { get; private set; }

        private FrameworkException(string msg) : base(msg) { }
        private FrameworkException(Type resourceType, string resourceKey)
        {
            IsLocalized = true;
            ResourceType = resourceType;
            ResourceKey = resourceKey;
        }

        /// <summary>
        /// Create localized instance of FrameworkException
        /// </summary>
        /// <typeparam name="TResourceType">Resource Type that contain the resource record</typeparam>
        /// <param name="resourceKey">Resource Key to retrive resource value in Resource Type</param>
        /// <returns></returns>
        public static FrameworkException Create<TResourceType>(string resourceKey) where TResourceType : class
            => new(typeof(TResourceType), resourceKey);

        /// <summary>
        /// Create instance of FrameworkException
        /// </summary>
        /// <param name="message">Error message to set in Message property</param>
        /// <returns></returns>
        public static FrameworkException Create(string message)
            => new(message);
    }
}
