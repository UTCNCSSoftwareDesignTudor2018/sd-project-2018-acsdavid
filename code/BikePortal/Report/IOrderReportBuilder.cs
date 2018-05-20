using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;

namespace BikePortal.Report
{
    public interface IOrderReportBuilder
    {
        IOrderReportBody CreateReport(Order order);
    }
}
