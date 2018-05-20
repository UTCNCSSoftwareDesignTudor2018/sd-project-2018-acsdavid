using BikePortal.Business.Entity;

namespace BikePortal.Report
{
    public interface IOrderReportBody
    {
        IOrderReportBody AddOrderedItem(OrderItem item);
        IOrderReportBuilder CloseBody();
    }
}