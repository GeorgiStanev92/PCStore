using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCStore.Core.Contracts;
using PCStore.Core.Models;
using PCStore.Core.Models.Device;
using PCStore.Infrastrucure.Data;

namespace PCStore.Controllers
{
    public class LaptopController : Controller
    {
        private readonly ILaptopService laptopService;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public LaptopController(IMapper _mapper,
            IUsersService _usersService,
            ILaptopService _laptopService)
        {
            mapper = _mapper;
            usersService = _usersService;
            laptopService = _laptopService;
        }

        [HttpGet]
        public ActionResult Laptops(int? page)
        {
            ViewData["Title"] = "Laptops";

            var laptops = laptopService
               .GetAll()
               .OrderByDescending(x => x.ModifiedOn)
               .ProjectTo<LaptopViewModel>()
               .ToList();

            var viewModel = new DevicesViewModel()
            {
                Laptops = laptops
            };

            return View(viewModel.Laptops);
        }

        [HttpGet]
        public ActionResult Laptop(Guid Id)
        {
            ViewData["Title"] = "Laptop";

            var laptop = laptopService
                 .GetAll()
                 .ProjectTo<LaptopViewModel>()
                 .Single(x => x.Id == Id);

            return View(laptop);
        }

        // Add Laptop \\
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult AddLaptop()
        {
            ViewData["Title"] = "Create Laptop Advertisement";
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddLaptop(Laptop model)
        {
            var user = usersService.GetAll().Single();

            model.CreatedOn = DateTime.Now;
            model.Seller = user;
            this.laptopService.Add(model);

            return RedirectToAction("Index", "Manage");
        }

        // Update Laptop \\
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult UpdateLaptop(Guid id)
        {
            ViewData["Title"] = "Update Laptop Advertisement";

            var laptop = laptopService
                .GetAll()
                .ProjectTo<LaptopViewModel>()
                .Single(x => x.Id == id);

            return View(laptop);
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateLaptop(Laptop model)
        {
            laptopService.Update(model);

            return RedirectToAction("Index", "Manage");
        }
    }
}
