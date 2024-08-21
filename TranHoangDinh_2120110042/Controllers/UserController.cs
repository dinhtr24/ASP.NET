using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TranHoangDinh_2120110042.Context;

namespace TranHoangDinh_2120110042.Controllers
{
    public class UserController : Controller
    {
        ElectronicEntities db = new ElectronicEntities();
        // GET: User

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                //return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                 StringBuilder sb = new System.Text.StringBuilder();
                 for (int i = 0; i < hashBytes.Length; i++)
                 {
                     sb.Append(hashBytes[i].ToString("X2"));
                 }
                 return sb.ToString();
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User objuser)
        {
            try
            {
                objuser.Password = CreateMD5(objuser.Password);
                db.Users.Add(objuser);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User objuser)
        {
            objuser.Password = CreateMD5(objuser.Password);
            var FlagUser = db.Users.Where(n=>n.Password == objuser.Password && n.Email == objuser.Email).ToList();
            if (FlagUser.Count > 0)
            {
                Session["username"] = FlagUser.FirstOrDefault().FirstName.ToString() + FlagUser.FirstOrDefault().LastName.ToString();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}