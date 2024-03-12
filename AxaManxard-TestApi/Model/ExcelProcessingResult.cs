namespace AxaManxard_TestApi.Model
{
    public class ExcelProcessingResult
    {
        public List<int> DivisibleBy2 { get; set; }
        public List<int> DivisibleBy7 { get; set; }
        public List<int> DivisibleBy3 { get; set; }
        public List<int> Mode { get; set; }
        public double Median { get; set; }
        public List<int> ShortestSeriesTo65 { get; set; }
        public List<int> ShortestSeriesTo35 { get; set; }
        public int SumOfOddNumbers { get; set; }
        public int SumOfEvenNumbers { get; set; }
        public int SumOfSingleDigitNumbers { get; set; }
        public int SumOfDoubleDigitNumbers { get; set; }
    }
}
