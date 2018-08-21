using Edge.Models.DatabaseModels;
using Edge.Services.Interface;
using Edge.Services.Operations;
using NEC.Components.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace Edge.API.Controllers
{
    public class SampleController : ApiController
    {
        private ISampleService _sampleService;
        public SampleController()
        {
            _sampleService = new SampleService();
        }

        // GET api/computeHash?nodeType="Gateway"&nodeName="CentralizeNode"
        [HttpGet]
        public IEnumerable<string> ComputeHash(string nodeType, string nodeName)
        {
            DateTime requestStartTime = DateTime.Now;

            LogHelper.WriteDebugLog("ComputeHash");

            Sample sampleRequest = new Sample();
            sampleRequest.NodeName = nodeName;
            sampleRequest.NodeType = nodeType;
            sampleRequest.RequestStartTime = requestStartTime;
            sampleRequest.RequestEndTime = DateTime.Now;
            _sampleService.AddSample(sampleRequest);

            return new string[] { "Sample Result" };
        }

        
    }
}
