using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Token
{
    public class TokenJWT
    {
        private JwtSecurityToken _token;
        public TokenJWT(JwtSecurityToken token)
        {
            _token = token; 
        }
        public DateTime ValidTo => _token.ValidTo;

        public string value => new JwtSecurityTokenHandler().WriteToken(_token);



    }
}
