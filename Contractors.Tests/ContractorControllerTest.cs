using Contractors.DataAccess;
using Contractors.Domain;
using Contractors.Services;
using Contractors.Services.Validators;
using Contractors.Shared.Validators;
using Contractors.WebApp;
using Contractors.WebApp.Controllers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace Contractors.Tests
{
    public class ContractorControllerTest
    {
        IContractorService _service;
        IContractorRepository _repository;
        AbstractValidator<Contractor> _validator;

        public ContractorControllerTest()
        {
            _validator = new AddContractorValidator();
            _repository = new InMemoryContractorRepository();
            _service = new ContractorService(_repository, _validator);
            
        }

        [Fact]
        public void Details_ReturnsModelInViewResult_IfContractorExists()
        {
            var controller = new ContractorController(_service, AutoMapperFactory.Create());

            var id = _service.GetContractors().FirstOrDefault().Id;
            var result = controller.Details(id) as ViewResult;

            Assert.NotNull(result.Model);
        }

        [Fact]
        public void Details_ReturnsNoModelInViewResult_IfContractorNotExists()
        {
            var controller = new ContractorController(_service, AutoMapperFactory.Create());

            var result = controller.Details(Guid.NewGuid()) as ViewResult;

            Assert.Null(result.Model);
        }
    }
}
