using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfoliowebsite.Models;
using Portfoliowebsite.Services;

namespace Portfoliowebsite.Controllers
{
    public class ContactController : Controller
    {

        private readonly IEmailSender _email;
        public ContactController(IEmailSender email) => _email = email;

        public IActionResult Index() => View(new ContactFormModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactFormModel model)
        {
            // Check if the honeypot is filled
            if (!string.IsNullOrWhiteSpace(model.MiddleName))
            {
                return RedirectToAction(nameof(Index));
            }
            
            // Check if the form is valid
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Trace.WriteLine($"Field: {state.Key} - Error: {error.ErrorMessage}");
                    }
                }
                return View(model);
            }
            
            
            // await _email.SendAsync(model.Name, model.Email, model.Subject, model.Message);
            
            TempData["ThanksName"] = model.Name;
            TempData["ThanksEmail"] = model.Email;
            TempData["ThanksMessage"] = model.Message;

            return RedirectToAction(nameof(Thanks));
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}
