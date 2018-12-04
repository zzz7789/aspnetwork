using System.Web.Mvc;
using System.Collections;
using System.Data;


namespace ASPwork.Controllers
{


    public class AccountController : System.Web.Mvc.Controller
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
            string sql = "select Upassword from BBSUser where UName='" + @Name+"'";
            Hashtable ht = new Hashtable();
            ht.Add(@Name, Name);
            DataRow row = db.GetRow(sql, ht);
            if (row == null)
            {
                result = "用户名输入错误";
            }
            else
            {
                if (Password != row["Upassword"].ToString())
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
            string sql = "insert  INTO  BBSUser (UName,Upassword) VALUES ('"+ username + "','"+ password + "')";
             db.Execute(sql);
            Response.Redirect("/home/Index");
            return Content("success");
        }

    }
}