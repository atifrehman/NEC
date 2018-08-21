using Edge.DataAccess.LocalStorage.Interface;
using Edge.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge.DataAccess.LocalStorage.Repository
{
    public class SampleRepository : GenericRepository<EdgeEntities, Sample>, ISampleRepository
    {

    }
}
