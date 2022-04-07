using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCDemo.Models;

namespace MVCDemo.Pages
{
    public class Register2Model : PageModel
    {
        [BindProperty]
        public ClassViewModel ClassViewModel { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Class", ClassViewModel);
                }

                return Page();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
