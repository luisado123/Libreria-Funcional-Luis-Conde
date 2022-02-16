
using Common.Utils.Enums;
using Infraestructure.Entity.Model;
using Infraestructure.Entity.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infraestructure.Core.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        #region Builder
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        #endregion

        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTypeStateAsync();
            //await CheckTypeIdentificationAsync();
            await CheckTypePermissionAsync();
            await CheckStateAsync();
            await CheckRolAsync();
            await CheckPermissionAsync();
            await CheckRolPermissionAsync();
            //await CheckUserAsync();
            //await CheckRolUserAsync();
            //await CheckCategory();

        }

        private async Task CheckRolAsync()
        {
            if (!_context.RolEntity.Any())
            {
                _context.RolEntity.AddRange(new List<RolEntity>
                {
                    new RolEntity
                    {
                        IdRol = (int)Enums.RolUser.Administrador,
                        Rol = "Administrador"
                    },
                    new RolEntity
                    {
                        IdRol = (int)Enums.RolUser.Aprobador,
                        Rol = "Aprobador"
                    },
                     new RolEntity
                    {
                        IdRol = (int)Enums.RolUser.Autor,
                        Rol = "Estandar"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckTypeStateAsync()
        {
            if (!_context.TypeStateEntity.Any())
            {
                _context.TypeStateEntity.AddRange(new List<TypeStateEntity>
                {
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        TypeState="Estado de Usuarios"
                    },
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoPublicacion,
                        TypeState="Estado de las Publicaciones"
                    },
                });
                await _context.SaveChangesAsync();
            }

        }

        private async Task CheckStateAsync()
        {
            if (!_context.StateEntity.Any())
            {
                _context.StateEntity.AddRange(new List<StateEntity>
                {
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        IdState=(int)Enums.State.UsuarioActivo,
                        State="Activo"
                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        IdState=(int)Enums.State.UsuarioInactivo,
                        State="Inactivo"
                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        IdState=(int)Enums.State.UsuarioSuspendido,
                        State="Suspendido"
                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoPublicacion,
                        IdState=(int)Enums.State.LibroRevision,
                        State="Libro en Revision"

                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoPublicacion,
                        IdState=(int)Enums.State.LibroRechazado,
                        State="Libro Rechazado"
                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoPublicacion,
                        IdState=(int)Enums.State.LibroAprobado,
                        State="Libro Aprobado"
                    },
                });
                await _context.SaveChangesAsync(); //importantisimo esto para poder guardar datos
            }
        }

        private async Task CheckTypePermissionAsync()
        {
            if (!_context.TypePermissionEntity.Any())
            {
                _context.TypePermissionEntity.AddRange(new List<TypePermissionEntity>
                {
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        TypePermission="Usuarios"
                    },
                    new TypePermissionEntity
                    {
                         IdTypePermission=(int)Enums.TypePermission.Roles,
                        TypePermission="Roles"
                    },
                    new TypePermissionEntity
                    {
                         IdTypePermission=(int)Enums.TypePermission.Permisos,
                        TypePermission="Permisos"
                    },
                    new TypePermissionEntity
                    {
                         IdTypePermission=(int)Enums.TypePermission.Estados,
                        TypePermission="Estados"

                    },
                   
                       new TypePermissionEntity
                    {

                        IdTypePermission=(int)Enums.TypePermission.Libreria,
                        TypePermission="Libreria"

                    },
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPermissionAsync()
        {
            if (!_context.PermissionEntity.Any())
            {
                _context.PermissionEntity.AddRange(new List<PermissionEntity>
                {
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Crear Usuarios",
                        Description="Crear usuarios en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Actualizar Usuarios",
                        Description="Actualizar datos de un  usuarios en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarUsuario,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Eliminar Usuarios",
                        Description="Eliminar un usuario del Sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Consultar Usuarios",
                        Description="Consultar Todos Los usuarios"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Consultar Roles",
                        Description="Consultar Roles del sistema"
                    },
                     new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Actualizar Roles",
                        Description="Actualizar datos de Roles del sistema"
                    },
                      new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Actualizar Permisos",
                        Description="Actualizar datos de un permiso en el sistema"
                    },
                       new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Consultar Permisos",
                        Description="Consultar Permisos delsistema"
                    },
                        new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.DenegarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Denegar permisos Rol",
                        Description="Denegar Permisos a un rol del sistema"
                    },
                         new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Consultar Estado",
                        Description="Consultar Estados del sistema"
                    },
                          new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarEstado,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Actualizar Estados",
                        Description="Actualizar los estados del sistema"
                    },
                          
                               
                                  new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearPublicacion,
                        IdTypePermission=(int)Enums.TypePermission.Libreria,
                        Permission="Crear publicaciones",
                        Description="Crear  La informacion de las publicaciones de nuevos libros"
                    },
                                         new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarPublicacion,
                        IdTypePermission=(int)Enums.TypePermission.Libreria,
                        Permission="Consultar publicaciones",
                        Description="Consultar la informacion de las publicaciones de nuevos libros"
                    },
                        new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CancelarPublicacion,
                        IdTypePermission=(int)Enums.TypePermission.Libreria,
                        Permission="Cancelar Publicaciones",
                        Description="Cancelar una nueva Publicacion"
                    },
                                               new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarPublicacion,
                        IdTypePermission=(int)Enums.TypePermission.Libreria,
                        Permission="Actualizar Publicaciones",
                        Description="Actualizar la informacion de las Publicaciones"
                    },
                });
                await _context.SaveChangesAsync(); //importantisimo esto para poder guardar datos
            }

        }

        private async Task CheckRolPermissionAsync()
        {
            if (!_context.RolPermissionEntity.Where(x => x.IdRol == (int)Enums.RolUser.Administrador).Any())
            {
                var rolesPermisosAdmin = _context.PermissionEntity.Select(x => new RolPermissionEntity
                {
                    IdRol = (int)Enums.RolUser.Administrador,
                    IdPermission = x.IdPermission
                }).ToList();

                _context.RolPermissionEntity.AddRange(rolesPermisosAdmin);


                await _context.SaveChangesAsync();
            }
        }
    }
}

