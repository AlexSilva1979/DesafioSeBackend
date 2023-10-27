using AvaliacaoSesab.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AvaliacaoSesab.Helper
{
    public class SessionUser : ISessionUser
    {
        private readonly IHttpContextAccessor _httpContext;

        public SessionUser(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UserModel GetSessionUser()
        {
            string sessaoUser = _httpContext.HttpContext.Session.GetString("UserLogin");

            if (string.IsNullOrEmpty(sessaoUser)) return null;
            return JsonConvert.DeserializeObject<UserModel>(sessaoUser);
        }

        public void CreateSessionUser(UserModel usuarioModel)
        {
            string valor = JsonConvert.SerializeObject(usuarioModel);

            _httpContext.HttpContext.Session.SetString("UserLogin", valor);
        }

        public void RemoveSessionUser()
        {
            _httpContext.HttpContext.Session.Remove("UserLogin");
        }
    }
}
