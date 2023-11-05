using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class Token
{
    public int IdToken { get; set; }

    public int? FkIdUsuario { get; set; }

    public string TokenValor { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public virtual Usuario? FkIdUsuarioNavigation { get; set; }
}
