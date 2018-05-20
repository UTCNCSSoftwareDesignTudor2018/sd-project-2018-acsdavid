using System.IO;
using BikePortal.Business.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BikePortal.Report
{
    public class PdfOrderReportBuilder : IOrderReportBuilder
    {
        public Document PdfDocument { get; private set; }
        private PdfWriter _pdfWriter;
        private readonly Stream _outputStream;

        public PdfOrderReportBuilder(Stream outputStream)
        {
            _outputStream = outputStream;
        }

        public IOrderReportBody CreateReport(Order order)
        {
            PdfDocument = new Document();
            _pdfWriter = PdfWriter.GetInstance(PdfDocument, _outputStream);
            _pdfWriter.CloseStream = false;

            PdfDocument.Open();
            PdfDocument.NewPage();
            var user = order.User;
            PdfDocument.Add(new Paragraph(user.FirstName + user.LastName));
            PdfDocument.Add(new Paragraph(order.Date.ToString()));

            return new PdfOrderReportBody(this);
        }
    }
}