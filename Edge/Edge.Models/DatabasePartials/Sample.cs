using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge.Models.DatabaseModels
{
    [MetadataType(typeof(SampleMetadata))]
    public partial class Sample
    {

    }

    internal sealed class SampleMetadata
    {
        public int Id { get; set; }
        [Required]   // change propoerty name to request name
        public string NodeName { get; set; }
        [Required]
        public string NodeType { get; set; }
        [Required]
        public System.DateTime RequestStartTime { get; set; }
        [Required]
        public System.DateTime RequestEndTime { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
