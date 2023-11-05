using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();

    public virtual ICollection<Panel> Panels { get; set; } = new List<Panel>();

    public virtual ICollection<PermisoUsuario> PermisoUsuarios { get; set; } = new List<PermisoUsuario>();

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();

    public virtual ICollection<RolPermisoModulo> RolPermisoModulos { get; set; } = new List<RolPermisoModulo>();

    public virtual ICollection<RolPermisoPanel> RolPermisoPanels { get; set; } = new List<RolPermisoPanel>();

    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
