using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Domain.Services;
using MyLibrary.Domain.Services.Interface;
using MyVet.Domain.Services;
using MyVet.Domain.Services.Interface;

namespace ApiVet.Handlers
{
   
        public  class DependencyInyectionHandler
        {


            public static void DependencyInyectionConfig(IServiceCollection services)
            {

                services.AddScoped<UnitOfWork, UnitOfWork>();

                //Infraestructure
                services.AddTransient<IUnitOfWork, UnitOfWork>();

                services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
                //esto es lo mismo que creamos en el startup,ahora solo bastara con inyectar  esta dependencia en 
                //Startup.cs
                services.AddTransient<SeedDb>();

                //Domain,es decir los servicios
                services.AddTransient<IUserServices, UserServices>();
                services.AddTransient<IRolServices, RolServices>();
                services.AddTransient<IBooksServices, BookServices>();
            services.AddTransient<IEditorialServices, EditorialServices>();
            services.AddTransient<IMasterServices, MasterServices>();
               
            }
        }
    }

