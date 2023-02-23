
namespace Enoca.Core.Base
{
    /// <summary>
    /// This class is used as base entity class for all entities with ability to track insert/update actions on the entity
    /// </summary>
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
