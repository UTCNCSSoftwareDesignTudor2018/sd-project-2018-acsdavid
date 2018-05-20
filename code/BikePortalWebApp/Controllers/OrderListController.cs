using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using BikePortal.Business.Process;
using BikePortal.Report;

namespace BikePortalWebApp.Controllers
{
    public class OrderListController : Controller
    {
        private readonly IOrderBll _orderBll;

        public OrderListController(IOrderBll orderBll)
        {
            _orderBll = orderBll;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewData.Model = id;
            return View();
        }

        public ActionResult Pdf(int id)
        {
            var pdfBuilder = new PdfOrderReportBuilder(Response.OutputStream);
            var order = _orderBll.Get(id);
            if (order == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var body = pdfBuilder.CreateReport(order);

            foreach (var item in order.OrderedArticles)
            {
                body.AddOrderedItem(item);
            }

            body.CloseBody();

            pdfBuilder.PdfDocument.Close();

            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Order.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfBuilder.PdfDocument);
            Response.End();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}