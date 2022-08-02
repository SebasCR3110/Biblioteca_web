using Biblioteca_web.Infraestructura.Interfaces;
using Biblioteca_web.Infraestructura.Opciones;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Biblioteca_web.Infraestructura.Servicios
{
    public class ServicioContrasena : IServicioContrasena
    {
        private readonly OpcionesContrasena _opciones;

        public ServicioContrasena(IOptions<OpcionesContrasena> opciones)
        {
            _opciones = opciones.Value;
        }

        public bool Verificar(string hash, string contrasena)
        {
            var partes = hash.Split('.', 3);
            if(partes.Length != 3)
            {
                throw new FormatException("Formato del Hash inesperado");
            }

            var iteraciones = Convert.ToInt32(partes[0]);
            var salt = Convert.FromBase64String(partes[1]);
            var key = Convert.FromBase64String(partes[2]);

            using (var algoritmo = new Rfc2898DeriveBytes(
                contrasena,
                salt,
                iteraciones,
                HashAlgorithmName.SHA512
                ))
            {
                var keyVerificar = algoritmo.GetBytes(_opciones.KeySize);
                return keyVerificar.SequenceEqual(key);
            }
        }

        public string Hash(string contrasena)
        {
            //PBKDF2 implemantacion
            using (var algoritmo = new Rfc2898DeriveBytes(
                contrasena,
                _opciones.SaltSize,
                _opciones.Iterations,
                HashAlgorithmName.SHA512
                ))
            {
                var key = Convert.ToBase64String(algoritmo.GetBytes(_opciones.KeySize));
                var salt = Convert.ToBase64String(algoritmo.Salt);

                return $"{_opciones.Iterations}.{salt}.{key}";
            }
        }
    }
}
