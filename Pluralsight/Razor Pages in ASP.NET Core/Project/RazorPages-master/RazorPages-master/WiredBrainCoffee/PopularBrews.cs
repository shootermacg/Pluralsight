using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee
{
    public class PopularBrews : ViewComponent
    {
        private IMenuService _menuSerice;

        public PopularBrews(IMenuService menuService)
        {
            _menuSerice = menuService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            if (count == 0)
            {
                return View(_menuSerice.GetMenuItems().Take(1));
            }

            return View(_menuSerice.GetMenuItems().Take(count));
        }
    }
}
