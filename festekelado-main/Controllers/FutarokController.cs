using festekelado_main.Models;
using festekelado_main.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace festekelado_main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutarokController : ControllerBase
    {

        private readonly FestekRepository _context;

        public FutarokController(FestekRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Futarok>> Get()
        {
            return await _context.GetFutarok();
        }

        [HttpGet("id")]
        public async Task<Futarok> Get(int id)
        {
            return await _context.GetFutar(id);
        }

        [HttpGet("name")]
        public async Task<IEnumerable<object>> GetName(string name)
        {
            return await _context.GetFutarName(name);
        }

        [HttpPost]
        public async Task<Futarok> Post(Futarok futar)
        {
            return await _context.AddFutar(futar);
        }

        [HttpPut]
        public async Task<Futarok> Put(Futarok futar)
        {
            return await _context.UpdateFutar(futar);
        }

        [HttpDelete]
        public async Task<Futarok> Delete(int id)
        {
            return await _context.DeleteFutar(id);
        }
        /*
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
        }*/
    }
}
