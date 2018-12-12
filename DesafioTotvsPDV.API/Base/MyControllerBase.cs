using DesafioTotvsPDV.Data.Persistencia;
using DesafioTotvsPDV.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioTotvsPDV.API.Base
{
    public class MyControllerBase : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServiceBase _serviceBase;

        public MyControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [NonAction]
        public IActionResult ResponseSuccess(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;

            try
            {
                _unitOfWork.Commit();

                var x = Ok(result);

                return x;
            }
            catch (Exception ex)
            {

                return BadRequest($"Ocorreu um problema na operação no servidor: {ex.Message}");
            }

        }

        [NonAction]
        public IActionResult ResponseException(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (_serviceBase != null)
        //        _serviceBase.Dispose();

        //    base.Dispose();
        //}

    }
}
