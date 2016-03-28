using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

using AopAlliance.Intercept;

namespace AOP.Advice
{
    public class TraceAroundAdvice : IMethodInterceptor
    {
        private FileStream _stream = null;
        private TextWriterTraceListener _listener = null;

        public TraceAroundAdvice()
        {
            _stream = File.Open(@"C:\temp\Logs.txt", FileMode.Append);
            _listener = new TextWriterTraceListener(_stream);
            Trace.Listeners.Add(_listener);
        }

        public object Invoke(IMethodInvocation invocation)
        {
            // Write "begin" trace message
            string message = string.Format("[{0}] Begin method call {1}", DateTime.Now.ToString("M/dd/yy hh:m:ss"),invocation.Method.Name);
            Trace.WriteLine(message);
            Trace.Flush();

            // Call the actual method
            object returnValue = invocation.Proceed();

            // Write "end" trace message
            message = string.Format("[{0}] Completed method call {1}", DateTime.Now.ToString("M/dd/yy hh:m:ss"), invocation.Method.Name);
            Trace.WriteLine(message);
            Trace.Flush();

            // return the result
            return returnValue;
        }
    }
}