﻿using System.Data.Entity;

namespace KisiselWebProjesi_MVC.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Anasayfa> Anasayfas { get; set; }
        public DbSet<ikonlar> ikonlars { get; set; }

    }
}