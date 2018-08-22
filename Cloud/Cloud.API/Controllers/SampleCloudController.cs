using Cloud.Components.Helpers;
using Cloud.Models.DatabaseModels;
using Cloud.Services.Interface;
using Cloud.Services.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cloud.API.Controllers
{
    public class SampleCloudController : ApiController
    {
        private ISampleService _sampleService;
        public SampleCloudController()
        {
            _sampleService = new SampleService();
        }

        // GET api/computeHash?nodeType="Gateway"&nodeName="CentralizeNode"
        [HttpGet]
        public IEnumerable<string> GetResult()
        {
            DateTime requestStartTime = DateTime.Now;

            LogHelper.WriteDebugLog("ComputeHash");

            Sample sampleRequest = new Sample();
            sampleRequest.NodeName = "Edge";
            sampleRequest.NodeType = "NDN";
            sampleRequest.RequestStartTime = requestStartTime;
            sampleRequest.RequestEndTime = DateTime.Now;
            _sampleService.AddSample(sampleRequest);

            return new string[] { "Sample Result from cloud" };
        }


    }
}
