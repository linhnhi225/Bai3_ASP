using Bai3_ASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bai3_ASP.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 15000000,
                Description = "Laptop học tập"
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Price = 250000,
                Description = "Chuột không dây"
            },
            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Price = 500000,
                Description = "Bàn phím cơ"
            }
        };
        // GET: ProductController

        public ActionResult Index()
        {
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                product.Id = products.Count == 0
                     ? 1
                     : products.Max(p => p.Id) + 1;

                products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
           
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var existingProduct = products.FirstOrDefault(
              p => p.Id == product.Id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
