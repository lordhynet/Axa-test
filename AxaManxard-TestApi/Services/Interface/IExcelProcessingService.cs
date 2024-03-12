using AxaManxard_TestApi.Model;

namespace AxaManxard_TestApi.Services.Interface
{
    public interface IExcelProcessingService
    {
        Task<ExcelProcessingResult> ProcessExcelAsync(Stream fileStream);
    }
}
