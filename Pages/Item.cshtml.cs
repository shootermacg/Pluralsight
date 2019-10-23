using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffee.Models;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee.Pages
{
    public class ItemModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public MenuItem Item { get; set; }
        public void OnGet(string slug)
        {
            Message = "The slug is " + slug;
            Item = new MenuService().GetMenuItems().FirstOrDefault(m => m.Slug == slug);
        }
    }
}
