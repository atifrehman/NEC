using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge.Models.DatabasePartials
{
    [MetadataType(typeof(EdgeServiceMetaData))]
    public partial class EdgeService
    {

    }

    /// <summary>
    ///  class for Data Annotations 
    /// </summary>
    internal sealed class EdgeServiceMetaData
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
    }
}
