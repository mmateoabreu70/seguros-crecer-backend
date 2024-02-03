using System;
using System.Collections.Generic;

namespace SegurosCrecerAPI.Models;

public partial class Ramo
{
    public int Id { get; set; }

    public int TipoRamoId { get; set; }

    public string? Descripcion { get; set; }

    public virtual TipoRamo TipoRamo { get; set; } = null!;
}
