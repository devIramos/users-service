// <summary>
// <copyright file="UpdateUserRequestDto.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Common.DTOs.Requests.User
{
    /// <summary>
    /// Class UpdateUserRequestDto.
    /// </summary>
    public class UpdateUserRequestDto
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
    }
}
