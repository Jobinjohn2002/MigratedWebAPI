using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// IntegrationModel
    /// </summary>
    public class IntegrationModel
    {
        /// <summary>
        /// Gets or sets Application
        /// </summary>
        public string Application { get; set; }
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Gets or sets EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets Firstname
        /// </summary>
        public string Firstname { get; set; }
        /// <summary>
        /// Gets or sets SecurityValue
        /// </summary>
        public string SecurityValue { get; set; }
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets OwnerApplication
        /// </summary>
        public string OwnerApplication { get; set; }

        /// <summary>
        /// Gets or sets Permissions
        /// </summary>
        public IntegrationPermissions Permissions { get; set; } = new IntegrationPermissions();

        /// <summary>
        /// Gets or sets Checksum
        /// </summary>
        public string Checksum { get; set; }

        /// <summary>
        /// Hmac operation
        /// </summary>
        public void Hmac(string secret, TimeSpan timespan)
        {
            var json = Json();

            Checksum = Steris.Core.Security.Hmac.Encode(json, timespan, secret);
        }

        /// <summary>
        /// Json operation
        /// </summary>
        public string Json()
        {
            var checksum = Checksum;

            Checksum = null;

            var json = JsonConvert.SerializeObject(this);

            Checksum = checksum;

            return json;
        }
    }
}
