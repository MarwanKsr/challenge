using Ardalis.GuardClauses;

namespace Enoca.Core.Common
{
    public class Resources
    {
        /// <summary>
        /// Resource Type that contain the resource record
        /// </summary>
        public Type ResourceType { get; private set; }

        /// <summary>
        /// Resource Key to retrive resource value in Resource Type
        /// </summary>
        public string ResourceKey { get; private set; }

        private Resources() { }
        private Resources(Type resourceType, string resourceKey)
        {
            ResourceType = Guard.Against.Null(resourceType, nameof(resourceType));
            ResourceKey = Guard.Against.NullOrEmpty(resourceKey, nameof(resourceKey)); ;
        }

        /// <summary>
        /// Create instance of Resources
        /// </summary>
        /// <typeparam name="TResourceType">Resource Type that contain the resource record</typeparam>
        /// <param name="resourceKey">Resource Key to retrive resource value in Resource Type</param>
        /// <returns></returns>
        public static Resources Get<TResourceType>(string resourceKey) where TResourceType : class
            => new(typeof(TResourceType), resourceKey);
    }
}
