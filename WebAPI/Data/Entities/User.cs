/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */

using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.Entities
{
    /// <summary>
    /// The User entity.
    /// </summary>
    public class User : IdentifiableEntity
    {
        /// <summary>
        /// Gets or sets the user handle.
        /// </summary>
        /// <value>
        /// The user handle.
        /// </value>
        [Required]
        public string Handle { get; set; }
    }
}
