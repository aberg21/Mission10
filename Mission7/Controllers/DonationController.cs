using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission7.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission7.Controllers
{
    public class DonationController : Controller
    {

        private IDonationRepository repo { get; set; }
        private Basket basket { get; set; }

        public DonationController(IDonationRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }


        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Donation());
        }

        [HttpPost]
        public IActionResult Checkout(Donation donation)
        {
            if (basket.Carts.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                donation.Lines = basket.Carts.ToArray();
                repo.SaveDonation(donation);
                basket.ClearBasket();

                return RedirectToPage("/DonationCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
