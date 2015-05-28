using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace h_store
{
    public partial class ADOModelContainer
    {
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                //var errorMessages = ex.EntityValidationErrors
                  //      .SelectMany(x => x.ValidationErrors)
                    //    .Select(x => x.ErrorMessage);

                // Retrieve the error messages as a list of strings.
                List<string> errorMessages = new List<string>();
                foreach (DbEntityValidationResult validationResult in ex.EntityValidationErrors)
                {
                    string entityName = validationResult.Entry.Entity.GetType().Name;
                    foreach (DbValidationError error in validationResult.ValidationErrors)
                    {
                        errorMessages.Add(entityName + "." + error.PropertyName + ": " + error.ErrorMessage);
                    }
                }

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}