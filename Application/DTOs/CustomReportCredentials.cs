using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// CustomReportCredentials
    /// </summary>
    public class CustomReportCredentials
    {
        private readonly string _userName;
        private readonly string _passWord;
        private readonly string _domainName;

        public CustomReportCredentials(string userName, string passWord, string domainName)
        {
            _userName = userName;
            _passWord = passWord;
            _domainName = domainName;
        }

        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;  // not use ImpersonationUser
            }
        }

        public ICredentials NetworkCredentials
        {
            get
            {
                return new NetworkCredential(_userName, _passWord, _domainName);
            }
        }

        /// <summary>
        /// GetFormsCredentials operation
        /// </summary>
        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {
            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }
}