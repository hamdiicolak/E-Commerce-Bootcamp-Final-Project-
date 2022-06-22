using FluentValidation;

namespace ProductCatalog.UI.Validation
{
	public class FileValidator : AbstractValidator<IFormFile>
	{
		public FileValidator()
		{
			RuleFor(x => x.FileName).NotNull().NotEmpty().WithMessage("Lütfen ürün için bir resim seçiniz.");
			RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(400000).WithMessage("Image Size ı 400 kb dan fazla olamaz");
			RuleFor(x => x.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
			   .WithMessage("File type is larger than allowed");
		}
	}
}
