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
using Project2.Models;

public class AuthenticationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string token = "";
        var authHeader = context.HttpContext.Request.Headers["Authorization"];

        if (!string.IsNullOrEmpty(authHeader))
        {
            string[] authHeaderParts = authHeader.ToString().Split(' ');

            if (authHeaderParts.Length == 2)
            {
                token = authHeaderParts[1];
            }
            else
            {
                // Handle the case where the Authorization header doesn't have the expected format
                Console.WriteLine(authHeader);
                context.Result = new UnauthorizedResult();
                return; // Exit the method to avoid further processing
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