using festekelado_main.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace festekelado_main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutarokController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new FestekContext())
            {
                try
                {
                    return Ok(context.Futaroks.ToList());
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
                    return Ok(context.Futaroks.Where(f => f.Id == id).ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [HttpPost]
        public IActionResult Post(Futarok futar)
        {
            using (var context = new FestekContext())
            {
                try
                {
                    context.Futaroks.Add(futar);
                    context.SaveChanges();
                    return Ok("új futár felvéve");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public IActionResult Put(Futarok futar)
        {
            using (var context = new FestekContext())
            {
                try
                {
                    context.Futaroks.Update(futar);
                    context.SaveChanges();
                    return Ok("futár megváltoztatva");

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
                    Futarok futar = new Futarok();
                    futar.Id = id;
                    context.Futaroks.Remove(futar);
                    context.SaveChanges();
                    return Ok("futár kirúgva");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
