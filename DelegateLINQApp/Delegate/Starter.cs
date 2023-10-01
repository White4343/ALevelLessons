using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLINQApp.Delegate
{
    internal class Starter
    {
        public static void Run()
        {
            PostOffice postOffice = new PostOffice();

            Subscriber subscriber1 = new Subscriber("Sub1");
            Subscriber subscriber2 = new Subscriber("Sub2");

            postOffice.NewMailArrived += subscriber1.HandleNewMail;
            postOffice.NewMailArrived += subscriber2.HandleNewMail;

            postOffice.MailArrived("New mail");

            postOffice.NewMailArrived -= subscriber2.HandleNewMail;

            postOffice.MailArrived("Attention");

        }
    }
}
