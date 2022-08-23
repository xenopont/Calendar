using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;

using System.IO;
using System.Threading;

namespace Calendar.Google
{
    internal class Common
    {
        static public UserCredential AuthAsync(string credIn, string credOut, string[] scopes)
        {
            using var stream = new FileStream(credIn, FileMode.Open, FileAccess.Read);

            return GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credOut, true)).Result;
        }
    }
}
