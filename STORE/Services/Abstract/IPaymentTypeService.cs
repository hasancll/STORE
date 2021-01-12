using STORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IPaymentTypeService
    {
        Task<List<PaymentTypeDTO>> GetAllPaymentTypeAsync();
        Task DeletePaymentTypeAsync(int paymentTypeId);
    }
}
