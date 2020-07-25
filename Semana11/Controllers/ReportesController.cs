using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using Semana11.Reportes;

namespace Semana11.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult ReporteEmpleados()
        {

            ReportViewer rp = new ReportViewer();
            rp.ProcessingMode = ProcessingMode.Local;
            rp.SizeToReportContent = true;

            SqlConnection conx = new SqlConnection("server=JORGE-PC;database=DbClinica;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Empleado", conx);

            dsNegocios ds = new dsNegocios();
            da.Fill(ds, ds.Empleado.TableName);

            rp.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes\rptEmpleados.rdlc";
            rp.LocalReport.DataSources.Add(new ReportDataSource("dsReporte", ds.Tables[0]));

            ViewBag.ReportViewer = rp;

            return View();
        }


    }
}