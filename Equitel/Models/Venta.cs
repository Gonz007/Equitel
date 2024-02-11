using System;
using System.Collections.Generic;

namespace Equitel.Models;

public partial class Venta
{
    public int Id { get; set; }

    public DateTime? FechaVenta { get; set; }

    public int? Idusuario { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
