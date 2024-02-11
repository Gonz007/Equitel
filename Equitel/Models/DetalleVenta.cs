using System;
using System.Collections.Generic;

namespace Equitel.Models;

public partial class DetalleVenta
{
    public int? Idventa { get; set; }

    public int? Idproducto { get; set; }

    public int? CantidadVendida { get; set; }

    public decimal? PrecioVenta { get; set; }

    public virtual Producto? IdproductoNavigation { get; set; }

    public virtual Venta? IdventaNavigation { get; set; }
}
