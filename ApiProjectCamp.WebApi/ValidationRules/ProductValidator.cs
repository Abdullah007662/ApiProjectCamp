using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez.!");
            RuleFor(x=>x.ProductName).MinimumLength(2).WithMessage("En Az 2 Karakter Veri Girişi Yapın.!");
            RuleFor(x=>x.ProductName).MaximumLength(50).WithMessage("En Fazla 50 Karakter Veri Girişi Yapın.!");
        }
    }
}
