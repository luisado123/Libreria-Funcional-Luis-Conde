using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Enums
{
   public class Enums
    {

        public enum TypeState
        {
            //Usurio
            EstadoUsuario=1,
            EstadoPublicacion=2,
        }
        public enum State
        {
            //Usuario
            UsuarioActivo=1,
            UsuarioInactivo=2,
            UsuarioSuspendido=3,

            //productos
            LibroRevision=4,
            LibroRechazado=5,
            LibroAprobado=6,
        }

        public enum TypePermission
        {
            Usuarios=1,
            Roles=2,
            Permisos=3,
            Libreria=4,
            Estados=5,
           
        
        }

        public enum Permission
        {
            //usuarios
            CrearUsuarios=1,
            ActualizarUsuarios=2,
            EliminarUsuario=3,
            ConsultarUsuarios=4,

            //Roles
            ActualizarRoles=5,
            ConsultarRoles=6,

            //Permisos
            ActualizarPermisos=7,
            ConsultarPermisos=8,
            DenegarPermisos=9,

       

            //Libreria
            CrearPublicacion=10,
            ConsultarPublicacion=11,
            CancelarPublicacion=12,
            ActualizarPublicacion=13,

            //Estados
            ConsultarEstados=14,
            ActualizarEstado=15,
        }

        public enum RolUser
        {
            Administrador=1,
            Aprobador=2,
            Autor=3
             

        }

    }
}
