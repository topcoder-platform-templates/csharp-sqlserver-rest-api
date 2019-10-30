/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Repositories
{
    /// <summary>
    /// The user repository interface.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Creates the given user.
        /// </summary>
        /// <param name="entity">The user entity.</param>
        /// <returns>Created user entity.</returns>
        User Create(User entity);

        /// <summary>
        /// Deletes user with given Id.
        /// </summary>
        /// <param name="id">The user Id.</param>
        void Delete(int id);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>All users.</returns>
        IList<User> GetAll();

        /// <summary>
        /// Gets the User by handle.
        /// </summary>
        /// <param name="handle">The user handle.</param>
        /// <returns>Found user or null.</returns>
        User GetByHandle(string handle);

        /// <summary>
        /// Gets the User by Id.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <returns>Found user or null.</returns>
        User GetById(int id);

        /// <summary>
        /// Updates given user.
        /// </summary>
        /// <param name="entity">The user entity.</param>
        void Update(User entity);
    }
}
