using Edge.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge.Services.Interface
{
    public interface IEdgeServicesService
    {
        List<EdgeService> SearchServices(string searchEntry);

        void ParalelQueriesSearch(string searchEntriesRange);

        List<EdgeService> GetAllEdgeService();

        string GetEdgeServiceFromCloud();

        List<EdgeService> GetAllEdgeService(bool isDeleted);

        EdgeService GetEdgeServiceBy(int id);

        List<EdgeService> GetEdgeServiceAfter(int id);

        void AddEdgeService(EdgeService sample);

        bool EditEdgeService(EdgeService messages);

        bool DeleteEdgeService(EdgeService sample);

        bool SoftDeleteEdgeService(EdgeService sample);

        
    }
}
