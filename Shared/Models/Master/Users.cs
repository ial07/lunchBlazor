using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace man_power_planning.Shared.Models
{
    public class Users : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? UserID { get; set; }
        public string? UserName { get; set; }
        public string? Department { get; set; }
        public string? Division { get; set; }
        public string? Location { get; set; }
        public bool? IsAdmin { get; set; }
    }
}