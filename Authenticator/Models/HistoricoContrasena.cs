using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class HistoricoContrasena
{
    public int IdHistorico { get; set; }

    public int? FkIdUsuario { get; set; }

    public string Contrasena { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public virtual Usuario? FkIdUsuarioNavigation { get; set; }
}
