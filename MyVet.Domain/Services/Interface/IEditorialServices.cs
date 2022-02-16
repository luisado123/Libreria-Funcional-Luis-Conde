using Infraestructure.Entity.Models.Library;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IEditorialServices
    {
        List<EditorialEntity> GetAllEditorial();
        Task<ResponseDto> DeleteEditorialAsync(int idEditorial);
        Task<bool> InsertEditorialAsync(InsertEditorialDto editorial);
        Task<bool> UpdateEditorialAsync(EditorialDto data);
    }
}
