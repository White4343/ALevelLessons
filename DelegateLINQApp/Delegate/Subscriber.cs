using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLINQApp.Delegate
{
    internal class Subscriber
    {
        private string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void HandleNewMail(object sender, MailEventArgs e)
        {
            Console.WriteLine($"{name} got new mail with this content: {e.Content}");
        }
    }
}
