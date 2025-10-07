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

        [GraphQLName("bookings")]
        public async Task<List<BookingHienNpq>> GetBookingsAsync()
        {
            return await _serviceProviders.BookingHienNpqService.GetAllAsync();
        }

        [GraphQLName("bookingById")]
        public async Task<BookingHienNpq> GetBookingByIdAsync(int id)
        {
            return await _serviceProviders.BookingHienNpqService.GetByIdAsync(id);
        }

        [GraphQLName("searchBookings")]
        public async Task<PaginationResult<List<BookingHienNpq>>> SearchBookingsAsync(BookingHienNpqSearchRequest searchRequest)
        {
            return await _serviceProviders.BookingHienNpqService.SearchWithAsyncPaging(searchRequest);
        }
    }
}
