using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class TableauAuthenticatedTicket
    {
        /// <summary>
        /// GetTicket operation
        /// </summary>
        public static string GetTicket(string tableauServerTrustedUrl, string targetSite, string tableauUsername)
        {
            var postData = new StringBuilder();
            postData.Append("username");
            postData.Append("=");
            postData.Append(tableauUsername.ToLower());
            postData.Append("&");
            postData.Append("target_site");
            postData.Append("=");
            postData.Append(targetSite);

            var enc = new ASCIIEncoding(); 

            var byteArray = enc.GetBytes(postData.ToString());  
            
            var request = (HttpWebRequest)WebRequest.Create(tableauServerTrustedUrl);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.ContentLength = byteArray.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);

                stream.Flush();
                var response = (HttpWebResponse) request.GetResponse();

                var responseStream = response.GetResponseStream();

                if (responseStream == null)
                {
                    throw new NullReferenceException("responseStream is null");
                }

                using (var reader = new StreamReader(responseStream, enc))
                {
                    var ticket = reader.ReadToEnd();

                    reader.Close();
                    response.Close();

                    return ticket;
                }
            }
        }
    }
}