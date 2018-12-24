using Edge.Models.DatabaseModels;
using Edge.Services.Interface;
using Edge.Services.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edge.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISampleService _sampleService;
        public HomeController()
        {
            _sampleService = new SampleService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SingleEntryStats()
        {
            return View();
        }

        public JsonResult GetStats(int id)
        {
            List<Sample> samples = new List<Sample>();

            samples = _sampleService.GetSampleAfter(id);
            if (samples.Count > 0)
            {
                samples = samples.OrderBy(x => x.Id).ToList();
            }
            return Json(samples, JsonRequestBehavior.AllowGet);
        }

        public string GetStatsForSingleEntrySearch()
        {
            List<Sample> samples = new List<Sample>();
            double totalTime = 0;
            samples = _sampleService.GetAllSample();

            foreach (var item in samples)
            {
                totalTime = totalTime + item.RequestEndTime.Subtract(item.RequestStartTime).TotalMilliseconds;
            }

            return Convert.ToString(totalTime / samples.Count);
        }
    }
}