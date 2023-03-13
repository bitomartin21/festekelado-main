using festekelado_main.Models;
using festekelado_main.Repository;
using Microsoft.EntityFrameworkCore;

namespace festekelado_main.Services
{
    public class FestekService : FestekRepository
    {
        private readonly FestekContext _context;

        public FestekService(FestekContext context)
        {
            _context = context;
        }

        //Futarok
        public async Task<IEnumerable<Futarok>> GetFutarok()
        {
            return await _context.Futaroks.ToListAsync();
        }
        public async Task<Futarok> GetFutar(int futarId)
        {
            return await _context.Futaroks.FindAsync(futarId);
        }

        public async Task<IEnumerable<object>> GetFutarName(string name)
        {
            var result = from futartable in _context.Futaroks where futartable.Nev.Contains(name) select new { futartable };
            return await result.ToListAsync();
        }
        public async Task<Futarok> AddFutar(Futarok futar)
        {
            _context.Futaroks.Add(futar);
            await _context.SaveChangesAsync();
            return futar;
        }

        public async Task<Futarok> UpdateFutar(Futarok futar)
        {
            _context.Futaroks.Update(futar);
            await _context.SaveChangesAsync();
            return futar;
        }

        public async Task<Futarok> DeleteFutar(int futarId)
        {
            Futarok futar = new Futarok();
            futar.Id = futarId;
            _context.Futaroks.Remove(futar);
            await _context.SaveChangesAsync();
            return futar;

        }
        //
        //Szinek
        public async Task<IEnumerable<Szinek>> GetSzinek()
        {
            return await _context.Szineks.ToListAsync();
        }

        public async Task<Szinek> GetSzin(int SzinId)
        {
            return await _context.Szineks.FindAsync(SzinId);
        }
        public async Task<IEnumerable<object>> GetSzinName(string name)
        {
            var result = from szintable in _context.Szineks where szintable.Szin.Contains(name) select new { szintable };
            return await result.ToListAsync();
        }
        public async Task<Szinek> AddSzin(Szinek szin)
        {
            _context.Szineks.Add(szin);
            await _context.SaveChangesAsync();
            return szin;
        }
        public async Task<Szinek> UpdateSzin(Szinek szin)
        {
            _context.Szineks.Update(szin);
            await _context.SaveChangesAsync();
            return szin;
        }

        public async Task<Szinek> DeleteSzin(int SzinId)
        {
            Szinek szin = new Szinek();
            szin.Id = SzinId;
            _context.Szineks.Remove(szin);
            await _context.SaveChangesAsync();
            return szin;
        }
        //
        //Rendelesek

        public async Task<IEnumerable<Rendelesek>> GetRendelesek()
        {
            return await _context.Rendeleseks.ToListAsync();
        }

        public async Task<Rendelesek> GetRendeles(int RendelesId)
        {
            return await _context.Rendeleseks.FindAsync(RendelesId);
        }

        public async Task<Rendelesek> AddRendeles(Rendelesek rendeles)
        {
            _context.Rendeleseks.Add(rendeles);
            await _context.SaveChangesAsync();
            return rendeles;
        }
        public async Task<Rendelesek> UpdateRendeles(Rendelesek rendeles)
        {
            _context.Rendeleseks.Update(rendeles);
            await _context.SaveChangesAsync();
            return rendeles;
        }

        public async Task<Rendelesek> DeleteRendeles(int RendelesId)
        {
            Rendelesek rendeles = new Rendelesek();
            rendeles.Id = RendelesId;
            _context.Rendeleseks.Remove(rendeles);
            await _context.SaveChangesAsync();
            return rendeles;
        }
    }
}
