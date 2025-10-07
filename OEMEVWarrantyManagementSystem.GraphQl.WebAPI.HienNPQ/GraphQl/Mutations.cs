using OEMEVWarrantyManagementSystem.Repositories.HienNPQ.ModelExtensions;
using OEMEVWarrantyManagementSystem.Repositories.HienNPQ.Models;
using OEMEVWarrantyManagementSystem.Service.HienNPQ;
using static OEMEVWarrantyManagementSystem.Repositories.HienNPQ.ModelExtensions.SearchRequest;

namespace OEMEVWarrantyManagementSystem.GraphQl.WebAPI.HienNPQ.GraphQl
{
    public class Mutations
    {
        private readonly IServiceProviders _serviceProviders;
        public Mutations(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders;

        public async Task<int> CreateBookingHienNpq(BookingHienNpq booking)
        {
            return await _serviceProviders.BookingHienNpqService.CreateAsync(booking);
        }
        public async Task<int> UpdateBookingHienNpq(BookingHienNpq booking)
        {
            return await _serviceProviders.BookingHienNpqService.UpdateAsync(booking);
        }
        public async Task<PaginationResult<List<BookingHienNpq>>> SearchWithAsyncPaging(BookingHienNpqSearchRequest searchRequest)
        {
            return await _serviceProviders.BookingHienNpqService.SearchWithAsyncPaging(searchRequest);
        }
        public async Task<bool> DeleteBookingHienNpq(int id)
        {
            return await _serviceProviders.BookingHienNpqService.DeleteAsync(id);
        }
    }
}
