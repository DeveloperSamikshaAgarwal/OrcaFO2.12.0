using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLoggerProvider
{
    public abstract class LogBase
    {
        public abstract void Information(string message);
        public abstract void Error(string message);
    }
}
