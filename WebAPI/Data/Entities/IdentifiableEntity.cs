/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */

namespace WebAPI.Data.Entities
{
    /// <summary>
    /// Represents the base class for all identifiable entities.
    /// </summary>
    public abstract class IdentifiableEntity
    {
        /// <summary>
        /// Gets or sets the entity Id.
        /// </summary>
        /// <value>
        /// The entity Id.
        /// </value>
        public int Id { get; set; }
    }
}
