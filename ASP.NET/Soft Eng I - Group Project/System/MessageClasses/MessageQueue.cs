using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuditSystem.MessageClasses
{
    static class MessageQueue
    {
        public static Queue<MessageEnums.MessageType> ReportQueue = new Queue<MessageEnums.MessageType>();
        public static Queue<MessageEnums.MessageType> AssessorQueue = new Queue<MessageEnums.MessageType>();
        public static Queue<MessageEnums.MessageType> EmailQueue = new Queue<MessageEnums.MessageType>();

        public static ConcurrentQueue<String> ReturnQueue = new ConcurrentQueue<String>();

        public static Semaphore ReportingSem = new Semaphore(0, 1);
        public static Semaphore AssessorSem = new Semaphore(0, 1);
        public static Semaphore EmailSem = new Semaphore(0, 1);
    }
}
