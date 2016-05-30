using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AuditSystem.MessageClasses;
namespace AuditSystem.AssessorClasses
{
    class AssessorManager
    {
        public MessageEnums.MessageType CurrentMessage;
        public AssessorManager()
        {
            CurrentMessage = MessageEnums.MessageType.START;
        }

        public void WaitLoop()
        {
            while (CurrentMessage != MessageEnums.MessageType.END)
            {
                MessageQueue.AssessorSem.WaitOne();

                CurrentMessage = MessageQueue.AssessorQueue.Dequeue();
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
            else if (Message == MessageEnums.MessageType.STANDARD_ASSESSMENT)
            {
                RunStandardAssessment();
            }
            else if (Message == MessageEnums.MessageType.SPECIALIZED_ASSESSMENT)
            {
                RunSpecializedAssessment();
            }
        }

        public void RunStandardAssessment()
        {
            //String StandardAssessmentResults = DalAudits.StandardAssessment.GetAssessmentData()
            String StandardAssessmentResults = "DalAudits.StandardAssessment.GetAssessmentData();";
            SendFeedback(StandardAssessmentResults);
        }

        public void RunSpecializedAssessment()
        {
            //String SpecializedAssessmentResults = DalAudits.SpecializedAssessment.GetAssessmentData()
            String SpecializedAssessmentResults = "DalAudits.SpecializedAssessment.GetAssessmentData();";
            SendFeedback(SpecializedAssessmentResults);
        }

        public void SendFeedback(String Output)
        {
            MessageQueue.ReturnQueue.Enqueue(Output);
        }

    }
}
