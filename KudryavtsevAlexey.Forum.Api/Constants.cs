using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Api
{
    public static class Constants
    {
        public const string Issuer = "https://localhost:5001";
        public const string Audience = Issuer;
        public const string SecretKey = "secret_key_for_jwt_token_generation"; //TODO: Memory cached
    }
}
