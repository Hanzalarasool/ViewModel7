namespace ViewModel.Models
{
    public class B
    {
        public int Id { get; set; }

        public string? One { get; set; }

        public string? Two { get; set; }

        public string? Three { get; set; }
        public int? AId { get; set; }

        // _______________________________________

        public A? A { get; set; }

        public IEnumerable<C>? C { get; set; }
    }
}
