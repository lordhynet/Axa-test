using FluentValidation;

namespace AxaManxard_TestApi.Model
{
    public class FileUploadValidator : AbstractValidator<FileUploadModel>
    {
        public FileUploadValidator()
        {
            RuleFor(x => x.File)
           .NotNull()
           .WithMessage("Please upload a file.");

            When(x => x.File != null, () =>
            {
                RuleFor(x => x.File)
                    .Must(f => Path.GetExtension(f.FileName).ToLower() == ".xlsx")
                    .WithMessage("File must be in .xlsx format.");
            });
        }
    }

}
