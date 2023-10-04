using Microsoft.AspNetCore.Mvc;
using SandstoneStore.Models;
using SandstoneStore.Models.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace SandstoneStore.Controllers
{
    public class HomeController : Controller
    {
        private IDatabaseRepository repository;
        public int size = 5;

        public HomeController(IDatabaseRepository repo)
        {
            repository = repo;
        }

        //public IActionResult Index() => View(repository.Products);

        public ViewResult Index(string category, int productPage = 1)
            => View(new ProductListViewModel {

                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip(
                    (productPage - 1) * size)
                        .Take(size),

                PagingInfo = new PagingInfo()
                {
                    CurrentPage = productPage,
                    ProductsPerPage = size,
                    Items_total = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category

            });



        //public ViewResult Index(int productPage = 1)
        //{
        //    return View(new ProductListViewModel
        //    {
        //        Products = repository.Products.OrderBy(p => p.ProductId).Skip((productPage - 1) * pageSize).Take(pageSize),
        //        Paging_Info = new PagingInfo { curentPage = productPage, itemsPerPage = pageSize, totalItems = repository.Products.Count() }
        //    });


        //    return View(repository.Products.OrderBy(p => p.ProductId).Skip((productPage - 1) * pageSize).Take(pageSize));
        //}

    }
}