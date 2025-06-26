using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTests
    {
        [Fact(DisplayName = "Create product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product name", "Description product name", 10, 10, "Image product");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product name", "Description product name", 10, 10, "Image product");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }
        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Description product name", 10, 10, "Image product");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }
        [Fact]
        public void CreateProduct_NullNameValue_DomainExeptionRequiredName()
        {
            Action action = () => new Product(1, null, "Description product name", 10, 10, "Image product");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
        [Fact]
        public void CreateCategory_EmptyNameValue_DomainExeptionRequiredName()
        {
            Action action = () => new Product(1, "", "Description product name", 10, 10, "Image product");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
        [Fact]
        public void CreateProduct_NullDescriptionValue_DomainExeptionRequiredDescription()
        {
            Action action = () => new Product(1, "Product name", null, 10, 10, "Image product");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }
        [Fact]
        public void CreateProduct_EmptyDescriptionValue_DomainExeptionRequiredDescription()
        {
            Action action = () => new Product(1, "Product name", "", 10, 10, "Image product");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }
        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainExeptionRequiredInvalidPrice()
        {
            Action action = () => new Product(1, "Product name", "Description product name", -10, 10, "Image product");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }
        [Fact]
        public void CreateProduct_InvalidStockValue_DomainExeptionRequiredInvalidStock()
        {
            Action action = () => new Product(1, "Product name", "Description product name", 10, -10, "Image product");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }
        [Fact]
        public void CreateProduct_TooLongImageValue_DomainExeptionRequiredInvalidImage()
        {
            Action action = () => new Product(1, "Product name", "Description product name", 10, 10, "Image productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImageImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage productImage product");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }
        [Fact]
        public void CreateProduct_NoNullImageValue_DomainExeptionRequiredNoNullImage()
        {
            Action action = () => new Product(1, "Product name", "Description product name", 10, 10, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}