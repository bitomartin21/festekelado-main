using festekelado_main.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace festekelado_main.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzinekController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new FestekContext())
            {
                try
                {
                    return Ok(context.Szineks.ToList());
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
                    return Ok(context.Szineks.Where(s => s.Id == id).ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [HttpPost]
        public IActionResult Post(Szinek szin)
        {
            using (var context = new FestekContext())
            {
                try
                {
                    context.Szineks.Add(szin);
                    context.SaveChanges();
                    return Ok("új szin felvéve");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public IActionResult Put(Szinek szin)
        {
            using (var context = new FestekContext())
            {
                try
                {
                    context.Szineks.Update(szin);
                    context.SaveChanges();
                    return Ok("szin megváltoztatva");

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
                    Szinek szin = new Szinek();
                    szin.Id = id;
                    context.Szineks.Remove(szin);
                    context.SaveChanges();
                    return Ok("szin törölve");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
