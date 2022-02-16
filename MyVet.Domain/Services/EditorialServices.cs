using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Books;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
   public class EditorialServices:IEditorialServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditorialServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<EditorialEntity> GetAllEditorial() => _unitOfWork.EditorialRepository.GetAll().ToList();


        public async Task<ResponseDto> DeleteEditorialAsync(int idEditorial)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.EditorialRepository.Delete(idEditorial);
            response.Success = await _unitOfWork.Save() > 0;
            if (response.Success)
                response.Message = "Se elminnó correctamente el la editorial";
            else
                response.Message = "Hubo un error al eliminar la Editorial, por favor vuelva a intentalo";

            return response;
        }

        public async Task<bool> InsertEditorialAsync(InsertEditorialDto data)
        {
          

            EditorialEntity editorial = new EditorialEntity()
            {
                Direction = data.Direction,
                Name = data.Name,
               
              
               

            };
            _unitOfWork.EditorialRepository.Insert(editorial);

            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> UpdateEditorialAsync(EditorialDto data)
        {
            bool result = false;

            EditorialEntity editorial = _unitOfWork.EditorialRepository.FirstOrDefault(x => x.Id == data.Id);
            if (editorial != null)
            {
               editorial.Direction = data.Direction;
               editorial.Name = data.Name;
             
                _unitOfWork.EditorialRepository.Update(editorial);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

    }
}
