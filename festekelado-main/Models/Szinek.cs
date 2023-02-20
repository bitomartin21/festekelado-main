using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace festekelado_main.Models;

public partial class Szinek
{
    public int Id { get; set; }

    public string Szin { get; set; } = null!;

    public int Db { get; set; }

    [JsonIgnore] //ezzel nem jelenik meg swaggerben
    public virtual ICollection<Rendelesek> Rendeleseks { get; } = new List<Rendelesek>();
}
