using WyseyeCase.Models.Model;

namespace WyseyeCase.Interface
{
	public interface ICar
	{
		Task<IEnumerable<Car>> GetCarsAsync();
		Task<Car> GetCarByIdAsync(int id);
		Task<Car> AddCar(Car car);
		Task DeleteCar(int id);
		Task<Car> UpdateCar(Car car);
				
	}
}
