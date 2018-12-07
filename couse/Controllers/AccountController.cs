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
        
        [HttpPost]
        public ActionResult Index(IEnumerable<Curator> curators)
        {
            var ctx = new StudentsModel();
            foreach (var c in curators)
            {
                var cur = ctx.Curators.Single( g => g.FIO == c.curator);
                cur.number_of_group = c.number;
                
            }
            ctx.SaveChanges();
            return View(curators);
        }
        // GET: Account
        public ActionResult Index()
        {
            var ctx = new StudentsModel();
            var groups = ctx.Group_students;
            var model = new List<Curator>();
            foreach(var st in ctx.Curators)
            {
                model.Add(new Curator {curator = st.FIO , groups = groups.Select(g => g.number_of_group).ToList() });
            }
            return View(model);//создать переменную и сюда передать, создать dropdown
        }

        public ActionResult AddCurators()
        {
            return View();
        }
        public ActionResult DeleteCurators()
        {
            return View();
        }
    }
}