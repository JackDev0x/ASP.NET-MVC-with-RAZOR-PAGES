using Microsoft.AspNetCore.Mvc;
using SandstoneStore.Models;

namespace SandstoneStore.Components
{
    public class NavigationMenuViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        private IDatabaseRepository _repository;

        public NavigationMenuViewComponent(IDatabaseRepository repo)
        {
            _repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategorrryy = RouteData?.Values["category"];
            return View(_repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}
