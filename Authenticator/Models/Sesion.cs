using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class Sesion
{
    public int IdSesion { get; set; }

    public int? FkIdUsuario { get; set; }

    public string TokenSesion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public virtual Usuario? FkIdUsuarioNavigation { get; set; }
}
