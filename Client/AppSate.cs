using lunchBlazor.Shared.Models;

namespace lunchBlazor.Client
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