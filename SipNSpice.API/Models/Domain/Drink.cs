﻿using System.ComponentModel.DataAnnotations;

namespace SipNSpice.API.Models.Domain
{
    public class Drink
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public ICollection<Base> Bases { get; set; }
    }
}
