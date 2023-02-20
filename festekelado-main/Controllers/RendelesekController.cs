using festekelado_main.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace festekelado_main.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RendelesekController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new FestekContext())
            {
                try
                {
                    return Ok(context.Rendeleseks.ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            using (var context = new FestekContext())
            {
                try
                {
                    return Ok(context.Rendeleseks.Where(r => r.Id == id).ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [HttpPost]
        public IActionResult Post(Rendelesek rendeles)
        {
            using (var context = new FestekContext())
            {
                try
                {
                    context.Rendeleseks.Add(rendeles);
                    context.SaveChanges();
                    return Ok("Rendeles felvéve");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        
        [HttpPut]
        public IActionResult Put(Rendelesek rendeles)
        {
            using (var context = new FestekContext())
            {
                try
                {
                    context.Rendeleseks.Update(rendeles);
                    context.SaveChanges();
                    return Ok("rendelés megváltoztatva");
                    
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using (var context = new FestekContext())
            {
                try
                {
                    Rendelesek rendeles = new Rendelesek();
                    rendeles.Id = id;
                    context.Rendeleseks.Remove(rendeles);
                    context.SaveChanges();
                    return Ok("rendelés törölve");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
