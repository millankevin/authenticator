using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class RolPermisoModulo
{
    public int IdPermisoModulo { get; set; }

    public int? FkIdRol { get; set; }

    public int? FkIdModulo { get; set; }

    public int? FkIdPermiso { get; set; }

    public int? FkIdEstado { get; set; }

    public virtual Estado? FkIdEstadoNavigation { get; set; }

    public virtual Modulo? FkIdModuloNavigation { get; set; }

    public virtual Permiso? FkIdPermisoNavigation { get; set; }

    public virtual Rol? FkIdRolNavigation { get; set; }
}
