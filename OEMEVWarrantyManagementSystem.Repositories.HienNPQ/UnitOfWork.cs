using OEMEVWarrantyManagementSystem.Repositories.HienNPQ.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEMEVWarrantyManagementSystem.Repositories.HienNPQ
{
    public interface IUnitOfWork
    {
        SystemUserAccountRepository SystemUserAccountRepository { get; }
        SupportInfoHienNpqRepository SupportInfoHienNpqRepository { get; }
        BookingHienNpqRepository BookingHienNpqRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {   
        private readonly FA25_PRN232_SE1713_G5_OEMEVWarrantyManagementSystemContext _context;
        private SystemUserAccountRepository _systemUserAccountRepository;
        private BookingHienNpqRepository _bookingHienNpqRepository;
        private SupportInfoHienNpqRepository _supportInfoHienNpqRepository;
        public UnitOfWork() => _context = new FA25_PRN232_SE1713_G5_OEMEVWarrantyManagementSystemContext();
        public SystemUserAccountRepository SystemUserAccountRepository
        {
            get
            {
                return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context);
            }
        }
        public BookingHienNpqRepository BookingHienNpqRepository
        {
            get
            {
                return _bookingHienNpqRepository ??= new BookingHienNpqRepository(_context);
            }
        }
        public SupportInfoHienNpqRepository SupportInfoHienNpqRepository
        {
            get
            {
                return _supportInfoHienNpqRepository ??= new SupportInfoHienNpqRepository(_context);
            }
        }
        public int SaveChanges()
        {
            int result = 0;
            using (var dbContextTransaction = _context.Database.BeginTransaction())

            {
                try

                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    result = 0;
                    dbContextTransaction.Rollback();

                }
                return result;


            }
        }
        public async Task<int> SaveChangesAsync()
        {
            int result = 0;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
                try
                {
                    result = await _context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception)
                {
                    result = 0;
                    dbContextTransaction.Rollback();
                }
            return result;
        }
    }
}
