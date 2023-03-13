using festekelado_main.Models;

namespace festekelado_main.Repository
{
    public interface FestekRepository
    {
        Task<IEnumerable<Futarok>> GetFutarok();
        Task<Futarok> GetFutar(int FutarId);
        Task<IEnumerable<object>> GetFutarName(string name);
        Task<Futarok> AddFutar(Futarok futar);
        Task<Futarok> UpdateFutar(Futarok futar);
        Task<Futarok> DeleteFutar(int FutarId);

        Task<IEnumerable<Szinek>> GetSzinek();
        Task<Szinek> GetSzin(int SzinId);
        Task<IEnumerable<object>> GetSzinName(string name);
        Task<Szinek> AddSzin(Szinek szin);
        Task<Szinek> UpdateSzin(Szinek szin);
        Task<Szinek> DeleteSzin(int SzinId);

        Task<IEnumerable<Rendelesek>> GetRendelesek();
        Task<Rendelesek> GetRendeles(int RendelesId);
        Task<Rendelesek> AddRendeles(Rendelesek rendeles);
        Task<Rendelesek> UpdateRendeles(Rendelesek rendeles);
        Task<Rendelesek> DeleteRendeles(int RendelesId);


    }
}
