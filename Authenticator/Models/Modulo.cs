using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public int? FkIdEstado { get; set; }

    public string Abreviatura { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual Estado? FkIdEstadoNavigation { get; set; }

    public virtual ICollection<Panel> Panels { get; set; } = new List<Panel>();

    public virtual ICollection<RolPermisoModulo> RolPermisoModulos { get; set; } = new List<RolPermisoModulo>();
}
