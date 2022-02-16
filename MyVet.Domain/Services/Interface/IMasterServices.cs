using Infraestructure.Entity.Model;
using Infraestructure.Entity.Model.Master;
using Infraestructure.Entity.Vet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Services.Interface
{
    public interface IMasterServices
    {
        List<StateEntity> GetAllState();
        List<TypeBookEntity> GetAllTypeBook();
    }
}
