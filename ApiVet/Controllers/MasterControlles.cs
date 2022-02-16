using Common.Utils.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using Vet.Handlers;

namespace ApiVet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]

    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class MasterController : ControllerBase
    {
        #region Attribute
        private readonly IMasterServices _masterServices;
        #endregion

        #region Buider
        public MasterController(IMasterServices masterServices)
        {
            _masterServices = masterServices;
        }
        #endregion


        /// <summary>
        /// Obtener todos los estados disponibles
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllState")]
        //[CustomPermissionFilter(Enums.Permission.ConsultarPublicacion)]
        public IActionResult GetAllState()
        {



            ResponseDto response = new ResponseDto()
            {
                Success = true,
                Result = _masterServices.GetAllState(),
                Message = string.Empty
            };

            return Ok(response);

        }

        /// <summary>
        /// Obtener todos los tipos de libros
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllTypeBook")]
       // [CustomPermissionFilter(Enums.Permission.ConsultarPublicacion)]
        public IActionResult GetAllTypeBook()
        {



            ResponseDto response = new ResponseDto()
            {
                Success = true,
                Result = _masterServices.GetAllTypeBook(),
                Message = string.Empty
            };

            return Ok(response);

        }


    }
}
