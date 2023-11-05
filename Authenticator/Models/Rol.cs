using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public int? FkIdEstado { get; set; }

    public string Abreviatura { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual Estado? FkIdEstadoNavigation { get; set; }

    public virtual ICollection<RolPermisoModulo> RolPermisoModulos { get; set; } = new List<RolPermisoModulo>();

    public virtual ICollection<RolPermisoPanel> RolPermisoPanels { get; set; } = new List<RolPermisoPanel>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
