using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using couse.mod;
using couse.Models;

namespace couse.Controllers
{
    public class CuratorController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentModel"].ConnectionString);
        OleDbConnection Econ;
        public CuratorController()
        {

        }
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
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            InsertExceldata(filepath, filename);

            return RedirectToAction("Index");
        }

        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
            Econ = new OleDbConnection(constr);

        }

        private void InsertExceldata(string fileepath, string filename)
        {
            string fullpath = Server.MapPath("/excelfolder/") + filename;
            ExcelConn(fullpath);
            string query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);

            DataTable dt = ds.Tables[0];

            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "Students_all";
            objbulk.ColumnMappings.Add("FIO", "FIO");
            objbulk.ColumnMappings.Add("number_of_group", "number_of_group");
            objbulk.ColumnMappings.Add("from_Minsk", "from_Minsk");
            objbulk.ColumnMappings.Add("from_the_countryside", "from_the_countryside");
            objbulk.ColumnMappings.Add("from_other_regions", "from_other_regions");
            objbulk.ColumnMappings.Add("from_CIS_countries", "from_CIS_countries");
            objbulk.ColumnMappings.Add("from_other_countries", "from_other_countries");
            objbulk.ColumnMappings.Add("in_dorm", "in_dorm");
            objbulk.ColumnMappings.Add("in_a_private_apartment", "in_a_private_apartment");
            objbulk.ColumnMappings.Add("houses", "houses");
            objbulk.ColumnMappings.Add("at_full_state_providing", "at_full_state_providing");
            objbulk.ColumnMappings.Add("have_a_guardian", "have_a_guardian");
            objbulk.ColumnMappings.Add("orphan_students", "orphan_students");
            objbulk.ColumnMappings.Add("lost_the_last_of_the_parents_in_the_period_of_study", "lost_the_last_of_the_parents_in_the_period_of_study");
            objbulk.ColumnMappings.Add("in_custody", "in_custody");
            objbulk.ColumnMappings.Add("disabled_students", "disabled_students");
            objbulk.ColumnMappings.Add("underage_students", "underage_students");
            objbulk.ColumnMappings.Add("single_parent_students", "single_parent_students");
            objbulk.ColumnMappings.Add("students_from_large_families", "students_from_large_families");
            objbulk.ColumnMappings.Add("students_with_disabled_parents_1_2_groups", "students_with_disabled_parents_1_2_groups");
            objbulk.ColumnMappings.Add("affected_by_the_Chernobyl_accident", "affected_by_the_Chernobyl_accident");
            objbulk.ColumnMappings.Add("disaster_victims", "disaster_victims");
            objbulk.ColumnMappings.Add("refugee_families", "refugee_families");
            objbulk.ColumnMappings.Add("parents_died_during_passage_of_military_or_police_services", "parents_died_during_passage_of_military_or_police_services");
            objbulk.ColumnMappings.Add("internal_control_students", "internal_control_students");
            objbulk.ColumnMappings.Add("underperforming_students", "underperforming_students");
            objbulk.ColumnMappings.Add("family_students", "family_students");
            objbulk.ColumnMappings.Add("students_with_children", "students_with_children");
            objbulk.ColumnMappings.Add("with_severe_chronic_diseases", "with_severe_chronic_diseases");
            objbulk.ColumnMappings.Add("budget", "budget");
            objbulk.ColumnMappings.Add("paid", "paid");
            objbulk.ColumnMappings.Add("student_activists", "student_activists");

            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();
        }
    }
}