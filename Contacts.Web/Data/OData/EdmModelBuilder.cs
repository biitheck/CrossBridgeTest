namespace Contacts.Web.Data.OData
{
    using Contacts.Domain;
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.OData.Edm;
    using System;
    using System.Linq;

    public class EdmModelBuilder
    {
        #region Public Methods
        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Contact>(nameof(Contact))
                            .EntityType
                            .Filter()
                            .Count()
                            .Expand()
                            .OrderBy()
                            .Page()
                            .Select();

            var t = builder.StructuralTypes.First(x => x.ClrType == typeof(Contact));
            t.AddProperty(typeof(Contact).GetProperty("FullName"));

            return builder.GetEdmModel();
        }
        #endregion
    }
}
