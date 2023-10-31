using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    // when ever we want to retreive, add data, update data we will work with dbcontext 
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext databaseData;

        public CategoryController(ApplicationDBContext DatabaseData)
        {
            this.databaseData = DatabaseData;
        }
        public IActionResult Index()
        {
            //var objCategoryList = databaseData.Categories.ToList(); //
            List<Category> objCategoryList = databaseData.Categories.ToList(); //This is better as we just write 2 lines[it will go to database and run command select * from categories]
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Invalid");
            }

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","The Display Order cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
            databaseData.Categories.Add(obj);
            databaseData.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
            return RedirectToAction("Index","Category");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = databaseData.Categories.Find(id);
            //Category? categoryFromDB1 = databaseData.Categories.FirstOrDefault(x=>x.ID == id);
            //Category? categoryFromDB2 = databaseData.Categories.Where(x=>x.ID == id).FirstOrDefault();
            if(categoryFromDB == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDB);
        }


        [HttpPost]
        public IActionResult Edit(Category obj)
        {
           
            if (ModelState.IsValid)
            {
                databaseData.Categories.Update(obj);
                databaseData.SaveChanges();
                TempData["success"] = "Category Updated Successfully";

                return RedirectToAction("Index", "Category");
            }
            return View();
        }
      

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = databaseData.Categories.Find(id);
            //Category? categoryFromDB1 = databaseData.Categories.FirstOrDefault(x=>x.ID == id);
            //Category? categoryFromDB2 = databaseData.Categories.Where(x=>x.ID == id).FirstOrDefault();
            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }


        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = databaseData.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            databaseData.Categories.Remove(obj);
            databaseData.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index", "Category");

           
        }
       
    }
}


