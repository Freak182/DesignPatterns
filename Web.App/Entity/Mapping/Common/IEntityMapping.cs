using Microsoft.EntityFrameworkCore;

namespace Web.App.Entity.Mapping.Common
{
    public interface IEntityMapping
    {
        void Map(ModelBuilder builder, bool isInMemory = false);
    }
}
