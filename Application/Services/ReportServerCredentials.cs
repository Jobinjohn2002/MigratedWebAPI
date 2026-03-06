using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ReportServerCredentials
    /// </summary>
    public class ReportServerCredentials
    {
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets DomainName
        /// </summary>
        public string DomainName { get; set; }

        public string DomainAndUsername
        {
            get
            {
                if (Username == null)
                {
                    return null;
                }
                else if (string.IsNullOrEmpty(DomainName))
                {
                    return Username;
                }
                else
                {
                    return DomainName + '\\' + Username;
                }
            }
            set
            {
                if (value == null)
                {
                    DomainName = null;
                    Username = null;
                }
                else
                {
                    var parts = value.Split('\\');
                    if (parts.Length == 1)
                    {
                        DomainName = null;
                        Username = value;
                    }
                    else if (parts.Length == 2)
                    {
                        DomainName = parts[0];
                        Username = parts[1];
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }
                }
            }
        }

        public ReportServerCredentials(string userNameIncludingDomain, string password)
        {
            DomainAndUsername = userNameIncludingDomain;
            Password = password;
        }

        public ReportServerCredentials(string userName, string passWord, string domainName)
        {
            Username = userName;
            Password = passWord;
            DomainName = domainName;
        }

        #region IReportServerCredentials implementation

        /// <summary>
        /// GetFormsCredentials operation
        /// </summary>
        public bool GetFormsCredentials(out Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = password = authority = null;
            return false;
        }

        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;
            }
        }

        public ICredentials NetworkCredentials
        {
            get
            {
                return new NetworkCredential(Username, Password, DomainName);
            }
        }

        #endregion
    }
}
