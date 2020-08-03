using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        //---Constructor
        //---DefaultConnection is going to be looked up
        //---in the web.config file
        public DataContext()
            : base("DefaultConnection")
        {

        }

        //---Passing the values of the tables needed taken from module
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        
    }
}
