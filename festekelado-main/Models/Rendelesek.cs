using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace festekelado_main.Models;

public partial class Rendelesek
{
    public int Id { get; set; }

    public int? Futarid { get; set; }

    public int? Szinid { get; set; }

    public int Rendeltdb { get; set; }

    public int osszar { get; set; }

    public string Címzett { get; set; } = null!;


    [JsonIgnore] //ezzel nem jelenik meg swaggerben
    public virtual Futarok? Futar { get; set; }
    [JsonIgnore]
    public virtual Szinek? Szin { get; set; }
}
