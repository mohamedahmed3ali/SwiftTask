using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Misc.SwiftTask.Domain;

namespace Nop.Plugin.Misc.SwiftTask.Service
{
    public interface ISwiftCustomerService
    {
        /// <summary>
        /// Logs the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        void Log(SwiftCustomerEntity record);
        /// <summary>
        /// Logs the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        IList<SwiftCustomerEntity> GetAllSwiftCustomers();
    }
}

namespace Nop.Plugin.Misc.SwiftTask.Service
{
    public class SwiftCustomerService : ISwiftCustomerService
    {
        private readonly IRepository<SwiftCustomerEntity> _swiftCustomerRepository;

        public SwiftCustomerService(IRepository<SwiftCustomerEntity> swiftCustomerRepository)
        {
            _swiftCustomerRepository = swiftCustomerRepository;
        }
        public async void Log(SwiftCustomerEntity record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
                await _swiftCustomerRepository.InsertAsync(record);
        }
        public IList<SwiftCustomerEntity> GetAllSwiftCustomers()
        {
            return _swiftCustomerRepository.GetAll();
        }

    }
}
