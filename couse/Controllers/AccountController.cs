using couse.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace couse.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }
        
        

        // GET: Account
        public ActionResult Index()
        {
            var ctx = new StudentModel();
            var groups = ctx.Group_students;
            var model = new List<Curator>();
            foreach(var cur in ctx.Curators)
            {
                model.Add(new Curator {FIO = cur.FIO, Groups = groups.Select(g => g. ID).ToList(), Number = cur.number_of_group ?? 0});
            }
            //number_of_group
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(IEnumerable<Curator> curators)
        {
            var ctx = new StudentModel();
            foreach (var c in curators)
            {
                var cur = ctx.Curators.Single(g => g.FIO.Trim() == c.FIO.Trim());
                cur.number_of_group = c.Number;
                //c.Grou
            }
            ctx.SaveChanges();
            return new JsonResult();
        }

        [HttpPost]
        public ActionResult Add(string fio, int number, string pass)
        {
            var ctx = new StudentModel();
            ctx.Curators.Add(new mod.Curators()
            {
                FIO = fio,
                number_of_group = number,
            });

            ctx.Autorization.Add(new mod.Autorization()
            {
                login_user = fio,
                password_user = pass,
            });
            ctx.SaveChanges();
           
            return new JsonResult();
        }

        
    }
}