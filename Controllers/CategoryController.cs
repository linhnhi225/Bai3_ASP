using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bai3_ASP.Models;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;//ko cần thiết phải dùng namespace này vì đã có using Microsoft.AspNetCore.Mvc rồi ,nếu ko có dòng này thì phải dùng Models.Category thay vì Category


namespace Bai3_ASP.Controllers
{
    public class CategoryController : Controller
    {
        public static List<Models.Category> categories = new List<Models.Category>//categories ở đây
        {
            //Giả lập csdl
            new Category { Id = 1, Name = "Laptop" },//có thể bỏ Models. vì đã có using Bai3_ASP.Models r
            new Models.Category { Id = 2, Name = "Phone" },
            new Models.Category { Id = 3, Name = "Table" }
        };
        // GET: CategoryController1
        [HttpGet]//có thể bỏ dòng [HttpGet] vì đã  mặc định 
        public ActionResult Index()
        {
            return View(categories);//truyền danh sách categories vào view
        }

        // GET: CategoryController1/Details/5
        public ActionResult Details(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }


            return View(category);
        }

        // GET: CategoryController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category )
        {
            try
            {
               category.Id = categories.Count + 1;//tạo id mới cho category mới
                categories.Add(category);//thêm category mới vào danh sách categories

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController1/Edit/5
        public ActionResult Edit(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;

            return RedirectToAction(nameof(Index));

        }
        // GET: CategoryController1/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }


            return View(category);
        }

        // POST: CategoryController1/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            categories.Remove(category);

            return RedirectToAction(nameof(Index));
        }
        
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            categories.RemoveAll(c => c.Id == id);
            return RedirectToAction(nameof(Index));
        }*/

    }
}
