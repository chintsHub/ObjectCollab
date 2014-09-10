using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.Domain.Domain
{
    public interface IUser
    {
        int UserId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        byte[] RowVersion { get; set; }
        Role Role { get; set; }
    }

    public class User : IUser, IValidatableObject 
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] RowVersion { get; set; }
        public Role Role { get; set; }

        public User()
        {
            
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(UserName))
                validationResults.Add(new ValidationResult("UserName is required", new string[] { "UserName" }));

            if (String.IsNullOrWhiteSpace(Password))
                validationResults.Add(new ValidationResult("Password is required", new string[] { "Password" }));

            return validationResults;
        }
    }
}
