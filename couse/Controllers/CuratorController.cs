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
using System.Text;

namespace couse.Controllers
{
    public class CuratorController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentModel"].ConnectionString);
        OleDbConnection Econ;

        public CuratorController()
        { }

        // GET: Account
        public ActionResult Index()
        {
            var sts = GetStuds();
            return View(sts);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string filename = Session["login_user"] + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            InsertExceldata(filepath, filename);

            return RedirectToAction("Index");
        }

        //[HttpGet]
        public ActionResult Download()
        {

            string filename = Session["login_user"] + DateTime.Now.ToFileTime().ToString();
            string fullpath = Server.MapPath("/excelload/") + filename;

            ExcelConn(fullpath);

            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", fullpath);

            using (Econ = new OleDbConnection(constr))
            {

                Econ.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Econ;
                var sql = @"CREATE TABLE [Sheet1] ([FIO] varchar(50),
[number_of_group] int,
[from_Minsk] bit,
[from_the_countryside] bit,
[from_other_regions] bit,
[from_CIS_countries] bit,
[from_other_countries] bit,
[in_dorm] bit,
[in_a_private_apartment] bit,
[houses] bit,
[at_full_state_providing] bit,
[have_a_guardian] bit,
[orphan_students] int,
[lost_the_last_of_the_parents_in_the_period_of_study] bit,
[in_custody] bit,
[disabled_students] bit,
[underage_students] int,
[single_parent_students] bit,
[students_from_large_families] bit,
[students_with_disabled_parents_1_2_groups] bit,
[affected_by_the_Chernobyl_accident]  bit,
[disaster_victims] bit,
[refugee_families] bit,
[parents_died_during_passage_of_military_or_police_services] bit,
[internal_control_students] bit,
[underperforming_students] bit,
[family_students] bit,
[students_with_children] bit,
[with_severe_chronic_diseases] bit,
[budget] bit,
[paid] bit, 
[student_activists] bit);";

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                var sts = GetStuds();

                foreach (var stud in sts)
                {
                    var append = @"Insert into [Sheet1$] ([FIO]
      ,[number_of_group]
      ,[from_Minsk]
      ,[from_the_countryside]
      ,[from_other_regions]
      ,[from_CIS_countries]
      ,[from_other_countries]
      ,[in_dorm]
      ,[in_a_private_apartment]
      ,[houses]
      ,[at_full_state_providing]
      ,[have_a_guardian]
      ,[orphan_students]
      ,[lost_the_last_of_the_parents_in_the_period_of_study]
      ,[in_custody]
      ,[disabled_students]
      ,[underage_students]
      ,[single_parent_students]
      ,[students_from_large_families]
      ,[students_with_disabled_parents_1_2_groups]
      ,[affected_by_the_Chernobyl_accident]
      ,[disaster_victims]
      ,[refugee_families]
      ,[parents_died_during_passage_of_military_or_police_services]
      ,[internal_control_students]
      ,[underperforming_students]
      ,[family_students]
      ,[students_with_children]
      ,[with_severe_chronic_diseases]
      ,[budget]
      ,[paid]
      ,[student_activists]) 
VALUES ('" + stud.FIO + "','" + stud.group_students + "','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','');";
                    cmd.CommandText = append;
                    cmd.ExecuteNonQuery();
                }

            }

            //AppDomain.CurrentDomain
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("/excelload/") + filename + ".xlsx");
            filename = filename + ".xlsx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
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

        private List<Student> GetStuds()
        {
            var ctx = new StudentModel();
            var name = Session["login_user"].ToString();
            var cur = ctx.Curators.Single(G => G.FIO == name);
            var group = ctx.Group_students.Single(g => g.ID == cur.number_of_group);
            var list = new List<Student>();
            foreach (var stud in ctx.Students_id.Where(g => g.group_students == group.ID))
            {
                list.Add(new Student { FIO = stud.FIO, group_students = stud.group_students ?? 0 });
            }
            return list;
        }
    }
}