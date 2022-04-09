using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCStore.Core.Contracts;
using PCStore.Core.Models.Device;
using PCStore.Infrastrucure.Data;

namespace PCStore.Controllers
{
    public class DisplayController : Controller
    {
        private readonly IDisplayService displayService;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public DisplayController(IMapper _mapper,
            IUsersService _usersService,
            IDisplayService _displayService)
        {
            mapper = _mapper;
            usersService = _usersService;
            displayService = _displayService;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult AddDisplay()
        {
            ViewData["Title"] = "Create Display Advertisement";
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddDisplay(Display model)
        {
            var user = usersService.GetAll().Single();

            model.CreatedOn = DateTime.Now;
            model.Seller = user;
            displayService.Add(model);

            return RedirectToAction("Index", "Manage");
        }

        // Update Display \\
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult UpdateDisplay(Guid id)
        {
            ViewData["Title"] = "Update Display Advertisement";

            var display = displayService
                .GetAll()
                .ProjectTo<DisplayViewModel>()
                .Single(x => x.Id == id);

            return View(display);
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDisplay(Display model)
        {
            displayService.Update(model);

            return RedirectToAction("Index", "Manage");
        }
    }
}
