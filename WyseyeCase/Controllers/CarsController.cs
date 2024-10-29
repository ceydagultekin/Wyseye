using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WyseyeCase.Interface;
using System.Threading.Tasks;
using WyseyeCase.Models;
using WyseyeCase.Repository;
using WyseyeCase.Models.Model;

namespace WyseyeCase.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly ICar carRepository;

		public CarsController(ICar carRepository) {
			this.carRepository = carRepository;
		}

		[HttpGet]
		public async Task<ActionResult> GetCars()
		{
			try
			{
				var cars = await carRepository.GetCarsAsync();
				return Ok(cars);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Bir hata oluştu,daha sonra tekrar deneyiniz.");
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Car>> GetCarById(int id)
		{
			try
			{
				var car = await carRepository.GetCarByIdAsync(id);
				if (car == null) return NotFound();
				return Ok(car);
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Bir hata oluştu,daha sonra tekrar deneyiniz.");
			}
		}

		[HttpPost]
		public async Task<ActionResult<Car>> AddCar(Car car)
		{
			try
			{
				var newCar = await carRepository.AddCar(car);
				return Ok(newCar);

			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Bir hata oluştu,daha sonra tekrar deneyiniz.");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCar(int id,Car car)
		{
			try
			{
				if(id != car.Id) return BadRequest("ID uyuşmuyor , tekrar deneyiniz");
				var existingCar = await carRepository.GetCarByIdAsync(id);
				if(existingCar == null) return NotFound();

				var updatedCar = await carRepository.UpdateCar(car);
				return Ok(updatedCar);
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Bir hata oluştu,daha sonra tekrar deneyiniz.");
			}
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCar(int id)
		{
			try
			{
				var car = await  carRepository.GetCarByIdAsync(id);
				if (car == null) return NotFound();
				await carRepository.DeleteCar(id);
				return NoContent();

			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Bir hata oluştu,daha sonra tekrar deneyiniz.");
			}
		}
		
	}
}
