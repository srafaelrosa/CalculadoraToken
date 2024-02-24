using Calculadora.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CalculadoraController : ControllerBase
    {
        //[HttpGet("Token")]
       // public IActionResult Get()
        
         //   return Ok(Auth);
        
        
        //[Authorize]
        [HttpGet("SOMA")]
        public ActionResult<Calculator> Soma(double variavel1, double variavel2) 
        {

            var result = new Calculator(variavel1, variavel2);

            result.soma();
            return Ok(result);      
        
        
        }

        [HttpGet("Subtracao")]
        public ActionResult<Calculator> Sub(double variavel1, double variavel2)
        {

            var result = new Calculator(variavel1, variavel2);

            result.sub();
            return Ok(result);


        }

        [HttpGet("Divisao")]
        public ActionResult<Calculator> Div(double variavel1, double variavel2)
        {

            var result = new Calculator(variavel1, variavel2);

            result.div();
            return Ok(result);


        }

        [HttpGet("Multiplicacao")]
        public ActionResult<Calculator> Mult(double variavel1, double variavel2)
        {

            var result = new Calculator(variavel1, variavel2);

            result.mult();
            return Ok(result);


        }
    }
}
