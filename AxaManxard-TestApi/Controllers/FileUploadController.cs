using AxaManxard_TestApi.Model;
using AxaManxard_TestApi.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AxaManxard_TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IValidator<FileUploadModel> _validator;
        private readonly IExcelProcessingService _excelProcessingService;

        public FileUploadController(IValidator<FileUploadModel> validator, IExcelProcessingService excelProcessingService)
        {
            _validator = validator;
            _excelProcessingService = excelProcessingService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] FileUploadModel model)
        {
            var validationResult = _validator.Validate(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            try
            {
                using var memoryStream = new MemoryStream();
                await model.File.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                var processingResult = await _excelProcessingService.ProcessExcelAsync(memoryStream);

                return Ok(processingResult);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"An error occurred while processing the file: {ex.Message}");
            }
        }
    }
}