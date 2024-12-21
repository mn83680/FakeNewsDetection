using FND.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FND.ViewModel;

namespace FND.Controllers
{
    public class AccountController : Controller
    {

        // ingrction
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInMAnager;

        public AccountController(UserManager<ApplicationUser>
            _UserManager, SignInManager<ApplicationUser> _SignInMAnager)
        {
            userManager = _UserManager;
            signInMAnager = _SignInMAnager;
        }
        //..........................................................................................................................Register.
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]//<a href>
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.Name;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded == true)
                {
                    //creat cookie
                    await signInMAnager.SignInAsync(userModel, false);
                    return RedirectToAction("AllNews", "News");
                }
                else
                {
                    // عرض الأخطاء إذا فشل الإنشاء
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            //= await userManager.CreateAsync(userModel, newUserVM.Password);

            return View(newUserVM);
        }

        //..........................................................................................................................Login.

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel UserVm)
        {
            if (ModelState.IsValid)
            {
                //check User Name
                ApplicationUser userModel = await userManager.FindByNameAsync(UserVm.Name);
                if (userModel != null)
                {
                    //check Pass
                    bool found = await userManager.CheckPasswordAsync(userModel, UserVm.Password);
                    if (found)
                    {
                        //ckokie
                        //await signInMAnager.SignInAsync(userModel, UserVm.RememberMe);
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("Address", userModel.Address));
                        await signInMAnager.SignInWithClaimsAsync(userModel, UserVm.RememberMe, Claims);
                        return RedirectToAction("AllNews", "News");
                    }
                }
                ModelState.AddModelError("", "Username and password invalid");
            }
            return View(UserVm);
        }


        //..............................................................................................................Logout

        public async Task<IActionResult> Logout()
        {
            await signInMAnager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        //..............................................................................................................AddPublisher
        //Only the Admin sees these
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddPublisher()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddPublisher(RegisterUserViewModel newUserVM)
        {

            if (ModelState.IsValid)
            {
                //create user account
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.Name;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded == true)
                {
                    //assign to role
                    await userManager.AddToRoleAsync(userModel, "Publisher");
                    //creat cookie
                    await signInMAnager.SignInAsync(userModel, false);
                    return RedirectToAction("News", "News");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(newUserVM);
        }
        //..............................................................................................................AddAdmin
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [Authorize]//(Roles = "Admin")
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterUserViewModel newUserVM)
        {

            if (ModelState.IsValid)
            {
                //create new user account
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.Name;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded == true)
                {
                    //assign to role
                    await userManager.AddToRoleAsync(userModel, "Admin");
                    //creat cookie
                    // تسجيل الدخول للمشرف الجديد
                    await signInMAnager.SignInAsync(userModel, false);
                    //News controller's News action
                    return RedirectToAction("AllNews", "News");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(newUserVM);
        }
    }
}