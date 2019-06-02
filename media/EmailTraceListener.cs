using NFOPP.Tersus.Shell.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFOPP.Tersus.Shell.Helpers.Trace_Listeners
{
    public class EmailTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            throw new NotImplementedException();
        }

        public override void WriteLine(string message)
        {
            throw new NotImplementedException();
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            //base.TraceData(eventCache, source, eventType, id, data);

            if (data is Exception)
            {
                Exception e = data as Exception;
                var vm = new BugReportViewModel { Description = e.Message, ExceptionDetail = e };
                
                if (vm.PostErrorCommand.CanExecute(null))
                {
                    vm.PostErrorCommand.Execute(null);
                }
            }
        }
    }
}
