﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
        // Factory class that creates and enables the use of the Db object,
        // this class should be created for scaffolding operations.
        public class DbFactory : IDesignTimeDbContextFactory<Db>
        {
            public Db CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<Db>();

                // we are going to use Microsoft SQL Server LocalDB from now on
                //optionsBuilder.UseMySQL("server=127.0.0.1;database=test;user id=std;password=;");
                optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=HobbiesAppCTISDB;trusted_connection=true;");

                // First, create an object containing the connection string of your database
                // (it's more suitable to use the development database).

                return new Db(optionsBuilder.Options);
                // Then, return an object of type Db using the optionsBuilder object we created above.
            }
        }
}
