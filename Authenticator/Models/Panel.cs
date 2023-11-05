using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class Panel
{
    public int IdPanel { get; set; }

    public int? FkIdModulo { get; set; }

    public int? FkIdEstado { get; set; }

    public bool Carpeta { get; set; }

    public string? Dependencia { get; set; }

    public string Nombre { get; set; } = null!;

    public string Interfaz { get; set; } = null!;

    public string Ruta { get; set; } = null!;

    public int Habilitado { get; set; }

    public virtual Estado? FkIdEstadoNavigation { get; set; }

    public virtual Modulo? FkIdModuloNavigation { get; set; }

    public virtual ICollection<PermisoUsuario> PermisoUsuarios { get; set; } = new List<PermisoUsuario>();

    public virtual ICollection<RolPermisoPanel> RolPermisoPanels { get; set; } = new List<RolPermisoPanel>();
}
