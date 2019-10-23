using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WiredBrainCoffee.Pages
{
    public class ConfirmationModel : PageModel
    {
        public string Message { get; set; }
        public void OnGetContact()
        {
            Message = "You have been added to the contacts page";
        }

        public void OnGetSubscribe()
        {
            Message = "You have been added to the contacts page";
        }
    }
}
