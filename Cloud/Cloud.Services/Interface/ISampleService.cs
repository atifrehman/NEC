using Cloud.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Services.Interface
{
    public interface ISampleService
    {
        List<Sample> GetAllSample();

        List<Sample> GetAllSample(bool isDeleted);

        Sample GetSampleBy(int id);

        List<Sample> GetSampleAfter(int id);

        void AddSample(Sample sample);

        bool EditSample(Sample messages);

        bool DeleteSample(Sample sample);

        bool SoftDeleteSample(Sample sample);
    }
}
