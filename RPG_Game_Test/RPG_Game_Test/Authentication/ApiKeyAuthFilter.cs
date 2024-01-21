using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RPG_Game_Test.Authentication
{
    //Serve como de filtro para usar a chave em cada controlador
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyFilterName, out var extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("API Key Missing");
                return;
            }

            var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("Invalid Key");
                return;
            }
        }
    }
}
