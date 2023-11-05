﻿using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class AuditoriaPermiso
{
    public int IdAuditoriaPermiso { get; set; }

    public int? FkIdPermiso { get; set; }

    public int? FkIdUsuario { get; set; }

    public DateTime FechaEvento { get; set; }

    public string? NombreTabla { get; set; }

    public int? IdResgistroAfectado { get; set; }

    public string? Detalles { get; set; }

    public virtual Permiso? FkIdPermisoNavigation { get; set; }

    public virtual Usuario? FkIdUsuarioNavigation { get; set; }
}
