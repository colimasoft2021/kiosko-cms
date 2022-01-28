using Kiosko.Data;
using Kiosko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosko.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginContext _login;

        public LoginController(LoginContext contexto)
        {
            _login = contexto;
        }
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Index(LoginModel item)
        {


            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Email",item.Email),
                new SqlParameter("@Pass",item.Pass),
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

                return View("Login");
            }

            catch (Exception ex)
            {
                TempData["msg"] = "No encuentro la base de datos";
                throw;
            }
        
        }
    }
}
