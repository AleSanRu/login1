using System;
using System.Collections.Generic;

namespace Login_Pagina.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? ApellidoUsuario { get; set; }

    public string? Correo { get; set; }

    public string? NumeroTel { get; set; }

    public string? Direccion { get; set; }

    public string? FechaNa { get; set; }

    public string? Clave { get; set; }
}
