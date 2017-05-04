using AutoMapper;
using Contractors.Domain;
using Contractors.Services;
using Contractors.Shared;
using Contractors.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace Contractors.WebApp.Controllers
{
    public class ContractorController : Controller
    {
        IContractorService _contractorService;
        IMapper _mapper;

        public ContractorController(IContractorService contractorService, IMapper mapper)
        {
            Guard.ThrowIfArgumentIsNull(contractorService, nameof(contractorService));
            Guard.ThrowIfArgumentIsNull(mapper, nameof(mapper));

            _contractorService = contractorService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var contractors = _contractorService.GetContractors()
                .Select(p => new ContractorListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    City = p.Address.City
                });

            return View(contractors);
        }

        public ActionResult Details(Guid id)
        {

            var contractor = _contractorService.GetById(id);
            var viewModel = _mapper.Map<ContractorViewModel>(contractor);
            
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContractorViewModel contractorViewModel)
        {
            try
            {
                var contractor =_mapper.Map<Contractor>(contractorViewModel);
                contractor.Id = Guid.NewGuid();
                _contractorService.AddContractor(contractor);

                return RedirectToAction("Index");
            }
            catch (ContractorNotValidException ex)
            {
                // log error, for demo show in debug output
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // log error, for demo show in debug output
                Debug.WriteLine(ex.Message);
            }

            return View();
        }

        public ActionResult Edit(Guid id)
        {
            try
            {
                var contractor = _contractorService.GetById(id);
                var viewModel = _mapper.Map<ContractorViewModel>(contractor);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                // log error, for demo show in debug output
                Debug.WriteLine(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ContractorViewModel contractorViewModel)
        {
            try
            {
                Guard.ThrowIfArgumentIsNull(contractorViewModel, nameof(contractorViewModel));

                var contractor = _mapper.Map<Contractor>(contractorViewModel);
                _contractorService.UpdateContractor(contractor);

                return RedirectToAction("Index");
            }
            catch (ArgumentNullException ex)
            {
                // log error, for demo show in debug output
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // log error, for demo show in debug output
                Debug.WriteLine(ex.Message);
            }

            return View();
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                var contractor = _contractorService.GetById(id);
                var viewModel = _mapper.Map<ContractorViewModel>(contractor);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                // log error, for demo show in debug output
                Debug.WriteLine(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Guid id, ContractorViewModel contractorViewModel)
        {
            try
            {
                Guard.ThrowIfArgumentIsNull(id, nameof(id));

                var contractor = _contractorService.GetById(id);
                _contractorService.DeleteContractor(contractor);

                return RedirectToAction("Index");
            }
            catch (ArgumentNullException ex)
            {
                // log error, for demo show in debug output
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // log error, for demo show in debug output
                Debug.WriteLine(ex.Message);
            }

            return View();
        }
    }
}
