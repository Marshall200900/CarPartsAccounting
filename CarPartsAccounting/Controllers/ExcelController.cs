using ClosedXML.Excel;
using CarPartsAccounting.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GymAccoutingWeb.Controllers
{
    public class ExcelController : Controller
    {
        public class FormSend
        {
            public string Name { get; set; }
        }

        private AutopartsShopEntities db = new AutopartsShopEntities();

        // GET: Excel
        [HttpGet]
        public ActionResult Index()
        {
            string[] names = { "id", "sale_percent_id", "date", "worker_id"};

            List<SelectListItem> Name = new List<SelectListItem>();
            foreach (var a in names)
            {
                Name.Add(new SelectListItem() { Text = a });
            }

            ViewBag.Name = Name;
            return View();
        }


        [HttpPost]
        public FileResult Index(FormSend form)
        {
            DataTable dt = new DataTable();
            string path;
            dt.Columns.Add("Идентификатор записи");
            dt.Columns.Add("Скидка");
            dt.Columns.Add("Дата");
            dt.Columns.Add("Работник");
            dt.Columns.Add("Детали");


            var accounting = db.accounting;

            //Adding the Rows.
            foreach (var row in accounting.Include(s => s.sales).Include(w => w.workers).ToList())
            {

                dt.Rows.Add();

                dt.Rows[dt.Rows.Count - 1][0] = row.id;
                dt.Rows[dt.Rows.Count - 1][1] = row.sales.sale_percent;
                dt.Rows[dt.Rows.Count - 1][2] = row.date;
                dt.Rows[dt.Rows.Count - 1][3] = row.workers.worker_name;
                string details = "";
                foreach(var detail in db.sold_parts.Where(s => s.selling_id == row.id))
                {
                    details += detail.parts.part_name + ", ";
                }
                dt.Rows[dt.Rows.Count - 1][4] = details;


            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Accounting");
                path = Server.MapPath("~/Files/hello.xlsx");
                wb.SaveAs(path);

            }

            return File(path, "application/xml", "Accounting.xlsx");
        }

    }
}