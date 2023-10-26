using Microsoft.AspNetCore.Mvc;
using ShopTARge22.ApplicationServices.Services;
using ShopTARge22.Core.Dto.ChuckNorrisDtos;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models.ChuckNorris;

namespace ShopTARge22.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;

        public ChuckNorrisController
            (IChuckNorrisServices chuckNorrisServices
        )

        {
            _chuckNorrisServices = chuckNorrisServices;
        }



        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        //* [HttpPost]
        //public IActionResult SearchChuckNorrisJoke(SearchJokeViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("Categories", "JakeNorris", new { categories = model.SearchJokeViewModel });
        //    }

        //    return View(model);
        //}
        //

        [HttpGet]
        public IActionResult ChuckNorrisJoke()
        {
            OpenChuckNorrisResultDto dto = new();


            _chuckNorrisServices.ChuckNorrisRandomJokes(dto);
            OpenChuckNorrisViewModel vm = new();


            vm.Categories = dto.Categories;
            vm.Created_At = dto.Created_At;
            vm.Icon_url = dto.Icon_url;
            vm.Id = dto.Id;
            vm.Updated_At = dto.Updated_At;
            vm.Url = dto.Url;
            vm.Value = dto.Value;


            return View(vm);
        }
    }
}
