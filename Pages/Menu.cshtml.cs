using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WiredBrainCoffee.Models;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee.Pages
{
    public class MenuModel : PageModel
    {
        private IMenuService _menuService;
        private ILogger<MenuModel> _logger;

        public MenuModel(IMenuService menuService, ILogger<MenuModel> logger)
        {
            _menuService = menuService;
            _logger = logger;
        }
        public List<MenuItem> Menu { get; set; }
        public void OnGet()
        {
            try
            {
                Menu = _menuService.GetMenuItems();
                throw new Exception();
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Debug, "Could not get menu");
            }
        }
    }
}
