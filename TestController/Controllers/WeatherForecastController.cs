using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TestController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] City = new string[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        private static readonly List<WeatherForecast> Summaries = new()
        {
            new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = City[Random.Shared.Next(City.Length)]
            },
            new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(20, 25),
                Summary = City[Random.Shared.Next(City.Length)]
            },
            new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(0, 20),
                Summary = City[Random.Shared.Next(City.Length)]
            },
            new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = City[Random.Shared.Next(City.Length)]
            },
            new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-16, 55),
                Summary = City[Random.Shared.Next(City.Length)]
            },
        };

        public WeatherForecastController()
        {

        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Summaries;
        }

        [HttpPost("[action]")]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            Summaries.Add(weatherForecast);
            // изменени€ кода состо€ни€ успешного запроса отличного от 200
            return StatusCode(205);
        }

        [HttpPut("[action]")]
        public IActionResult Put(int index, WeatherForecast weatherForecast)
        {

            if (index < 0 || index >= Summaries.Count)
            {
                return NotFound();
            }

            Summaries[index] = weatherForecast;
            return Ok();
        }

        /// <summary>
        /// јналогично PUT, но примен€етс€ только к фрагменту ресурса.
        /// </summary>
        /// <param name="weatherForecast"></param>
        /// <returns></returns>
        [HttpPatch("[action]")]
        public IActionResult Patch(WeatherForecast weatherForecast)
        {
            var index = Summaries.IndexOf(weatherForecast);

            if (index < 0)
            {
                Summaries.Add(weatherForecast);
            } else
            {
                Summaries[index].TemperatureC = weatherForecast.TemperatureC;
            }

            return Ok();
        }

        /// <summary>
        /// јналогичен методу GET, за исключением того, что в ответе сервера отсутствует тело. «апрос HEAD обычно примен€етс€
        /// дл€ извлечени€ метаданных, проверки наличи€ ресурса (валидаци€ URL) и чтобы узнать, не изменилс€ ли он с момента 
        /// последнего обращени€.
        /// </summary>
        /// <returns></returns>
        [HttpHead("[action]")]
        public IActionResult Head()
        {
            return Ok();
        }

        /// <summary>
        /// »спользуетс€ дл€ определени€ возможностей веб-сервера или параметров соединени€ дл€ конкретного ресурса. ѕредполагаетс€,
        /// что запрос клиента может содержать тело сообщени€ дл€ указани€ интересующих его сведений. ‘ормат тела и пор€док работы с 
        /// ним в насто€щий момент не определЄн. —ервер пока должен его игнорировать. јналогична€ ситуаци€ и с телом в ответе сервера.
        /// </summary>
        /// <returns></returns>
        [HttpOptions("[action]")]
        public IActionResult Option()
        {
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult Redirect()
        {
            return Redirect("https://localhost:7006/WeatherForecast/Get");
        }
    }
}