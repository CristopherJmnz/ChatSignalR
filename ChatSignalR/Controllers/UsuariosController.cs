using ChatSignalR.Models;
using ChatSignalR.Repositories;
using Microsoft.AspNetCore.Mvc;
using ChatSignalR.Extensions;

namespace ChatSignalR.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuariosRepository repo;
        public UsuariosController(UsuariosRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            Usuario user = this.repo.Login(email, password);
            if (user!=null)
            {
                HttpContext.Session.SetObject("user", user);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["MENSAJE"] = "Password o email incorrectos";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index","Home");
        }


    }
}
