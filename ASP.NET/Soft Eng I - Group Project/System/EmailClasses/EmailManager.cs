using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AuditSystem.MessageClasses;

namespace AuditSystem.EmailClasses
{
    class EmailManager
    {
        public MessageEnums.MessageType CurrentMessage;
        public EmailManager()
        {
            CurrentMessage = MessageEnums.MessageType.START;
        }

        public void WaitLoop()
        {
            while (CurrentMessage != MessageEnums.MessageType.END)
            {
                MessageQueue.EmailSem.WaitOne();

                CurrentMessage = MessageQueue.EmailQueue.Dequeue();
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
            else if (Message == MessageEnums.MessageType.MASS_EMAIL)
            {
                RunMassEmail();
            }
            else if (Message == MessageEnums.MessageType.SPECIFIC_EMAIL)
            {
                RunSpecificEmail();
            }
        }

        public void RunMassEmail()
        {
            //String MassEmailResults = DalSystem.EmailAccounts.GetAll()
            String MassEmailResults = "DalSystem.EmailAccounts.GetAll();";
            SendFeedback(MassEmailResults);
        }

        public void RunSpecificEmail()
        {
            //String SpecificEmailResults = DalSystem.EmailAccounts.GetSpecific()
            String SpecificEmailResults = "DalSystem.EmailAccounts.GetSpecific();";
            SendFeedback(SpecificEmailResults);
        }

        public void SendFeedback(String Output)
        {
            MessageQueue.ReturnQueue.Enqueue(Output);
        }

    }
}
