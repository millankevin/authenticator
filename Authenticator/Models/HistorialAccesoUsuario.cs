using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class HistorialAccesoUsuario
{
    public int IdHistorialAcceso { get; set; }

    public int? FkIdUsuario { get; set; }

    public DateTime FechaInicioSesion { get; set; }

    public string? DireccionIp { get; set; }

    public string? InformacionDispositivo { get; set; }

    public virtual Usuario? FkIdUsuarioNavigation { get; set; }
}
