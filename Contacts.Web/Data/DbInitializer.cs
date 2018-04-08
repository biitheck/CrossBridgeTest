namespace Contacts.Web.Data
{
    using Contacts.Domain;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    public class DbInitializer
    {
        #region Attributes
        private static bool _initialized = false;
        private static object _lock = new object();
        #endregion

        #region Internal
        internal static void Initialize(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (_initialized)
                        return;

                    InitializeData(context, hostingEnvironment);
                }
            }
        }
        #endregion

        #region Private Methods

        private static void InitializeData(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            context.Database.Migrate();
            Seed(context, hostingEnvironment);
        }

        private static void Seed(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            AddContacts(context, hostingEnvironment);
        }

        private static void AddContacts(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            string contentRootPath = hostingEnvironment.ContentRootPath;
            var json = System.IO.File.ReadAllText(contentRootPath + "/ContactsJson.json");
            var contacts = JsonConvert.DeserializeObject<List<Contact>>(json);

            if (!context.Contacts.Any() && contacts?.Count > 0)
            {
                context.Contacts.AddRange(contacts);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
