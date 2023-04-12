// <summary>
// <copyright file="UserModel.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>
namespace Company.Project.Model.Entities
{
    /// <summary>
    /// Class ProjectModel.
    /// </summary>
    public class UserModel : SignedModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserModel"/> class.
        /// </summary>
        public UserModel()
        {
            this.Roles = new HashSet<RoleModel>();
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
        /// Gets or sets Username.
        /// </summary>
        /// <value>
        /// String Username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        /// <value>
        /// String Email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets UserRoles.
        /// </summary>
        /// <value>
        /// <see cref="ICollection{RoleModel}"/> Roles.
        /// </value>
        public virtual ICollection<RoleModel> Roles { get; set; }
    }
}
