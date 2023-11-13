﻿namespace Web.App.Entity.Common
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
