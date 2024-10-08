﻿using Microsoft.AspNetCore.Mvc;
using Login_Pagina.Models;
using Login_Pagina.Recursos;
using Login_Pagina.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace Login_Pagina.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;

        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {   
            modelo.Clave= Utilidades.EncriptarClave(modelo.Clave);

            Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

            if (usuario_creado.Idusuario > 0)
                return RedirectToAction("IniciarSesion","Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }
        
        public IActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IniciarSesion( string Correo,string Clave)
        {
            Usuario usuario_encontrado = await _usuarioServicio.GetUsuarios(Correo,Utilidades.EncriptarClave(Clave));
            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No Se encontraron conincidencias";
                return View();
            } 
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario_encontrado.NombreUsuario)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );
            return RedirectToAction("Index", "Home");
        }
    }
}
