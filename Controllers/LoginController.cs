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
        private readonly KColSoftContext _KColSoft;

        public LoginController(LoginContext login, KColSoftContext kColSoft)
        {
            _login = login;
            _KColSoft = kColSoft;
        }
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginModel item)
        {


            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Email",item.vchEmail),
                new SqlParameter("@Pass",item.vchPass),
                new SqlParameter("@Usuario", item.vchEmail),
            };

            try
            {
                var result = _login.LoginItems.FromSqlRaw<LoginModel>("exec Loggin @vchEmail, @vchPass", param).ToList();
                
                if (result.Count == 0)
                {
                    TempData["msg"] = "Usuario o Contrasena incorrectos, intenete otra vez";
                }
                else
                {
                    //xd
                    TempData["msg"] = "Bienvenido";
                    var res = _KColSoft.KColSoftsItem.FromSqlRaw<KColSoftModel>("exec dbo.RegistroDB @vchUsuario", param).ToList();
                }

                return View("Login");
            }

            catch (Exception ex)
            {
                TempData["msg"] = "No encuentro la base de datos";
                throw;
            }
        
        }
        [HttpPost]
        public IActionResult Index(LoginModel item)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Email",item.vchEmail),
                new SqlParameter("@Pass",item.vchPass)
            };
            try
            {
                var result = _login.LoginItems.FromSqlRaw<LoginModel>("exec Loggin @vchEmail, @vchPass", param).ToList();
                if (result.Count == 0)
                {
                    result[0].vchPass = "1";
                    return Ok(result);
                }
                else
                {
                    result[0].vchPass = "0";
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
