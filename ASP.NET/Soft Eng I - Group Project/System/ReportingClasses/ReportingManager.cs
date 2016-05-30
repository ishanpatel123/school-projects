using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AuditSystem.MessageClasses;
namespace AuditSystem.ReportingClasses
{
    class ReportingManager
    {
        public MessageEnums.MessageType CurrentMessage;
        public ReportingManager()
        {
            CurrentMessage = MessageEnums.MessageType.START;
        }

        public void WaitLoop()
        {
            while (CurrentMessage != MessageEnums.MessageType.END)
            {
                MessageQueue.ReportingSem.WaitOne();

                CurrentMessage = MessageQueue.ReportQueue.Dequeue();
                if (CurrentMessage == MessageEnums.MessageType.END)
                    break;
                else
                    ReceiveWork(CurrentMessage);
            }
        }

        public void ReceiveWork(MessageClasses.MessageEnums.MessageType Message)
        {
            #if(DEBUG)
                Thread.Sleep(3000);
            #endif
            if (Message == MessageEnums.MessageType.NONE)
            {
                SendFeedback("Error - No Secondary Message Type Sent");
            }
            else if (Message == MessageEnums.MessageType.ACTIVITY_REPORT)
            {
                RunActivityReport();
            }
            else if (Message == MessageEnums.MessageType.MONTHLY_REPORT)
            {
                RunMonthlyReport();
            }
            else if (Message == MessageEnums.MessageType.SUMMARY_REPORT)
            {
                RunSummaryReport();
            }
        }

        public void RunActivityReport()
        {
            //String ActivityReportResults = DalReporting.ActivityReport.GetReportData()
            String ActivityReportResults = "DalReporting.ActivityReport.GetReportData();";
            SendFeedback(ActivityReportResults);
        }

        public void RunMonthlyReport()
        {
            //String MonthlyReportResults = DalReporting.MonthlyReport.GetReportData()
            String ActivityReportResults = "DalReporting.MonthlyReport.GetReportData();";
            SendFeedback(ActivityReportResults);
        }

        public void RunSummaryReport()
        {
            //String SummaryReportResults = DalReporting.SummaryReport.GetReportData()
            String ActivityReportResults = "DalReporting.SummaryReport.GetReportData();";
            SendFeedback(ActivityReportResults);
        }

        public void SendFeedback(String Output)
        {
            MessageQueue.ReturnQueue.Enqueue(Output);
        }
    }
}
