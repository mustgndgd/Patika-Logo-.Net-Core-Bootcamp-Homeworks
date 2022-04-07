using System;
using First.API.Filters;
using First.API.Models;
using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace First.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        //[HttpGet]
        //[ServiceFilter(typeof(ActionFilterExample))]
        //public IActionResult GetData()
        //{
        //    return Ok(new { data = "Veriler Yüklendi"});
        //}

        [HttpGet]
        [Log]
        public IActionResult Log()
        {
            return NoContent();
        }

        /// <summary>
        /// Tüm şirket bilgilerini getirir.
        /// </summary>
        /// <returns></returns>
        [Route("Compaines")]
        [HttpGet]
        public IActionResult Get()
        {
            var companies = companyService.GetAllCompany().Select(x=> new CompanyDto
            {
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Country = x.Country,
                Description = x.Description,
                Location = x.Location,
                Phone = x.Phone               
            });
            return Ok(new CompanyResponse { Data = companies, Success = true });
        }

        /// <summary>
        /// Şirket ekleme işlemi yapar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("AddCompany")]
        [HttpPost]
        public IActionResult Post([FromBody] CompanyDto model)
        {
            companyService.AddCompany(new Company
            {
                Address = model.Address,
                City = model.City,
                Description = model.Description,
                CreatedBy = "SAMET",
                CreatedAt = System.DateTime.Now,
                IsDeleted = false,
                Name = model.Name.ToUpper(),
                Country = model.Country,
                Phone = model.Phone,
                Location = model.Location,
            });
            return Ok(
                new CompanyResponse
                {
                    Data = "İşleminiz Başarıyla Tamamlandı",
                    Success = true
                });
        }

        [Route("UpdateCompany")]
        [HttpPost]
        public IActionResult UpdateCompany([FromBody] CompanyDto model)
        {
            try
            {
                companyService.UpdateCompany(new Company
                {
                    Name=model.Name,
                    Description =model.Description,
                    Address  =model.Address,
                    City =model.City,
                    Country  =model.Country,
                    Location  =model.Location,
                    Phone=model.Phone
                });
                return Accepted(new CompanyResponse
                {
                    Data="Güncelleme başarılı!",
                    Success = true
                });
            }
            catch (Exception e)
            {
                return Ok(new CompanyResponse
                {
                    Data = "İşlem başarısız",
                    Success = false,
                    Error = e.Message
                });
            }
        }


        [Route("DeleteCompany")]
        [HttpPost]
        public IActionResult DeleteCompany([FromBody] CompanyDto model)
        {
            try
            {
                companyService.DeleteCompany(companyService.getCompany(model));
                return Accepted(new CompanyResponse
                {
                    Data = "Silme başarılı!",
                    Success = true
                });
            }
            catch (Exception e)
            {
                return Ok(new CompanyResponse
                {
                    Data = "Silme işlemi başarısız",
                    Success = false,
                    Error = e.Message
                });
            }
        }


    }
}
