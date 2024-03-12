using AxaManxard_TestApi.Model;
using AxaManxard_TestApi.Services.Interface;
using ClosedXML.Excel;

namespace AxaManxard_TestApi.Services.Implementation
{
    public class ExcelProcessingService : IExcelProcessingService
    {
        public async Task<ExcelProcessingResult> ProcessExcelAsync(Stream fileStream)
        {
            if (fileStream.CanSeek)
            {
                fileStream.Position = 0;
            }

            return await Task.Run(() =>
            {
                using var workbook = new XLWorkbook(fileStream);
                var worksheet = workbook.Worksheet(1);
                var numbers = worksheet.RangeUsed().RowsUsed().Skip(1) 
                                .Select(row => row.Cell(1).GetValue<int>())
                                .ToList();

                var result = new ExcelProcessingResult
                {
                    DivisibleBy2 = numbers.Where(n => n % 2 == 0).ToList(),
                    DivisibleBy7 = numbers.Where(n => n % 7 == 0).ToList(),
                    DivisibleBy3 = numbers.Where(n => n % 3 == 0).ToList(),
                    Mode = CalculateMode(numbers),
                    Median = CalculateMedian(numbers),
                    ShortestSeriesTo65 = FindSubsetWithTargetSum(numbers, 65),
                    ShortestSeriesTo35 = FindSubsetWithTargetSum(numbers, 35),
                    SumOfOddNumbers = numbers.Where(n => n % 2 != 0).Sum(),
                    SumOfEvenNumbers = numbers.Where(n => n % 2 == 0).Sum(),
                    SumOfSingleDigitNumbers = numbers.Where(n => n >= 0 && n < 10).Sum(),
                    SumOfDoubleDigitNumbers = numbers.Where(n => n >= 10 && n < 100).Sum(),
                };

                return result;
            });
        }

        private List<int> CalculateMode(List<int> numbers)
        {
            var groupedNumbers = numbers.GroupBy(n => n).Select(group => new { Number = group.Key, Count = group.Count() });
            var maxCount = groupedNumbers.Max(g => g.Count);
            return groupedNumbers.Where(g => g.Count == maxCount).Select(g => g.Number).ToList();
        }

        private double CalculateMedian(List<int> numbers)
        {
            var sortedNumbers = numbers.OrderBy(n => n).ToList();
            int size = sortedNumbers.Count;
            int mid = size / 2;
            if (size % 2 == 0)
            {
                return (sortedNumbers[mid] + sortedNumbers[mid - 1]) / 2.0;
            }
            else
            {
                return sortedNumbers[mid];
            }
        }
        public List<int> FindSubsetWithTargetSum(List<int> numbers, int targetSum)
        {
            var subsets = new Queue<List<int>>();
            subsets.Enqueue(new List<int>()); 

            foreach (var number in numbers)
            {
                int currentLevelSize = subsets.Count;
                for (int i = 0; i < currentLevelSize; i++)
                {
                    var currentSubset = subsets.Dequeue();

                    if (currentSubset.Sum() == targetSum)
                        return currentSubset;

                    subsets.Enqueue(new List<int>(currentSubset)); 

                    var newSubset = new List<int>(currentSubset) { number };
                    subsets.Enqueue(newSubset); 

                    if (newSubset.Sum() == targetSum)
                        return newSubset;
                }
            }
            return new List<int>();
        }
    }
}
