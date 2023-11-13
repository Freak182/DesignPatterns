using Microsoft.EntityFrameworkCore;

namespace Web.App.Database.Mapping.Common
{
    public interface IEntityMapping
    {
        void Map(ModelBuilder builder, bool isInMemory = false);
    }
}
