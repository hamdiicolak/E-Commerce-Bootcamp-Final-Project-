using FluentValidation;
namespace ProductCatalog.Application.Features.Products.Commands.New_Product
{
	public class NewProductCommandValidator : AbstractValidator<NewProductCommandRequest>
	{
		public NewProductCommandValidator()
		{
			RuleFor(p => p.Name).NotEmpty().WithMessage("'Ürün Adı' alanı gereklidir")
				.MaximumLength(100).WithMessage("'Ürün Adı maksimum 100 karakter olmalı'");
			RuleFor(p => p.Price).NotEmpty().WithMessage("'Ürün Fiyat' alanı gereklidir")
				.GreaterThan(0).WithMessage("'Ürün Fiyat'ı 0 dan büyük olmalı");
			RuleFor(p => p.CategoryId).NotEmpty().WithMessage("'Kategori' alanı gereklidir");
			RuleFor(p => p.UsingStatusId).NotEmpty().WithMessage("'Kullanım Durumu' alanı gereklidir");
			RuleFor(p => p.Size).NotEmpty().WithMessage("'Beden' alanı gereklidir")
				.MaximumLength(5).WithMessage("'Beden' alanı en fazla 5 karakter olmalıdır");
			RuleFor(p => p.Description).NotEmpty().WithMessage("Ürün hakkında kısa bir tanım girmeniz gereklidir")
				.MaximumLength(500).WithMessage("'Tanım' bilgisi en fazla 500 karater olmalıdır.");
		}
	}
}
