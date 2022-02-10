using Microsoft.AspNetCore.Http;
using QazaqmysTestTask.Controllers.Authorization.Encrypt;
using QazaqmysTestTask.Models.Authorization;
using QazaqmysTestTask.Models.EF;
using QazaqmysTestTask.Models.Repositry;
using System.Threading.Tasks;

namespace QazaqmysTestTask.Controllers.Authorization.Login
{
    public static class LoginHandler
    {
        private static UserRepository userRepository = new UserRepository();

        public static async Task<bool> AreCredentialsCorrect(LoginModel model, HttpContext httpContext)
        {
            if(model != null)
            {
                User potentialUser = userRepository.GetUsers().Find(m => m.Name == model.Name);

                if(potentialUser != null)
                {
                    bool isLogged = Hasher.VerifyHashedPassword(potentialUser.Password, model.Password);

                    if (isLogged)
                    {
                        await CustomCookieHandler.Authenticate(httpContext, model.Name);

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
