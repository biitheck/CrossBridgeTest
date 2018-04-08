namespace Contacts.Web.Controllers
{
    using Contacts.Domain;
    using Contacts.Web.Data;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Produces("application/json")]
    public class ContactController : ODataController
    {
        #region Attributes
        private readonly AppDbContext _context;
        #endregion

        #region Constructors
        public ContactController(AppDbContext context) => this._context = context;
        #endregion

        #region Public Methods
        [EnableQuery]
        public IQueryable<Contact> Get() => this._context.Contacts.AsQueryable();

        [EnableQuery]
        public SingleResult<Contact> Get([FromODataUri]int key)
        {
            IQueryable<Contact> provider = _context.Contacts
                                            .Where(m => m.Id == key);

            return SingleResult.Create(provider);
        }
        #endregion
    }
}
