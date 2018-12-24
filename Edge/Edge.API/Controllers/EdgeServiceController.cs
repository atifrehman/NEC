using Edge.Models.DatabaseModels;
using Edge.Services.Interface;
using Edge.Services.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edge.API.Controllers
{
    public class EdgeServiceController : ApiController
    {
        private IEdgeServicesService _edgeService;
        private ISampleService _sampleService;
        public EdgeServiceController()
        {
            _edgeService = new EdgeServicesService();
            _sampleService = new SampleService();
        }


        [HttpGet]
        public IEnumerable<string> SingleQuery(string searchEntry, int parallelUsers = 1)
        {
            DateTime requestStartTime = DateTime.Now;

            _edgeService.SearchServices(searchEntry);

            Sample sampleRequest = new Sample();
            sampleRequest.NodeName = "SingleQuerySearch" + parallelUsers;
            sampleRequest.NodeType = "ndnSIMGateWayNode";
            sampleRequest.RequestStartTime = requestStartTime;
            sampleRequest.RequestEndTime = DateTime.Now;
            _sampleService.AddSample(sampleRequest);
            return new string[] { "Search Result Time: " + sampleRequest.RequestEndTime.Subtract(requestStartTime).TotalMilliseconds.ToString() };
        }

        [HttpGet]
        public IEnumerable<string> ParalelQueriesSearch(string searchEntriesRange)
        {
            DateTime requestStartTime = DateTime.Now;

            _edgeService.ParalelQueriesSearch(searchEntriesRange);

            Sample sampleRequest = new Sample();
            sampleRequest.NodeName = "ParalelQueriesSearch";
            sampleRequest.NodeType = "ndnSIMGateWayNode";
            sampleRequest.RequestStartTime = requestStartTime;
            sampleRequest.RequestEndTime = DateTime.Now;
            _sampleService.AddSample(sampleRequest);
            return new string[] { "Search Result Time: " + sampleRequest.RequestEndTime.Subtract(requestStartTime).TotalMilliseconds.ToString() };
        }
    }
}
