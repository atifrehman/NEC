using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge.Models.DatabaseModels
{
    [MetadataType(typeof(LoggingMetadata))]
    public partial class Logging
    {

    }

    internal sealed class LoggingMetadata
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public string Message { get; set; }
        public Nullable<int> LineNumber { get; set; }
        public string MethodName { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerExceptionMessage { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
