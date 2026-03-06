using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class HaveIBeenPwned
    {
        /// <summary>
        /// CheckHaveIBeenPwned operation
        /// </summary>
        public static bool CheckHaveIBeenPwned(string newPassword, int breachCountTolerance)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                return false;
            }

            

            var hashManager = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(newPassword));
            var passwordHash = string.Join("", hashManager.Select(b => b.ToString("x2")).ToArray());

            var sentHash = passwordHash.Substring(0, 5);
            var receivedHash = passwordHash.Substring(5);
            return Retry.Do(() =>
            {
                var request = (HttpWebRequest)WebRequest.Create($"https://api.pwnedpasswords.com/range/{sentHash}");
                request.Method = "GET";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var response = (HttpWebResponse)request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();

                    var hashList = result.Split('\n').ToList();
                    var foundPassword = hashList.FirstOrDefault(x => x.StartsWith(receivedHash, StringComparison.InvariantCultureIgnoreCase));
                    if (foundPassword != null && foundPassword.Contains(":"))
                    {
                        int.TryParse(foundPassword.Split(':')[1], out var count);

                        if (count > breachCountTolerance) // how many time does a password have to appear in order to be determined as "bad"
                        {
                            return true;
                        }
                    }
                }
                return false;
            },
            TimeSpan.FromSeconds(3), // 3 second interval because HaveIBeenPwned rate limits to 1.5 seconds
            10,// abritary retry count
            (AggregateException ex) =>
            {
            });
        }
    }
}
