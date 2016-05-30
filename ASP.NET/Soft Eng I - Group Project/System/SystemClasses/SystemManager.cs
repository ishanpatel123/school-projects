using System;
using System.Collections.Generic;
using System.Linq;
using AuditSystem.MessageClasses;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuditSystem.SystemClasses
{
    public class SystemManager
    {
        private ReportingClasses.ReportingManager ReportMan;
        private AssessorClasses.AssessorManager AssessorMan;
        private EmailClasses.EmailManager EmailMan;

        private Thread ReportThread;
        private Thread AssessorThread;
        private Thread EmailThread;

        public SystemManager()
        {
            ReportMan = new ReportingClasses.ReportingManager();
            AssessorMan = new AssessorClasses.AssessorManager();
            EmailMan = new EmailClasses.EmailManager();

            ReportThread = new Thread(ReportMan.WaitLoop);
            AssessorThread = new Thread(AssessorMan.WaitLoop);
            EmailThread = new Thread(EmailMan.WaitLoop);

            ReportThread.Name = "ReportThread";
            AssessorThread.Name = "AssessorThread";
            EmailThread.Name = "EmailThread";
            
            ReportThread.Start();
            AssessorThread.Start();
            EmailThread.Start();
        }

        public String SendWork(MessageEnums.MessageType PrimaryMessage, MessageEnums.MessageType SecondaryMessage = MessageEnums.MessageType.NONE)
        {
            #if(DEBUG)
                GetThreadInfo("All");
            #endif
            if (PrimaryMessage == MessageEnums.MessageType.REPORT)
            {
                MessageQueue.ReportQueue.Enqueue(SecondaryMessage);
                MessageQueue.ReportingSem.Release(1);
                #if(DEBUG)
                    GetThreadInfo("Report");
                #endif
            }
            else if (PrimaryMessage == MessageEnums.MessageType.ASSESSMENT)
            {
                MessageQueue.AssessorQueue.Enqueue(SecondaryMessage);
                MessageQueue.AssessorSem.Release(1);
                #if(DEBUG)
                    GetThreadInfo("Assessor");
                #endif
            }
            else if (PrimaryMessage == MessageEnums.MessageType.EMAIL)
            {
                MessageQueue.EmailQueue.Enqueue(SecondaryMessage);
                MessageQueue.EmailSem.Release(1);
                #if(DEBUG)
                    GetThreadInfo("Email");
                #endif
            }
            else if (PrimaryMessage == MessageEnums.MessageType.END)
            {
                MessageQueue.ReportQueue.Enqueue(PrimaryMessage);
                MessageQueue.AssessorQueue.Enqueue(PrimaryMessage);
                MessageQueue.EmailQueue.Enqueue(PrimaryMessage);

                MessageQueue.ReportingSem.Release(1);
                MessageQueue.AssessorSem.Release(1);
                MessageQueue.EmailSem.Release(1);

                ReportThread.Join();
                AssessorThread.Join();
                EmailThread.Join();

                MessageQueue.ReturnQueue.Enqueue("The Global End Was Successfully Sent and Handled");
            }
            String WorkResult = "";
            bool Successful = false;
            while(!Successful)
            {
                Successful = MessageQueue.ReturnQueue.TryDequeue(out WorkResult);
            }

            #if(DEBUG)
                GetThreadInfo("All");
            #endif
            return WorkResult;
        }

        public void GetThreadInfo(String ThreadType)
        {
            if (ThreadType == "Report")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Thread: " + ReportThread.Name + "\t State:" + ReportThread.ThreadState + "\t At: " + DateTime.Now);
            }
            else if (ThreadType == "Assessor")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Thread: " + AssessorThread.Name + "\t State:" + AssessorThread.ThreadState + "\t At: " + DateTime.Now);
            }
            else if (ThreadType == "Email")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Thread: " + EmailThread.Name + "\t State:" + EmailThread.ThreadState + "\t At: " + DateTime.Now);
            }
            else if (ThreadType == "All")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Thread: " + ReportThread.Name + "\t State:" + ReportThread.ThreadState + "\t At: " + DateTime.Now);
                Console.WriteLine("Thread: " + AssessorThread.Name + "\t State:" + AssessorThread.ThreadState + "\t At: " + DateTime.Now);
                Console.WriteLine("Thread: " + EmailThread.Name + "\t State:" + EmailThread.ThreadState + "\t At: " + DateTime.Now);
            }
        }
    }
}
