using Microsoft.AspNetCore.Mvc;
using ShopTARge22.ApplicationServices.Services;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using ShopTARge22.Data.Migrations;
using ShopTARge22.Models.Kindergartens;

namespace ShopTARge22.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly ShopTARge22Context _context;
        private readonly IKindergartensServices _kindergartensServices;

        public KindergartensController
            (
                ShopTARge22Context context,
                IKindergartensServices kindergartens
            )
        {
            _context = context;
            _kindergartensServices = kindergartens;
        }


        [HttpGet]


        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new KindergartenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                    Teacher = x.Teacher
                });

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarten = await _kindergartensServices.DetailsAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KindergartenDetailsViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            KindergartenCreateUpdateViewModel vm = new();

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                Teacher = vm.Teacher,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _kindergartensServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarten = await _kindergartensServices.DetailsAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KindergartenCreateUpdateViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;


            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto();

            dto.Id = vm.Id;
            dto.GroupName = vm.GroupName;
            dto.ChildrenCount = vm.ChildrenCount;
            dto.KindergartenName = vm.KindergartenName;
            dto.Teacher = vm.Teacher;
            dto.CreatedAt = vm.CreatedAt;
            dto.UpdatedAt = vm.UpdatedAt;

            var result = await _kindergartensServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarten = await _kindergartensServices.DetailsAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KindergartenDeleteViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergartenId = await _kindergartensServices.Delete(id);

            if (kindergartenId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
       
