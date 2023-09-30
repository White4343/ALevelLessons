using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLINQApp.Delegate
{
    internal class PostOffice
    {
        public delegate void NewMailHandler(object sender, MailEventArgs e);

        public event NewMailHandler NewMailArrived;

        public void MailArrived(string mailContent)
        {
            Console.WriteLine($"New mail: {mailContent}");

            if (NewMailArrived != null)
            {
                NewMailArrived(this, new MailEventArgs(mailContent));
            }
        }
    }
}
