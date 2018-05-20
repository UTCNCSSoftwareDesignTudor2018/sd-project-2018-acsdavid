using BikePortal.Business.Entity;
using iTextSharp.text.pdf;

namespace BikePortal.Report
{
    internal class PdfOrderReportBody : IOrderReportBody
    {
        private readonly PdfOrderReportBuilder _pdfBuilder;
        private readonly PdfPTable _table;

        public PdfOrderReportBody(PdfOrderReportBuilder pdfBuilder)
        {
            _pdfBuilder = pdfBuilder;

            _pdfBuilder = pdfBuilder;

            _table = new PdfPTable(3);
            _table.AddCell("Name");
            _table.AddCell("Quantity");
            _table.AddCell("Price");
        }

        public IOrderReportBody AddOrderedItem(OrderItem item)
        {
            _table.AddCell(item.Article.Name);
            _table.AddCell(item.Quantity.ToString());
            _table.AddCell(item.PricePerItem.ToString());

            return this;
        }

        public IOrderReportBuilder CloseBody()
        {
            _pdfBuilder.PdfDocument.Add(_table);
            return _pdfBuilder;
        }
    }
}