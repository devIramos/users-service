// <summary>
// <copyright file="CreateUserRequestDto.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Common.DTOs.Requests.User
{
    /// <summary>
    /// Class CreateUserRequestDto.
    /// </summary>
    public class CreateUserRequestDto
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>
        /// String Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets UserName.
        /// </summary>
        /// <value>
        /// String UserName.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        /// <value>
        /// String Email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Roles.
        /// </summary>
        /// <value>
        /// <see cref="List{CreateRoleDto}"/> Roles.
        /// </value>
        public List<CreateRoleRequestDto> Roles { get; set; }
    }
}
