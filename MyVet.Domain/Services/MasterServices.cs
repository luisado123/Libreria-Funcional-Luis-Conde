using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;
using Infraestructure.Entity.Model.Master;
using Infraestructure.Entity.Vet;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyVet.Domain.Services
{
    public class MasterServices : IMasterServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public MasterServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<StateEntity> GetAllState() => _unitOfWork.StateRepository.GetAll().ToList();

        public List<TypeBookEntity> GetAllTypeBook() => _unitOfWork.TypeBookRepository.GetAll().ToList();

    }
}
