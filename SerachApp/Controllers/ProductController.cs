using Microsoft.AspNetCore.Mvc;
using SerachApp.Models;

namespace SerachApp.Controllers
{
    
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        
        public IActionResult Index()
        {
            var result = productRepository.GetAll();
            return View(result);
        }

        [Route("/getAllProducts")]
        public IActionResult getAllProducts() {
            var result = productRepository.GetAll();
            return PartialView("_ProductTable", result);
        }

        [Route("getAll")]
        public IActionResult GetAll(FilterModel filterModel)
        {
            Console.WriteLine(filterModel.ProductName);
            Console.WriteLine(filterModel.Price);

            var result = productRepository.getFilterResult(filterModel);
            return PartialView("_ProductTable", result);
        }

        [Route("search")]
        public string GetProducts()
        {
            return "here";
        }
    }
}
