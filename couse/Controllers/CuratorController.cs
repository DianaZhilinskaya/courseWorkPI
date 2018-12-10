using couse.mod;
using couse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace couse.Controllers
{
    public class CuratorController : Controller
    {
        public CuratorController()
        {

        }

        //[HttpPost]
        //public ActionResult Index(IEnumerable<Curator> curators)
        //{
        //    var ctx = new StudentModel();
        //    foreach (var c in curators)
        //    {
        //        var cur = ctx.Curators.Single(g => g.FIO.Trim() == c.FIO.Trim());
        //        cur.number_of_group = c.Number;
        //        //c.Grou
        //    }
        //    ctx.SaveChanges();
        //    return new JsonResult();
        //}

        // GET: Account
        public ActionResult Index()
        {
            var ctx = new StudentModel();
            var name = Session["login_user"].ToString();
            var cur = ctx.Curators.Single(G => G.FIO == name);
            var group = ctx.Group_students.Single( g => g.ID == cur.number_of_group);
            var model = new List<Student>();
            foreach (var stud in ctx.Students_id.Where( g=> g.group_students == group.ID))
            {
                model.Add(new Student { FIO = stud.FIO, group_students = stud.group_students ?? 0 });
            }
            //number_of_group
            return View(model);
            //создать переменную и сюда передать, создать dropdown
        }
    }
}