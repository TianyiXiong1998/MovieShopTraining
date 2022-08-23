using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MovieCRM.Core.Models
{
    public class ActorsModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Actor Name is required")]
        [MaxLength(50,ErrorMessage ="Actor name can no more longer than 50 character long")]
        public string Name { get; set; }
    }
}
