namespace Web.App.Database.Mapping.Common
{
    /// <summary>
    /// Base entity with Id 
    /// </summary>
    public interface IEntityWithId
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }
    }
}
