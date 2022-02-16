using Common.Utils.Enums;
using Common.Utils.Helpers;
using Common.Utils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Domain.Services;
using MyLibrary.Domain.Services.Interface;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vet.Handlers;
using static Common.Utils.Constant.Const;

namespace ApiVet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
 
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class BooksController : ControllerBase
    {
        #region Attribute
        private readonly IBooksServices _bookServices;
        #endregion

        #region Buider
        public BooksController(IBooksServices bookServices)
        {
            _bookServices = bookServices;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Obtener todos los libros publicados un usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllBooks")]
       // [CustomPermissionFilter(Enums.Permission.ConsultarPublicacion)]
        public IActionResult GetAllBooks()
        {
            
            List<ConsultBooksDto> list = _bookServices.GetAllBooks();

            ResponseDto response = new ResponseDto()
            {
                Success = true,
                Result = list,
                Message = string.Empty
            };

            return Ok(response);

        }


        /// <summary>
        /// Eliminar un libro de un usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteBooks")]
        //[CustomPermissionFilter(Enums.Permission.CancelarPublicacion)]
        public async Task<IActionResult> DeleteBooks(int idBooks)
        {
            IActionResult response;
            ResponseDto result = await _bookServices.DeleteBooksAsync(idBooks);

            if (result.Success)
                response = Ok(result);
            else
                response = BadRequest(result);

            return Ok(response);
        }

        /// <summary>
        /// Subir un nuevo libro para revisar
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertBooks")]
        //[CustomPermissionFilter(Enums.Permission.CrearCitas)]
        public async Task<IActionResult> InsertBooks(InsertBooksDto data)
        {
            IActionResult response;

            bool result = await _bookServices.InsertBooksAsync(data);
            ResponseDto responseDto = new ResponseDto()
            {
                Success = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }

        /// <summary>
        /// Actualizar LA info de un libro
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateDatesVet")]
      //  [CustomPermissionFilter(Enums.Permission.ActualizarCitasVeterinario)]
        public async Task<IActionResult> UpdateBooks(BookDto data)
        {
            IActionResult response;
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);
          //  data.IdEditorial = Convert.ToInt32(idUser);
            bool result = await _bookServices.UpdateBooksAsync(data);
            ResponseDto responseDto = new ResponseDto()
            {
                Success = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }












        #endregion
    }
}
