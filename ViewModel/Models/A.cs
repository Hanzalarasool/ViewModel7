﻿namespace ViewModel.Models
{
    public class A
    {
        public int Id { get; set; }

        public string? One { get; set; }

        public string? Two { get; set; }

        public string? Three { get; set; }

        public IEnumerable<C>? C { get; set; }
        public IEnumerable<B>? B { get; set; }

    }
}
