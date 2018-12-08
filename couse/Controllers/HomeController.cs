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

namespace couse.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentsModel"].ConnectionString);
        OleDbConnection Econ;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            InsertExceldata(filepath, filename);

            return View();
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
            objbulk.DestinationTableName = "Form_of_education";
            objbulk.ColumnMappings.Add("ID", "ID");
            objbulk.ColumnMappings.Add("budget", "budget");
            objbulk.ColumnMappings.Add("paid", "paid");
            SqlBulkCopy objbulk1 = new SqlBulkCopy(con);
            objbulk1.DestinationTableName = "Needing_social_protection";
            objbulk1.ColumnMappings.Add("ID", "ID");
            objbulk1.ColumnMappings.Add("orphan students", "orphan_students");
            objbulk1.ColumnMappings.Add("lost_the_last_of_the_parents_in_the_period_of_study", "lost_the_last_of_the_parents_in_the_period_of_study");
            objbulk1.ColumnMappings.Add("in_custody", "in_custody");
            objbulk1.ColumnMappings.Add("disabled_students", "disabled_students");
            //objbulk.ColumnMappings.Add("paid", "paid");

            con.Open();
            objbulk.WriteToServer(dt);
            objbulk1.WriteToServer(dt);
            con.Close();
        }

    }
}