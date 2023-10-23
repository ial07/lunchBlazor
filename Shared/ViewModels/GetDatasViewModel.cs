
namespace man_power_planning.Shared.ViewModels
{
    public class GetDatasViewModel<T>
    {
        public List<T> Items { get; set; }
        public int? page { get; set; }
        public int? pageSize { get; set; }
        public int? totalCountData { get; set; }
    }
}