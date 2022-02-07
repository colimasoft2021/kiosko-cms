using Kiosko.Data;
using Kiosko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosko.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginContext _login;

        public HomeController(ILogger<HomeController> logger, LoginContext contexto)
        {
            _logger = logger;
            _login = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel item)
        {


            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Email",item.vchEmail),
                new SqlParameter("@Pass",item.vchPass),
               /* new SqlParameter("@Usuario", item.Email),*/
            };

            try
            {
                
                var result = _login.LoginItems.FromSqlRaw<LoginModel>("exec Loggin @Email, @Pass", param).ToList();
                if (result.Count == 0)
                {
                    TempData["msg"] = "Usuario o Contrasena incorrectos, intenete otra vez";
                }
                else
                {
                    TempData["msg"] = "Bienvenido";
                    //var res = _KColSoft.KColSoftsItem.FromSqlRaw<KColSoftModel>("exec dbo.RegistroDB @Usuario", param).ToList();
                }

                return View();
            }

            catch (Exception ex)
            {
                TempData["msg"] = "No encuentro la base de datos";
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
