// <summary>
// <copyright file="BaseTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Test
{
    /// <summary>
    /// Class Base Test.
    /// </summary>
    public abstract class BaseTest
    {
        /// <summary>
        /// List of ProjectModel.
        /// </summary>
        /// <returns>A <see cref="TResult"/> representing the result of the operation.</returns>
        public static IEnumerable<UserModel> GetAllProjectModel()
        {
            return new List<UserModel>()
            {
                new UserModel { Id = 1, Name = "Usuario Uno", Username = "user1", Email = "user1@yopmail.com", Created = DateTime.Now, Modified = DateTime.Now, UserModified = "system", UserCreated = "system", Active = true },
                new UserModel { Id = 2, Name = "Usuario Dos", Username = "user2", Email = "user2@yopmail.com", Created = DateTime.Now, Modified = DateTime.Now, UserModified = "system", UserCreated = "system", Active = true },
                new UserModel { Id = 3, Name = "Usuario Tres", Username = "user3", Email = "user3@yopmail.com", Created = DateTime.Now, Modified = DateTime.Now, UserModified = "system", UserCreated = "system", Active = true },
                new UserModel { Id = 4, Name = "Usuario Cuatro", Username = "user4", Email = "user4@yopmail.com", Created = DateTime.Now, Modified = DateTime.Now, UserModified = "system", UserCreated = "system", Active = true },
                new UserModel { Id = 5, Name = "Usuario Cinco", Username = "user5", Email = "user5@yopmail.com", Created = DateTime.Now, Modified = DateTime.Now, UserModified = "system", UserCreated = "system", Active = true },
                new UserModel { Id = 6, Name = "Usuario Seis", Username = "user6", Email = "user6@yopmail.com", Created = DateTime.Now, Modified = DateTime.Now, UserModified = "system", UserCreated = "system", Active = true },
                new UserModel { Id = 7, Name = "Usuario Siete", Username = "user7", Email = "user7@yopmail.com", Created = DateTime.Now, Modified = DateTime.Now, UserModified = "system", UserCreated = "system", Active = true },
                new UserModel { Id = 8, Name = "Usuario Ochp", Username = "user8", Email = "user8@yopmail.com", Created = DateTime.Now, Modified = DateTime.Now, UserModified = "system", UserCreated = "system", Active = true },
                new UserModel { Id = 9, Name = "Usuario Nuevo", Username = "user9", Email = "user9@yopmail.com", Created = DateTime.Now, Modified = DateTime.Now, UserModified = "system", UserCreated = "system", Active = true },
            };
        }
    }
}
