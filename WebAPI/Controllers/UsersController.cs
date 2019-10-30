/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;
using WebAPI.Data.Entities;
using WebAPI.Data.Repositories;
using WebAPI.Exceptions;

namespace WebAPI.Controllers
{
    /// <summary>
    /// This controller exposes API for managing users.
    /// </summary>
    public class UsersController : BaseController
    {
        /// <summary>
        /// The users repository.
        /// </summary>
        private readonly IUserRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="repository">The User repository.</param>
        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all User items.
        /// </summary>
        /// <returns>All User items.</returns>
        [HttpGet("")]
        public IList<User> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Creates the specified User item.
        /// </summary>
        /// <param name="model">The User model.</param>
        /// <returns>The Id of created item.</returns>
        [HttpPost("")]
        public int Create(User model)
        {
            ValidateModel(model);
            var existing = _repository.GetByHandle(model.Handle);
            if (existing != null)
            {
                throw new ArgumentException($"User with handle '{model.Handle}' already exists.");
            }

            return _repository.Create(model).Id;
        }

        /// <summary>
        /// Updates the User item.
        /// </summary>
        /// <param name="id">The Id of the User to update.</param>
        /// <param name="model">The User model with updated data.</param>
        [HttpPut("{id}")]
        public void Update(int id, User model)
        {
            Util.ValidateArgumentPositive(id, nameof(id));
            EnsureUserExists(id);

            ValidateModel(model);
            var existing = _repository.GetByHandle(model.Handle);
            if (existing != null)
            {
                if (existing.Id != id)
                {
                    throw new ArgumentException($"User with handle '{model.Handle}' already exists.");
                }
                else
                {
                    // nothing to update
                    return;
                }
            }

            model.Id = id;
            _repository.Update(model);
        }

        /// <summary>
        /// Deletes User with the given Id.
        /// </summary>
        /// <param name="id">The Id of the User to delete.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EnsureUserExists(id);
            _repository.Delete(id);
        }

        /// <summary>
        /// Ensures that the user exists.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        private void EnsureUserExists(int userId)
        {
            var existing = _repository.GetById(userId);
            if (existing == null)
            {
                throw new EntityNotFoundException($"User with id '{userId}' doesn't exist.");
            }
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        private static void ValidateModel(User model)
        {
            Util.ValidateArgumentNotNull(model, nameof(model));
            Util.ValidateArgumentNotNullOrEmpty(model.Handle, nameof(model.Handle));
        }
    }
}
