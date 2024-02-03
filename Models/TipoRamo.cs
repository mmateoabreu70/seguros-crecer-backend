using System;
using System.Collections.Generic;

namespace SegurosCrecerAPI.Models;

public partial class TipoRamo
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Ramo> Ramos { get; set; } = new List<Ramo>();
}
