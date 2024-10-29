using Microsoft.EntityFrameworkCore;
using WyseyeCase.Interface;
using WyseyeCase.Models.Model;
using WyseyeCase.Data;

namespace WyseyeCase.Repository
{
	public class CarRepository : ICar
	{
		private readonly DataContext dbContext;

		public CarRepository(DataContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<Car>> GetCarsAsync()
		{
			return await dbContext.Cars.ToListAsync();
		}
		public async Task<Car> GetCarByIdAsync(int id)
		{
			return await dbContext.Cars.FirstOrDefaultAsync(dbContext => dbContext.Id == id);
		}

		public async Task<Car> AddCar(Car car)
		{
			if (car is null) throw new ArgumentNullException("Araba bilgileri eksik girildi");
			await dbContext.Cars.AddAsync(car);
			await dbContext.SaveChangesAsync();
			return car;
		}

		public async Task DeleteCar(int id)
		{
			var car = await dbContext.Cars.FirstOrDefaultAsync(dbContext=>dbContext.Id == id);
			if (car is null) throw new KeyNotFoundException("Silmek istediğiniz araba bulunamadı");

			dbContext.Remove(car);
			await dbContext.SaveChangesAsync();

		}	

		public async Task<Car> UpdateCar(Car car)
		{
			var existingCar = await dbContext.Cars.FirstOrDefaultAsync(dbContext => dbContext.Id == car.Id);
			if(existingCar is null) throw new KeyNotFoundException("Güncellemek istediğiniz araba bulunamadı");

			existingCar.Make = car.Make;
			existingCar.Model = car.Model;
			existingCar.Year = car.Year;
			existingCar.LicensePlate = car.LicensePlate;
				

			dbContext.Cars.Update(existingCar);
			await dbContext.SaveChangesAsync();

			return existingCar;
		}
	}
}
