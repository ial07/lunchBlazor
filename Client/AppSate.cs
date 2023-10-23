using man_power_planning.Shared.Models;

namespace man_power_planning.Client
{
    public class AppState
    {
        public string? Id { get; set; }
        public MppChildForm? MppChildForm { get; set; }
        public MppForm? MppForm { get; set; }
        public Users? User { get; set; }
        public string? Token { get; set; }
    }
}