using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCRM.Core.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }
    }
}
