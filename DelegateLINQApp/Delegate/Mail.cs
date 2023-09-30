using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLINQApp.Delegate
{
    internal class MailEventArgs : EventArgs
    {
        public string Content { get; }

        public MailEventArgs(string content)
        {
            Content = content;
        }
    }
}
