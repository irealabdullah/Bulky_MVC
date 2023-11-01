using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext databaseData;
        public List<Category> CategoryList { get; set; }

        public IndexModel(ApplicationDBContext databaseData)
        {
            this.databaseData = databaseData;
        }
        public void OnGet() //we dont have to to return view
        {
            CategoryList = databaseData.Categories.ToList();
        }
    }
}
