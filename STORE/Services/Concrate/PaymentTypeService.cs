using STORE.DATA.Repository.Abstract;
using STORE.DTOs;
using STORE.Services.Abstract;
using STORE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        public PaymentTypeService(IUnitOfWork unitOfWork)
        {
            _paymentTypeRepository = unitOfWork.PaymentTypies;
            _unitOfWork = unitOfWork;
        }

        public async Task DeletePaymentTypeAsync(int paymentTypeId)
        {
            await _paymentTypeRepository.DeleteAsync(paymentTypeId).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
        }

        public async Task<List<PaymentTypeDTO>> GetAllPaymentTypeAsync()
        {
            var paymentTypies = await _paymentTypeRepository.GetAllAsync().ConfigureAwait(false);

            var paymentTypeDTO = paymentTypies != null ?
                (from p in paymentTypies
                 select new PaymentTypeDTO
                 {
                     Id = p.Id,
                     InsertedDate = p.InsertedDate,
                     Name = p.Name
                 }
                 ).ToList() : null;

            return paymentTypeDTO;
        }
    }
}
