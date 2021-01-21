using STORE.DATA.Repository.Abstract;
using STORE.DTOs;
using STORE.ENTITY.Entities;
using STORE.EXCEPTION;
using STORE.Services.Abstract;
using STORE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
    public class CompanyService: ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _companyRepository = unitOfWork.Company;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyDTO> AddProductCategoryAsync(CompanyDTO companyDTO)
        {
            if (companyDTO == null)
                throw new StoreApiException("Eksik yada hatalı bir bilgi girdiniz");
            var company = new Company
            {
                Address = companyDTO.Address,
                Id = companyDTO.Id,
                InsertedDate = companyDTO.InsertedDate,
                Name = companyDTO.Name,
                Number = companyDTO.Number
            };

            await _companyRepository.AddAsync(company).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return companyDTO;
        }

        public async Task<List<CompanyDTO>> GetAllProductCategoryAsync()
        {
           
            var company = await _companyRepository.GetAllAsync().ConfigureAwait(false);
            if (company == null)
                throw new StoreApiException("Kayıtlı hiçbir şirket bulunamadı");
            var companyDTOs = company != null ?
                (from c in company
                 select new CompanyDTO
                 {
                     Address = c.Address,
                     Id = c.Id,
                     InsertedDate = c.InsertedDate,
                     Name = c.Name,
                     Number = c.Number 
                 }
                ).ToList() : null;
            return companyDTOs;
        }

        public async Task<CompanyDTO> UpdateCategoryAsync(CompanyDTO companyDTO)
        {
            
            var companies = await _companyRepository.GetByIdAsync(companyDTO.Id).ConfigureAwait(false);

            if (companies == null)
                throw new StoreApiException("Güncellenmek istenen şirket bulunamadı");
            companies.Name = companyDTO.Name;
            companies.Number = companyDTO.Number;
            companies.Address = companyDTO.Address;
            _companyRepository.Update(companies);

            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return companyDTO;
        }
    }
}
