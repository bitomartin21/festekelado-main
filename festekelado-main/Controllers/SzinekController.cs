using festekelado_main.Models;
using festekelado_main.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace festekelado_main.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzinekController : ControllerBase
    {
        private readonly FestekRepository _context;

        public SzinekController(FestekRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Szinek>> Get()
        {
            return await _context.GetSzinek();
        }

        [HttpGet("id")]
        public async Task<Szinek> Get(int id)
        {
            return await _context.GetSzin(id);
        }

        [HttpGet("name")]
        public async Task<IEnumerable<object>> GetName(string name)
        {
            return await _context.GetSzinName(name);
        }

        [HttpPost]
        public async Task<Szinek> Post(Szinek szin)
        {
            return await _context.AddSzin(szin);
        }

        [HttpPut]
        public async Task<Szinek> Put(Szinek szinek)
        {
            return await _context.UpdateSzin(szinek);
        }

        [HttpDelete]
        public async Task<Szinek> Delete(int id)
        {
            return await _context.DeleteSzin(id);
        }

        /*
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
        */
    }
}
