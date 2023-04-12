// <summary>
// <copyright file="SampleNotification.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Common.Notifications.Module
{
    /// <summary>
    /// Class ExapleNotification.
    /// </summary>
    public class SampleNotification : INotification
    {
        /// <summary>
        /// Gets or sets or set Id.
        /// </summary>
        /// <value>
        /// Int Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets or set Name.
        /// </summary>
        /// <value>
        /// String Name.
        /// </value>
        public string Name { get; set; }
    }
}
