using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lunchBlazor.Shared.Models
{
    public class User : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Department { get; set; }
        public string? Division { get; set; }
        public string? Location { get; set; }
        public bool IsActive { get; set; }
    }
}