using Cloud.DataAccess.LocalStorage.Interface;
using Cloud.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Cloud.DataAccess.LocalStorage.Repository
{
    public class LoggingRepository : GenericRepository<CloudEntities, Logging>, ILoggingRepository
    {
        private static int GetLineNumber(Exception ex)
        {
            var lineNumber = 0;
            const string lineSearch = ":line ";
            var index = ex.StackTrace.LastIndexOf(lineSearch);
            if (index != -1)
            {
                var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
                if (int.TryParse(lineNumberText, out lineNumber))
                {
                }
            }
            return lineNumber;
        }

        private static string GetMethodName(Exception ex)
        {
            StackTrace stackTrace = new StackTrace(ex);
            Assembly thisasm = Assembly.GetExecutingAssembly();
            string methodname = stackTrace.GetFrames().Select(f => f.GetMethod()).First(m => m.Module.Assembly == thisasm).Name;

            return methodname;
        }
    }
}
