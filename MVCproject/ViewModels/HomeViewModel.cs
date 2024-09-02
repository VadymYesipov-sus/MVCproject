﻿using MVCproject.Models;

namespace MVCproject.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Club>? Clubs { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        //public HomeUserCreateViewModel Register { get; set; } = new HomeUserCreateViewModel();
    }
}
