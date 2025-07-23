//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;

//namespace BillsSystem.MVC.Models
//{dotnet aspnet-codegenerator controller -name ProductsController -m Product -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

//    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//    {
//        public ApplicationDbContext CreateDbContext(string[] args)
//        {
//            var currentDirectory = Directory.GetCurrentDirectory();
//            Console.WriteLine("CURRENT DIRECTORY: " + currentDirectory);

//            var config = new ConfigurationBuilder()
//                .SetBasePath(currentDirectory)
//                .AddJsonFile("appsettings.json")
//                .Build();

//            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

//            return new ApplicationDbContext(optionsBuilder.Options);
//        }

//    }
//}
