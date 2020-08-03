using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //---Used to access the product?
        //ProductRepository context;
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;
        //---Load the categories from db
        //ProductCategoryRepository productCategories;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            //---Init these
            //context = new InMemoryRepository<Product>();
            //---Now that the interfaces are working
            //---we can set the init different
            context = productContext;
            //productCategories = new InMemoryRepository<ProductCategory>();
            productCategories = productCategoryContext;
        }

        public ActionResult Index(string Category=null)
        {
            //---Get the list of products
            //List<Product> products = context.Collection().ToList();
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if(Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                //---IQueryable object using where
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;

            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();
            } else
            {
                return View(product);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}