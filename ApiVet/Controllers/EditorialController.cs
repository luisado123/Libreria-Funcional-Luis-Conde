using Common.Utils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Books;
using MyVet.Domain.Services;
using MyVet.Domain.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vet.Handlers;

namespace ApiVet.Controllers
{

    [Authorize]
    [Route("api/[controller]")]

    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class EditorialController : ControllerBase
    {
        #region Attribute
        private readonly IEditorialServices _editorialServices;
        #endregion

        #region Buider
        public EditorialController(IEditorialServices editorialServices)
        {
            _editorialServices = editorialServices;
        }
        #endregion


        /// <summary>
        /// Obtener todas las Editoriales
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllEditorial")]
        //[CustomPermissionFilter(Enums.Permission.ConsultarPublicacion)]
        public IActionResult GetAllEditorial()
        {

         

            ResponseDto response = new ResponseDto()
            {
                Success = true,
                Result = _editorialServices.GetAllEditorial(),
                Message = string.Empty
            };

            return Ok(response);

        }

        /// <summary>
        /// Eliminar una editorial
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteEditorial")]
        //[CustomPermissionFilter(Enums.Permission.CancelarPublicacion)]
        public async Task<IActionResult> DeleteEditorial(int idEditorial)
        {
            IActionResult response;
            ResponseDto result = await _editorialServices.DeleteEditorialAsync(idEditorial);

            if (result.Success)
                response = Ok(result);
            else
                response = BadRequest(result);

            return Ok(response);
        }
        /// <summary>
        /// Insertar una nueva editorial
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertEditorial")]
        //[CustomPermissionFilter(Enums.Permission.CrearCitas)]
        public async Task<IActionResult> InsertEditorial(InsertEditorialDto editorial)
        {
            IActionResult response;

            bool result = await _editorialServices.InsertEditorialAsync(editorial);
            ResponseDto responseDto = new ResponseDto()
            {
                Success = result,
                Result = result,
                Message = result ? GeneralMessages.EditorialInserted : GeneralMessages.EditorialInserted 
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }


        /// <summary>
        /// Actualizar una Editorial existente
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("UpdateEditorial")]
        //[CustomPermissionFilter(Enums.Permission.CrearCitas)]
        public async Task<IActionResult> UpdateEditorial(EditorialDto data)
        {
            IActionResult response;

            bool result = await _editorialServices.UpdateEditorialAsync(data);
            ResponseDto responseDto = new ResponseDto()
            {
                Success = result,
                Result = result,
                Message = result ? GeneralMessages.EditorialInserted : GeneralMessages.EditorialInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }



    }
}
