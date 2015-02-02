using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using ObjectCollab.Enums;

namespace ObjectCollab.Domain
{
    public interface IUser
    {
       string FirstName { get; set; }
       string LastName { get; set; }
        
        
    }

    public class User : IdentityUser, IUser, IValidatableObject 
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(UserName))
                validationResults.Add(new ValidationResult("UserName is required", new string[] { "UserName" }));

            if (String.IsNullOrWhiteSpace(LastName))
                validationResults.Add(new ValidationResult("Password is required", new string[] { "Password" }));

            return validationResults;
        }
    }

    public class Role : IdentityRole
    {
        
    }
}
