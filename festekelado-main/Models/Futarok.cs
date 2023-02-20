using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace festekelado_main.Models;

public partial class Futarok
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    [JsonIgnore] //ezzel nem jelenik meg swaggerben
    public virtual ICollection<Rendelesek> Rendeleseks { get; } = new List<Rendelesek>();
}
