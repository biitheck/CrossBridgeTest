namespace Contacts.Web.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ContactDetailsModel : PageModel
    {
        #region Properties
        public int ContactId { get; set; }
        #endregion

        #region Public Methods
        public IActionResult OnGet(int id)
        {
            ContactId = id;

            if (ContactId <= 0)
                return RedirectToPage("./Index");

            return Page();
        }
        #endregion
    }
}