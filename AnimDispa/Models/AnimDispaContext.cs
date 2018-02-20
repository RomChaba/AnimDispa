using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class AnimDispaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AnimDispaContext() : base("name=AnimDispaContext")
        {
        }

        public System.Data.Entity.DbSet<AnimDispa.Models.Comptes> Comptes { get; set; }
        public System.Data.Entity.DbSet<AnimDispa.Models.Animaux> Animaux { get; set; }
        public System.Data.Entity.DbSet<AnimDispa.Models.Villes> Villes { get; set; }
        public System.Data.Entity.DbSet<AnimDispa.Models.Messages> Messages { get; set; }
        public System.Data.Entity.DbSet<AnimDispa.Models.Types> Types { get; set; }
        public System.Data.Entity.DbSet<AnimDispa.Models.Races> Races { get; set; }
        public System.Data.Entity.DbSet<AnimDispa.Models.Config> Config { get; set; }

        public System.Data.Entity.DbSet<AnimDispa.Models.StatutsComptes> StatutsComptes { get; set; }
        public System.Data.Entity.DbSet<AnimDispa.Models.Roles> Roles { get; set; }
    }
}
