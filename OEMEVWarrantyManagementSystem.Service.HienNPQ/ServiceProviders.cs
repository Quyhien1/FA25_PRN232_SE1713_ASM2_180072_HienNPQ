using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEMEVWarrantyManagementSystem.Service.HienNPQ
{
    public interface IServiceProviders
    {
        SystemUserAccountService SystemUserAccountService { get; }
        IBookingHienNpqService BookingHienNpqService { get; }
        SupportInfoHienNpqService SupportInfoHienNpqService { get; }

    }
    public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService _systemUserAccountService;
        private IBookingHienNpqService _bookingHienNpqService;
        private SupportInfoHienNpqService _supportInfoHienNpqService;

        public SystemUserAccountService SystemUserAccountService
        { get { return _systemUserAccountService ??= new SystemUserAccountService(); } 
        }
        public IBookingHienNpqService BookingHienNpqService
        { get { return _bookingHienNpqService ??= new BookingHienNpqService(); }
        }
        public SupportInfoHienNpqService SupportInfoHienNpqService
        { get { return _supportInfoHienNpqService ??= new SupportInfoHienNpqService(); }
        }
    }

}
