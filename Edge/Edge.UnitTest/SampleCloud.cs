using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Edge.DataAccess.Cloud.Repository;

namespace Edge.UnitTest
{
    /// <summary>
    /// Summary description for SampleCloud
    /// </summary>
    [TestClass]
    public class SampleCloud
    {
        public SampleCloud()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void TestMethod1()
        {
            SampleCloudRepository sampleCloudRepository = new SampleCloudRepository();
            sampleCloudRepository.GetResult();
        }
    }
}
