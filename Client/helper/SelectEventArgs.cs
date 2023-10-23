namespace man_power_planning.Client.helper
{
    public class SelectChangedEventArgs
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class SelectMultipleChangedEventArgs
    {
        public string Name { get; set; }
        public string[] Value { get; set; }
    }
}