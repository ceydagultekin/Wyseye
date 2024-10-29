using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using WyseyeCase.Models.Model;

namespace WyseyeCase.Data
{
	public class DataContext:DbContext
	{
		public DataContext()
		{

		}

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
			try
			{
				var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
				if(databaseCreator != null)
				{
					if (!databaseCreator.CanConnect()) databaseCreator.Create();
					if(!databaseCreator.HasTables()) databaseCreator.CreateTables();
				}
			}
			catch(Exception ex) 
			{
			  Console.WriteLine(ex.Message);
			}
		}

		public DbSet<Car> Cars { get; set; }
	}

}
