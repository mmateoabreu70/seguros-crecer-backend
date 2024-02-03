using System;
using System.Collections.Generic;

namespace SegurosCrecerAPI.Models;

public partial class Tasa
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public string? Descripcion { get; set; }

    public decimal Tasa1 { get; set; }

}
