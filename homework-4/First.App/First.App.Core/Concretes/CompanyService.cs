﻿using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace First.App.Business.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> repository;
        private readonly IUnitOfWork unitOfWork;
        public CompanyService(IRepository<Company> repository, IUnitOfWork unitOfWork)
        {
          this.repository = repository;
          this.unitOfWork = unitOfWork;
        }

        public Company getCompany(CompanyDto companyDto)
        {
           return repository.Get().Where(c=>c.Name==companyDto.Name && c.Phone==companyDto.Phone).First();
        }

        public void AddCompany(Company company)
        {
            repository.Add(company);
            unitOfWork.Commit();
        }

        public void UpdateCompany(Company company)
        {
            repository.Update(company);
            unitOfWork.Commit();
        }

        public void DeleteCompany(Company company)
        {
            repository.Delete(company);
            unitOfWork.Commit();
        }

        public List<Company> GetAllCompany()
        {
            return repository.Get().ToList();
        }
    }
}
