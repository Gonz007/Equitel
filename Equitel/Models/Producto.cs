using System;
using System.Collections.Generic;

namespace Equitel.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Modelo { get; set; }

    public int? CantidadEnBodega { get; set; }

    public decimal? ValorVenta { get; set; }
}
