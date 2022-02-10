using QazaqmysTestTask.Models.List;
using QazaqmysTestTask.Models.Repositry;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace QazaqmysTestTask.Controllers.HomePage
{
    public static class HomeModel
    {
        private static NumberRepository numberRepository = new NumberRepository();
        private static UserRepository userRepository = new UserRepository();

        public static NumbersListModel Initialize(HttpContext httpContext)
        {
            var numbers = numberRepository.GetNumbers();
            var user = userRepository.GetUsers().Find(m => m.Name == httpContext.User.Identity.Name);
            long userID = user.Id;
            bool isAdmin = user.IsAdmin;

            return new NumbersListModel { Numbers = numbers, UserID = userID, IsAdmin = isAdmin};
        }

        public static NumbersListModel Initialize(HttpContext httpContext, NumbersListModel model)
        {
            numberRepository.Save(new Models.EF.Number { Number1 = model.Number, UserId = model.UserID, Title = model.Title });
            var numbers = numberRepository.GetNumbers();
            long userID = model.UserID;
            bool isAdmin = model.IsAdmin;

            return new NumbersListModel { Numbers = numbers, UserID = userID, IsAdmin = isAdmin };
        }
    }
}
