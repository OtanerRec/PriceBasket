using AutoFixture;
using FluentAssertions;
using PriceBasket.Discounts.Implementations;
using PriceBasket.Models;
using System.Collections.Generic;
using Xunit;

namespace PriceBasket.UnitTests.Discounts
{
    public class DiscountServiceTests
    {
        private readonly Fixture fixture;
        private readonly DiscountService discountService;

        public DiscountServiceTests()
        {
            this.fixture = new Fixture();
            this.discountService = new DiscountService();
        }

        [Fact]
        public void DiscountCalculation_InvalidProducts_EmptyListOfDiscounts()
        {
            //Arrange
            var product1 = this.fixture.Build<Product>().Create();
            var product2 = this.fixture.Build<Product>().Create();

            var products = new List<Product>() { product1, product2 };

            //Act
            var result = this.discountService.DiscountCalculation(products);

            //Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void DiscountCalculation_ValidListOfProducts_ReturnListOfDiscounts()
        {
            //Arrange
            var product1 = new Product("apples", 1);
            var product2 = new Product("bread", 1);

            var products = new List<Product>() { product1, product2 };

            //Act
            var result = this.discountService.DiscountCalculation(products);

            //Assert
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void DiscountCalculation_ValidListOfProducts_ReturnsAnExpectedDiscountList()
        {
            //Arrange
            var product = new Product("apples", 1.00m);
            product.AddQuantity(1);

            var products = new List<Product>() { product};

            var discountValue = 0.10m;
            var discountDescription = "Apples 10% OFF: -" + $"{ discountValue}";

            var discount = new Discount();
            discount.CreateDiscount(discountValue, discountDescription);

            var discounts = new List<Discount>() { discount };

            //Act
            var result = this.discountService.DiscountCalculation(products);

            //Assert
            result.Should().BeEquivalentTo(discounts);
            result.Count.Should().Be(1);
        }

        [Fact]
        public void DiscountCalculation_ValidListOfProducts_ReturnsAllPossibleDiscounts()
        {
            //Arrange
            var product1 = new Product("apples", 1.00m);
            var product2 = new Product("bread", 0.80m);
            var product3 = new Product("soup", 0.65m);
            product1.AddQuantity(1);
            product2.AddQuantity(1);
            product3.AddQuantity(2);

            var products = new List<Product>() { product1, product2, product3 };

            var discountValue1 = 0.10m;
            var discountDescription1 = "Apples 10% OFF: -" + $"{ discountValue1}";

            var discount1 = new Discount();
            discount1.CreateDiscount(discountValue1, discountDescription1);

            var discountValue2 = 0.40m;
            var discountDescription2 = "Bread 50% OFF: -" + $"{ discountValue2}";

            var discount2 = new Discount();
            discount2.CreateDiscount(discountValue2, discountDescription2);

            var discounts = new List<Discount>() { discount1, discount2 };

            //Act
            var result = this.discountService.DiscountCalculation(products);

            //Assert
            result.Should().BeEquivalentTo(discounts);
            result.Count.Should().Be(2);
        }
    }
}
