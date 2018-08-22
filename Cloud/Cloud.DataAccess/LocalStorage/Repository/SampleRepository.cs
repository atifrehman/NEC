using Cloud.DataAccess.LocalStorage.Interface;
using Cloud.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.DataAccess.LocalStorage.Repository
{
    public class SampleRepository : GenericRepository<CloudEntities, Sample>, ISampleRepository
    {

    }
}
