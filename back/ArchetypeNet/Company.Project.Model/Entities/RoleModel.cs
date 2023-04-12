// <summary>
// <copyright file="RoleModel.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>
namespace Company.Project.Model.Entities
{
    /// <summary>
    /// RoleModel class.
    /// </summary>
    public class RoleModel : SignedModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleModel"/> class.
        /// </summary>
        public RoleModel()
        {
            this.Users = new HashSet<UserModel>();
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        /// <value>
        /// Int Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>
        /// String Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Users.
        /// </summary>
        /// <value>
        /// <see cref="ICollection{UserModel}"/> Users.
        /// </value>
        public virtual ICollection<UserModel> Users { get; set; }
    }
}
