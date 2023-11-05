using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<AuditoriaPermiso> AuditoriaPermisos { get; set; } = new List<AuditoriaPermiso>();

    public virtual ICollection<AuditoriaUsuario> AuditoriaUsuarios { get; set; } = new List<AuditoriaUsuario>();

    public virtual ICollection<PermisoUsuario> PermisoUsuarios { get; set; } = new List<PermisoUsuario>();

    public virtual ICollection<RolPermisoModulo> RolPermisoModulos { get; set; } = new List<RolPermisoModulo>();

    public virtual ICollection<RolPermisoPanel> RolPermisoPanels { get; set; } = new List<RolPermisoPanel>();
}
