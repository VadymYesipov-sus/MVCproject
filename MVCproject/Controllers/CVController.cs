using Microsoft.AspNetCore.Mvc;
using MVCproject.Interfaces;
using MVCproject.ViewModels;

namespace MVCproject.Controllers
{
    public class CVController : Controller
    {
        private readonly IUserRepository _userRepository;

        public CVController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> IndexVadym()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Mileage = user.Mileage,
                    ProfileImageUrl = user.ProfileImageUrl
                };
                result.Add(userViewModel);
            }
            return View(result);
        }

        public IActionResult IndexVlad()
        {

            return View();
        }
    }
}
