using Kiosko.Data;
using Kiosko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kiosko.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APILoginController : ControllerBase
    {
        private readonly LoginContext _login;

        public APILoginController(LoginContext login)
        {
            _login = login;
        }
        // GET: api/<APILoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<APILoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APILoginController>
        [HttpPost]
        public IActionResult Login(LoginModel item)
        {
            List<isLoginUser> res = new List<isLoginUser>();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@vchEmail",item.vchEmail),
                new SqlParameter("@vchPass",item.vchPass)
            };
            try
            {
                var result = _login.LoginItems.FromSqlRaw<LoginModel>("exec Loggin @vchEmail, @vchPass", param).ToList();
                if (result.Count == 1)
                {
                    //res = isLoginUser(item, 1);
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

        // PUT api/<APILoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APILoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private class isLoginUser
        {
            public string Email { get; set; }
            public int isLogin { get; set; }
        }

        private isLoginUser isLogin(LoginModel item, int band)
        {
            List<isLoginUser> res = new List<isLoginUser>();
            if (band == 1)
            {
                res[0].Email = item.vchEmail;
                res[0].isLogin = 1;
                return (res[0]);
            }
            else
            {
                res[0].Email = item.vchEmail;
                res[0].isLogin = 0;
                return (res[0]);
            }
        }
    }
}
