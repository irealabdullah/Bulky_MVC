using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext databaseData;
        public Category Category { get; set; }

        public CreateModel(ApplicationDBContext databaseData)
        {
            this.databaseData = databaseData;
        }
        public void OnGet() 
        {
           
        }
    }
}


