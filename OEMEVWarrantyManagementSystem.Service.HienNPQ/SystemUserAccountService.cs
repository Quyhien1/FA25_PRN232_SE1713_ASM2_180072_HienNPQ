using OEMEVWarrantyManagementSystem.Repositories.HienNPQ;
using OEMEVWarrantyManagementSystem.Repositories.HienNPQ.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace OEMEVWarrantyManagementSystem.Service.HienNPQ
{
    public class SystemUserAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SystemUserAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public SystemUserAccountService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            try
            {
                return await _unitOfWork.SystemUserAccountRepository.GetUserAccount(username, password);
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}