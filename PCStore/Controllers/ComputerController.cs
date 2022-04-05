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
    public class ComputerController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUsersService usersService;
        private readonly IComputerService computersService;

        public ComputerController(IMapper _mapper, 
            IUsersService _usersService,
            IComputerService _computersService)
        {
            mapper = _mapper;
            usersService = _usersService;
            computersService = _computersService;
        }

        [HttpGet]
        public ActionResult Computers(int? page)
        {
            ViewData["Title"] = "Computers";

            var computers = this.computersService
                .GetAll()
                .OrderByDescending(x => x.DateFrom)
                .ProjectTo<ComputerViewModel>()
                .ToList();

            var viewModel = new DevicesViewModel()
            {
                Computers = computers
            };

            return View(viewModel.Computers);
        }

        [HttpGet]
        public ActionResult Computer(Guid Id)
        {
            ViewData["Title"] = "Computer";

            var computer = this.computersService
                .GetAll()
                .ProjectTo<ComputerViewModel>()
                .Single(x => x.Id == Id);

            return View(computer);
        }

        // Add Computer \\
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult AddComputer()
        {
            ViewData["Title"] = "Create Computer Advertisement";
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddComputer(Computer model)
        {

            var user = usersService.GetAll().Single();

            model.DateFrom = DateTime.Now;
            model.Seller = user;
            this.computersService.Add(model);

            return RedirectToAction("Index", "Manage");
        }

        // Update Computer \\
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult UpdateComputer(Guid id)
        {
            ViewData["Title"] = "Update Computer Advertisement";

            var computer = this.computersService
                .GetAll()
                .ProjectTo<ComputerViewModel>()
                .Single(x => x.Id == id);

            return View(computer);
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateComputer(Computer model)
        {
            this.computersService.Update(model);

            return RedirectToAction("Index", "Manage");
        }
    }
}
