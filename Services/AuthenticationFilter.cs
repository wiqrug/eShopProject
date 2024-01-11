using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class AuthenticationFilter : IAsyncActionFilter
{
    public class CurrentUser
    {
        public string email { get; set; }
        public string token { get; set; }
        public int candidateNumber { get; set; }
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string cookie = context.HttpContext.Request.Cookies["currentUser"];
        CurrentUser parsedCookie = JsonConvert.DeserializeObject<CurrentUser>(cookie);
        var token = parsedCookie.token;

        if (token == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("JwtSettings:Key");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
            
            if (principal.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Candidate"))
            {
                // You can access the authenticated user from the principal
                context.HttpContext.Items["User"] = principal;

                await next();
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }
        catch (SecurityTokenException)
        {
            context.Result = new ForbidResult();
        }
    }
}

//        [ServiceFilter(typeof(AuthenticationFilter))]
//to parapano annotation tha to vazoume pano apo kathe controller/action pou theloume 
//na kanei authenticate protou to xtipisei to front-end