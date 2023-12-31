﻿using RedeSocialAPI.Models.Data;
using System.IdentityModel.Tokens.Jwt;

namespace RedeSocialAPI.src.Base.Middlewares
{
    public class JwtMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string authorizationHeader = context.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                string token = authorizationHeader.Substring("Bearer ".Length).Trim();

                var jwtHandler = new JwtSecurityTokenHandler();
                var claims = jwtHandler.ReadJwtToken(token).Claims;
                var sid = claims.FirstOrDefault(x => x.Type == "sid")?.Value;
                var email = claims.FirstOrDefault(x => x.Type == "email")?.Value;

                if (!string.IsNullOrEmpty(sid) && !string.IsNullOrEmpty(email))
                {
                    var userContextData = new UserContextData
                    {
                        Id = Convert.ToInt32(sid),
                        Email = email,
                    };

                    context.Items["UserContextData"] = userContextData;

                }
                else
                {
                    throw new Exception("Token Invalido");
                }
            }

            await next(context);
        }
    }
}
