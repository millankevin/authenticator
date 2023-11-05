using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class PermisoUsuario
{
    public int IdPermisoUsuario { get; set; }

    public int? FkIdUsuario { get; set; }

    public int? FkIdPanel { get; set; }

    public int? FkIdPermiso { get; set; }

    public int? FkIdEstado { get; set; }

    public virtual Estado? FkIdEstadoNavigation { get; set; }

    public virtual Panel? FkIdPanelNavigation { get; set; }

    public virtual Permiso? FkIdPermisoNavigation { get; set; }

    public virtual Usuario? FkIdUsuarioNavigation { get; set; }
}
