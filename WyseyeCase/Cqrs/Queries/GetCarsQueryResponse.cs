using WyseyeCase.Models.Model;

namespace WyseyeCase.Cqrs.Queries
{
    public class GetCarsQueryResponse
    {
        public IEnumerable<Car> Cars { get; set; }
        public string Message { get; set; }
    }
}
