using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

public class AuthenticationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var authHeader = context.HttpContext.Request.Headers["Authorization"];
        var token = authHeader.ToString().Split(' ')[1];

        if (token == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("JwtSettings:key");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

            // You can access the authenticated user from the principal
            context.HttpContext.Items["User"] = principal;

            await next();
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