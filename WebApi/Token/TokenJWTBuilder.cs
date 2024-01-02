using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApi.Token
{
    public class TokenJWTBuilder
    {
        private SecurityKey SecurityKey = null;
        private string subject = "";
        private string issuer = "";
        private string audience = "";
        private Dictionary<string, string> claims = new Dictionary<string, string>();
        private int expiryInMinutes = 5;

        public TokenJWTBuilder AddSecurityKey( SecurityKey securityKey)
        {
            this.SecurityKey = securityKey;
            return this;
        }
        public TokenJWTBuilder AddSuject(string subject)
        { 
            this.subject = subject; 
            return this;
        }
        public TokenJWTBuilder AddIssuer(string issuer)
        { 
            this.issuer = issuer;
            return this;
        }
        public TokenJWTBuilder AddAudience(string audience)
        {
            this.audience = audience;   
            return this;    
        }
        public TokenJWTBuilder AddClaim(string type, string value)
        {
            this.claims.Add(type, value);
            return this;
        }

        public TokenJWTBuilder AddClaims(Dictionary<string, string> claims)
        {
            this.claims.Union(claims);
            return this;
        }
        public TokenJWTBuilder AddExpiry(int experyInMinutes)
        { 
            this.expiryInMinutes = experyInMinutes;
            return this;
        }

        private void EnssureArguments()
        {
            if (this.SecurityKey == null)
            {
                throw new ArgumentException("Security Key");
            }
            if (string.IsNullOrEmpty(this.subject))
            {
                throw new ArgumentException("Subject");
            }
            if (string.IsNullOrEmpty(this.issuer))
            {
                throw new ArgumentException("Issuer");
            }
            if (string.IsNullOrEmpty(this.audience))
            {
                throw new ArgumentException("Audience");
            }
        }

        public TokenJWT Bulder()
        { 
            EnssureArguments();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, this.subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(this.claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                issuer: this.issuer,
                audience: this.audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(this.expiryInMinutes),
                signingCredentials: new SigningCredentials(this.SecurityKey, SecurityAlgorithms.HmacSha256)
                );
            return new TokenJWT(token);
        }
    }
}
