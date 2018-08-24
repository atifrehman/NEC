using Edge.DataAccess.Cloud.ApiAccess;
using Edge.DataAccess.Cloud.Interface;
using Edge.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge.DataAccess.Cloud.Repository
{
    public class SampleCloudRepository : ISampleCloudRepository
    {
        public string GetResult()
        {
            string result = string.Empty;
            CloudAccess<string> cloudAccess = new CloudAccess<string>();
            result = cloudAccess.GetSingleString("samplecloud/GetResult").Result;
            return result;
        }
    }
}
