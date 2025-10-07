using GraphQL.Client.Abstractions;
using OEMEVWarrantyManagementSystem.BlazorWebApp.HienNPQ.Models;

namespace OEMEVWarrantyManagementSystem.BlazorWebApp.HienNPQ.GraphQLClient
{
    public class GraphQLConsumer
    {
        private readonly IGraphQLClient _graphQLClient;
        public GraphQLConsumer(IGraphQLClient graphQLClient)
        {
            _graphQLClient = graphQLClient;
        }
        public async Task<List<BookingHienNpq>> GetBookingHienNpqs()
        {
            try
            {
                var query = @"
                    query {
                        bookings {
                            bookingHienNpqid
                            stationName
                            batteryCapacity
                            startTime
                            endTime
                            supportInfoHienNpq {
                                supportInfoHienNpqId
                                licensePlate
                                customerName
                                contactNumber
                            }
                        }
                    }";
                var response = await _graphQLClient.SendQueryAsync<BookingHienNpqsGraphQLResponse>(query);
                var result = response?.Data?.BookingHienNpq;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetBookingHienNpqs: {ex.Message}", ex);
            }
            return new List<BookingHienNpq>();
        }
    }
}
