using System;
using System.Collections.Generic;

namespace Equitel.Models;

public partial class RegistroAuditorium
{
    public int Id { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? AccionRealizada { get; set; }

    public string? Usuario { get; set; }
}
