using QazaqmysTestTask.Data;
using QazaqmysTestTask.Models.Authorization;
using QazaqmysTestTask.Models.EF;
using QazaqmysTestTask.Models.Repositry;
using QazaqmysTestTask.Controllers.Authorization.Encrypt;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace QazaqmysTestTask.Controllers.Authorization.Registration
{
    public static class RegistrationHandler
    {
        private static UserRepository userRepository = new UserRepository();

        public static async Task<bool> Registrable(RegistrationModel model, HttpContext httpContext)
        {
            if (model != null)
            {
                if (userRepository.GetUsers().Exists(m => m.Name == model.Name) == false)
                {
                    User user = new User() 
                    { 
                        Name = model.Name, 
                        Password = Hasher.HashPassword(model.Password), 
                        IsAdmin = model.Role 
                    };

                    userRepository.Save(user);

                    await CustomCookieHandler.Authenticate(httpContext, model.Name);

                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
