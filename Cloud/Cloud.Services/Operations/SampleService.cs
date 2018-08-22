using Cloud.Components.Helpers;
using Cloud.DataAccess.LocalStorage.Interface;
using Cloud.DataAccess.LocalStorage.Repository;
using Cloud.Models.DatabaseModels;
using Cloud.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Services.Operations
{
    public class SampleService:ISampleService
    {
        ISampleRepository _sampleRepository;
        public SampleService()
        {
            _sampleRepository = new SampleRepository();
        }

        #region Sample

        #region Get

        public List<Sample> GetAllSample()
        {
            try
            {
                return _sampleRepository.GetAll();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }
        public List<Sample> GetAllSample(bool isDeleted)
        {
            try
            {
                return _sampleRepository.GetBy(x => x.IsDeleted == isDeleted);
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }

        public Sample GetSampleBy(int id)
        {
            try
            {
                return _sampleRepository.GetBy(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }

        public List<Sample> GetSampleAfter(int id)
        {
            try
            {
                return _sampleRepository.GetBy(x => x.Id > id).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }

        #endregion

        #region Add

        public void AddSample(Sample sample)
        {
            try
            {
                sample.CreatedDate = DateTime.UtcNow;
                _sampleRepository.Add(sample);
                _sampleRepository.Save();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
            }
        }


        #endregion

        #region Edit

        public bool EditSample(Sample sample)
        {
            try
            {
                sample.UpdatedDate = DateTime.UtcNow;
                _sampleRepository.Edit(sample);
                _sampleRepository.Save();

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

        public bool DeleteSample(Sample sample)
        {
            try
            {
                _sampleRepository.Delete(sample);
                _sampleRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return false;
            }
        }

        public bool SoftDeleteSample(Sample sample)
        {
            try
            {
                sample.IsDeleted = true;
                EditSample(sample);

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
