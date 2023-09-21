using System.IdentityModel.Tokens.Jwt;

namespace Bbit2taks.Policy
{
    public class JwtHelper
    {
        public static Dictionary<string, string> GetTokenData(HttpContext httpContext)
        {
            try
            {
                var jwtToken = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwtToken);

                var tokenData = new Dictionary<string, string>();

                foreach (var claim in token.Claims)
                {
                    tokenData[claim.Type] = claim.Value;
                }

                return tokenData;
            }
            catch
            {
                // Handle exceptions, e.g., token validation errors
                return null;
            }
        }

        public static int? GetHouseId(HttpContext httpContext)
        {
            var tokenData = GetTokenData(httpContext);
            if (tokenData != null && tokenData.TryGetValue("houseid", out string houseIdStr))
            {
                if (int.TryParse(houseIdStr, out int houseId))
                {
                    return houseId;
                }
            }

            return null;
        }

        public static int? GetResidentId(HttpContext httpContext)
        {
            var tokenData = GetTokenData(httpContext);
            if (tokenData != null && tokenData.TryGetValue("residentid", out string residentIdStr))
            {
                if (int.TryParse(residentIdStr, out int residentId))
                {
                    return residentId;
                }
            }

            return null;
        }

        public static int? GetApartmentId(HttpContext httpContext)
        {
            var tokenData = GetTokenData(httpContext);
            if (tokenData != null && tokenData.TryGetValue("apartmentid", out string apartmentIdStr))
            {
                if (int.TryParse(apartmentIdStr, out int apartmentId))
                {
                    return apartmentId;
                }
            }

            return null;
        }
    }
}
