using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WyseyeCase.Interface;
using System.Threading.Tasks;
using WyseyeCase.Models;
using WyseyeCase.Repository;
using WyseyeCase.Models.Model;
using MediatR;
using WyseyeCase.Cqrs.Queries;
using WyseyeCase.Cqrs.Commands;

namespace WyseyeCase.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
		public async Task<ActionResult> GetCars()
		{
			try
			{
				var cars = await _mediator.Send(new GetCarsQuery());
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
				var car = await _mediator.Send(new GetCarByIdQuery(id));
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
				var newCar = await _mediator.Send(new AddCarCommand(car));
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
				var existingCar = await _mediator.Send(new GetCarByIdQuery(id));
				if(existingCar == null) return NotFound();

				var updatedCar = await _mediator.Send(new UpdateCarCommand(car));
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
				var car = await _mediator.Send(new GetCarByIdQuery(id));
				if (car == null) return NotFound();
				await _mediator.Send(new DeleteCarCommand(id));
				return NoContent();

			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Bir hata oluştu,daha sonra tekrar deneyiniz.");
			}
		}
		
	}
}
