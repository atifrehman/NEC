using Edge.DataAccess.LocalStorage.Interface;
using Edge.DataAccess.LocalStorage.Repository;
using Edge.Models.DatabaseModels;
using Edge.Services.Interface;
using NEC.Components.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge.Services.Operations
{
    public class EdgeServicesService : IEdgeServicesService
    {
        IEdgeServiceRepository _edgeServiceRepository;
        //IEdgeServiceCloudRepository _sampleCloudRepository;
        public EdgeServicesService()
        {
            _edgeServiceRepository = new EdgeServiceRepository();
            //_sampleCloudRepository = new EdgeServiceCloudRepository();
        }

        #region EdgeService

        #region Get

        public string GetEdgeServiceFromCloud()
        {
            try
            {
                return string.Empty;/*_sampleCloudRepository.GetResult();*/
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }
        public List<EdgeService> SearchServices(string searchEntry)
        {
            try
            {
                return _edgeServiceRepository.GetBy(x => x.ServiceName.Contains(searchEntry));
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }
        public void ParalelQueriesSearch(string searchEntriesRange)
        {
            try
            {
                int start = Convert.ToInt32(searchEntriesRange.Split('-')[0]);
                int end = Convert.ToInt32(searchEntriesRange.Split('-')[1]);
                for (int i = start; i < end; i++)
                {
                    string searchEntry = "EdgeService-" + i;
                    _edgeServiceRepository.GetBy(x => x.ServiceName.Contains(searchEntry));
                }

            }
            catch (Exception ex)
            {

            }
        }
        public List<EdgeService> GetAllEdgeService()
        {
            try
            {
                return _edgeServiceRepository.GetAll();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }
        public List<EdgeService> GetAllEdgeService(bool isDeleted)
        {
            try
            {
                return _edgeServiceRepository.GetAll();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }

        public EdgeService GetEdgeServiceBy(int id)
        {
            try
            {
                return _edgeServiceRepository.GetBy(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }

        public List<EdgeService> GetEdgeServiceAfter(int id)
        {
            try
            {
                return _edgeServiceRepository.GetBy(x => x.Id > id).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }

        #endregion

        #region Add

        public void AddEdgeService(EdgeService sample)
        {
            try
            {
                //sample.CreatedDate = DateTime.UtcNow;
                _edgeServiceRepository.Add(sample);
                _edgeServiceRepository.Save();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
            }
        }


        #endregion

        #region Edit

        public bool EditEdgeService(EdgeService sample)
        {
            try
            {
                //sample.UpdatedDate = DateTime.UtcNow;
                _edgeServiceRepository.Edit(sample);
                _edgeServiceRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return false;
            }
        }

        #endregion

        #region Delete

        public bool DeleteEdgeService(EdgeService sample)
        {
            try
            {
                _edgeServiceRepository.Delete(sample);
                _edgeServiceRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return false;
            }
        }

        public bool SoftDeleteEdgeService(EdgeService sample)
        {
            try
            {
                //sample.IsDeleted = true;
                EditEdgeService(sample);

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return false;
            }
        }

       





        #endregion

        #endregion
    }
}
