using System.Diagnostics.CodeAnalysis;
using Web.App.Database.Mapping;

namespace Web.App.Database
{
    public abstract class EntityWithIdBase : IEntityWithId, IEquatable<EntityWithIdBase?>
    {
        protected EntityWithIdBase()
        {
        }

        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as EntityWithIdBase);
        }

        public virtual bool Equals([AllowNull] EntityWithIdBase? other)
        {
            if (other is null)
            {
                return false;
            }
            return Id.Equals(other.Id);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}