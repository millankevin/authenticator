using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class RolPermisoPanel
{
    public int IdPermisoPanel { get; set; }

    public int? FkIdRol { get; set; }

    public int? FkIdPanel { get; set; }

    public int? FkIdPermiso { get; set; }

    public int? FkIdEstado { get; set; }

    public virtual Estado? FkIdEstadoNavigation { get; set; }

    public virtual Panel? FkIdPanelNavigation { get; set; }

    public virtual Permiso? FkIdPermisoNavigation { get; set; }

    public virtual Rol? FkIdRolNavigation { get; set; }
}
