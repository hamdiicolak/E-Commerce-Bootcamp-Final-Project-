using FluentValidation;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Validation
{
	public class NewProductValidator : AbstractValidator<NewProductViewModel>
	{
		public NewProductValidator()
		{
			RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("'Ürün Adı' alanı gereklidir")
				.MaximumLength(100).WithMessage("'Ürün Adı maksimum 100 karakter olmalı'");
			RuleFor(p => p.Price).NotNull().NotEmpty().WithMessage("'Ürün Fiyat' alanı gereklidir")
				.GreaterThan(0).WithMessage("'Ürün Fiyat'ı 0 dan büyük olmalı");
			RuleFor(p => p.CategoryId).NotNull().NotEmpty().WithMessage("'Kategori' alanı gereklidir");
			RuleFor(p => p.UsingStatusId).NotNull().NotEmpty().WithMessage("'Kullanım Durumu' alanı gereklidir");
			RuleFor(p => p.Size).NotNull().NotEmpty().WithMessage("'Beden' alanı gereklidir")
				.MaximumLength(5).WithMessage("'Beden' alanı en fazla 5 karakter olmalıdır");
			RuleFor(p => p.Description).NotNull().NotEmpty().WithMessage("Ürün hakkında kısa bir tanım girmeniz gereklidir")
				.MaximumLength(500).WithMessage("'Tanım' bilgisi en fazla 500 karater olmalıdır.");
			RuleFor(x => x.Image).SetValidator(new FileValidator());
		}
	}
}
