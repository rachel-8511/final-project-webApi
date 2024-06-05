using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DatabaseFixture : IDisposable
    {
        public MyShop214189656Context Context { get; private set; }

        public DatabaseFixture()
        {
            // Set up the test database connection and initialize the context
            var options = new DbContextOptionsBuilder<MyShop214189656Context>()
                .UseSqlServer("Server=srv2\\pupils;Database=Tests_214189656;Trusted_Connection=True;TrustServerCertificate=true;")
                .Options;
            Context = new MyShop214189656Context(options);
            Context.Database.EnsureCreated();// create the data base
        }

        public void Dispose()
        {
            // Clean up the test database after all tests are completed
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
