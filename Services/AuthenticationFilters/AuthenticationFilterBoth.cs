using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class AuthenticationFilterBoth : IAsyncActionFilter
{
    public class CurrentUser
    {
        public string email { get; set; }
        public string token { get; set; }
        public int candidateNumber { get; set; }
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string token = "";
        var authHeader = context.HttpContext.Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(authHeader))
        {
            token = authHeader.ToString().Split(' ')[1];
        }
        else
        {
            string? cookie = context.HttpContext.Request.Cookies["currentUser"];

            if (cookie != null)
            {
                CurrentUser? parsedCookie = JsonConvert.DeserializeObject<CurrentUser>(cookie);
                token = parsedCookie.token;
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new InvalidOperationException("The required cookie 'currentUser' was not found.");
            }
        }

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("verysecretserverkey123");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

            if (principal.HasClaim(c => c.Type == "Role" && (c.Value == "Admin" || c.Value == "Candidate")))
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

//        [ServiceFilter(typeof(AuthenticationFilterCandidate))]
//to parapano annotation tha to vazoume pano apo kathe controller/action pou theloume 
//na kanei authenticate protou to xtipisei to front-end