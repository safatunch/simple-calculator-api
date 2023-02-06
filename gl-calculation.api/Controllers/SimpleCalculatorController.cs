using gl_calculation.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gl_calculation.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SimpleCalculatorController : Controller
    {
        private ISimpleCalculator _calculator;

        public SimpleCalculatorController(ISimpleCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet("{start}/{amount}")]
        public IActionResult Add(int start, int amount)
        {
            try
            {
                var res = _calculator.Add(start, amount);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{start}/{amount}")]
        public IActionResult Subtract(int start, int amount)
        {
            try
            {
                var res=_calculator.Subtract(start, amount);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
