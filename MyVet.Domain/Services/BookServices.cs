using Common.Utils.Enums;
using Common.Utils.Exceptions;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Library;
using MyLibrary.Domain.Services.Interface;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Services
{
   
    public  class BookServices:IBooksServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Builder
        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Methods

        public List<ConsultBooksDto> GetAllBooks()
        {
            var books = _unitOfWork.BooksRepository.GetAll(/*x => x.UserLibraryEntity.IdUser == idUser,*/
                                                             //p => p.UserLibraryEntity,
                                                             p => p.StateEntity,
                                                             p => p.TypeBookEntity);

            List<ConsultBooksDto> listBooks = books.Select(x => new ConsultBooksDto
            {
                IdBook = x.IdBook,
                DatePreRelease = x.DatePreRealease,
               DateRelease = x.DateRelease,
                Description = x.Description,
                AuthorName = x.AuthorName,
                Name = x.Name,
                IdState = x.IdState,
                State=x.StateEntity.State,
                IdEditorial = x.IdEditorial,
                StrLaunchDate = x.DateRelease == null ? "No disponible" : x.DateRelease.Value.ToString("yyyy-MM-dd"),
                estado = x.StateEntity.State,
                IdTypeBook = x.IdTypeBook,
                TypeBook=x.TypeBookEntity.TypeBook,
                StrPreLaunchDate = x.DatePreRealease.ToString("yyyy-MM-dd")
            }).ToList();

            return listBooks;
        }

        public async Task<ResponseDto> DeleteBooksAsync(int idBooks)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.BooksRepository.Delete(idBooks);
            response.Success = await _unitOfWork.Save() > 0;
            if (response.Success)
                response.Message = "Se elminnó correctamente el libro";
            else
                response.Message = "Hubo un error al eliminar el libro, por favor vuelva a intentalo";

            return response;
        }


        public async Task<bool> InsertBooksAsync(InsertBooksDto data)
        {
            if (data.Date.Date <= DateTime.Now.Date)
                throw new BusinessException("La fecha no puede ser inferior al dia actual");
           
            BooksEntity  books = new BooksEntity()
            {
                AuthorName = data.AuthorName,
                DatePreRealease = data.Date,
                Description = data.Description,
                Name = data.Name,
                IdTypeBook = data.IdTypeBook,
                IdState = /*data.IdState*/(int)Enums.State.LibroRevision,
                IdEditorial =data.IdEditorial,
            
            };
            _unitOfWork.BooksRepository.Insert(books);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateBooksAsync(BookDto data)
        {
            bool result = false;

           BooksEntity books = _unitOfWork.BooksRepository.FirstOrDefault(x => x.IdBook == data.IdBook);
            if (books != null)
            {
                books.AuthorName = data.AuthorName;
                books.DatePreRealease = data.DatePreRelease.Value;
                books.Description = data.Description;
                books.Name = data.Name;
                books.IdTypeBook = data.IdTypeBook;
                books.IdState = data.IdState;//(int)Enums.State.LibroRevision
                books.IdEditorial = data.IdEditorial;
                _unitOfWork.BooksRepository.Update(books);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }



        #endregion
    }
}
