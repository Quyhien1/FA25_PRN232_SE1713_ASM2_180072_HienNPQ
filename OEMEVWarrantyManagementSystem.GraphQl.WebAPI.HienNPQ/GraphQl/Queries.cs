using OEMEVWarrantyManagementSystem.Repositories.HienNPQ.ModelExtensions;
using OEMEVWarrantyManagementSystem.Repositories.HienNPQ.Models;
using OEMEVWarrantyManagementSystem.Service.HienNPQ;
using static OEMEVWarrantyManagementSystem.Repositories.HienNPQ.ModelExtensions.SearchRequest;

namespace OEMEVWarrantyManagementSystem.GraphQl.WebAPI.HienNPQ.GraphQl
{
    public class Queries
    {
        private readonly IServiceProviders _serviceProviders;
        public Queries(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders ?? throw new ArgumentNullException(nameof(serviceProviders));

        public async Task<List<BookingHienNpq>> GetBookingHienNpqs()
        {
            return await _serviceProviders.BookingHienNpqService.GetAllAsync();
        }
        public async Task<BookingHienNpq> GetBookingHienNpqs(int id)
        {
            return await _serviceProviders.BookingHienNpqService.GetByIdAsync(id);
        }
        public async Task<PaginationResult<List<BookingHienNpq>>> SearchWithPagingAsync(BookingHienNpqSearchRequest searchRequest)
        {
            return await _serviceProviders.BookingHienNpqService.SearchWithAsyncPaging(searchRequest);
        }
    }
}
