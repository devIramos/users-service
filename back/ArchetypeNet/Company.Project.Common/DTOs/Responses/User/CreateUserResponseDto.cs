// <summary>
// <copyright file="CreateUserResponseDto.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Common.DTOs.Responses.User
{
    /// <summary>
    /// Class CreateUserResponseDto.
    /// </summary>
    public class CreateUserResponseDto
    {
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
        /// <see cref="List{CreateRoleResponseDto}"/> Roles.
        /// </value>
        public List<CreateRoleResponseDto> Roles { get; set; }
    }
}
