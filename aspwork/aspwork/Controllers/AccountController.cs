using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.Owin.Security;
using ASPwork.Models;
using System.Collections;
using System.Data;


namespace ASPwork.Controllers
{
    

    public class AccountController : Controller
    {
        
        public ViewResult Login()
        {
            return View();
        }

        //[Filler.userfiller]
        public ViewResult Register ()
        {
            return View();
        }

        
        public ContentResult exit()
        {
            Session["username"] = null;
            Response.Redirect("/home/Index");
            return Content("success");
        }

        
        [HttpPost]
       
        public string DoLogin(string Name, string Password)
        {
            DBhelperBase db = new DBhelperBase();
            string result = string.Empty;
            string sql = "select Pwd from tb_user where Name='"+@Name+"'";
            Hashtable ht = new Hashtable();
            ht.Add(@Name, Name);
            DataRow row = db.GetRow(sql, ht);
            if (row == null)
            {
                result = "用户名输入错误";
            }
            else
            {
                if (Password == row["Pwd"].ToString())
                {
                    result = "输入口令错误";
                }
                else
                {
                    Response.Cookies["username"].Value = Name;
                    Session["username"] = Name;
                    Response.Redirect("/home/Index");
                }
            }
            return "<script>alert('" + result + "');history.back();</script>";
        }

      
        [HttpPost]
         public ContentResult Res(string username, string password)
        {
            DBhelperBase db = new DBhelperBase();
            string result = string.Empty;
            string sql = "insert  INTO  tb_user (Name,Pwd) VALUES ('111','11')";
             db.Execute(sql);
            Response.Redirect("/home/Index");
            return Content("success");
        }

    }
}