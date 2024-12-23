using MemoryManagementInDS.Week5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace UnitTestProjectForOOPCourse
{
    internal class TestForFractionClass
    {

        [Fact]
        public void Constructor_ValidFraction_SimplifiesCorrectly()
        {
            Fraction fraction = new Fraction(2, 4);
            object value = Assert.Equals(1, fraction.Numerator);
            Assert.Equals(2, fraction.Denominator);
        }

        [Fact]
        public void Constructor_ZeroDenominator_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Fraction(1, 0));
        }

        [Fact]
        public void Operator_Addition_ReturnsCorrectResult()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 4);
            Fraction result = f1 + f2;

            Assert.Equals(3, result.Numerator);
            Assert.Equals(4, result.Denominator);
        }

        [Fact]
        public void Operator_Subtraction_ReturnsCorrectResult()
        {
            Fraction f1 = new Fraction(3, 4);
            Fraction f2 = new Fraction(1, 4);
            Fraction result = f1 - f2;

            Assert.Equals(1, result.Numerator);
            Assert.Equals(2, result.Denominator);
        }

        [Fact]
        public void Operator_Multiplication_ReturnsCorrectResult()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(3, 4);
            Fraction result = f1 * f2;

            Assert.Equals(1, result.Numerator);
            Assert.Equals(2, result.Denominator);
        }

        [Fact]
        public void Operator_Division_ReturnsCorrectResult()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(3, 4);
            Fraction result = f1 / f2;

            Assert.Equals(8, result.Numerator);
            Assert.Equals(9, result.Denominator);
        }

        [Fact]
        public void Operator_Division_ByZeroNumerator_ThrowsDivideByZeroException()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(0, 1);

            Assert.ThrowsException<DivideByZeroException>(() => f1 / f2);
        }

        [Fact]
        public void Operator_Equality_ReturnsTrueForEqualFractions()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(2, 4);

            Assert.IsTrue(f1 == f2);
        }

        [Fact]
        public void Operator_Inequality_ReturnsTrueForUnequalFractions()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 3);

            Assert.IsTrue(f1 != f2);
        }

        [Fact]
        public void Operator_LessThan_ReturnsCorrectResult()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(2, 3);

            Assert.IsTrue(f1 < f2);
        }

        [Fact]
        public void Operator_GreaterThan_ReturnsCorrectResult()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(1, 2);

            Assert.IsTrue(f1 > f2);
        }

        [Fact]
        public void Operator_LessThanOrEqual_ReturnsCorrectResult()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(2, 4);

            Assert.IsTrue(f1 <= f2);
        }

        [Fact]
        public void Operator_GreaterThanOrEqual_ReturnsCorrectResult()
        {
            Fraction f1 = new Fraction(2, 4);
            Fraction f2 = new Fraction(1, 2);

            Assert.IsTrue(f1 >= f2);
        }

        [Fact]
        public void ToString_SimplifiedFraction_ReturnsCorrectString()
        {
            Fraction f = new Fraction(2, 4);
            Assert.Equals("1/2", f.ToString());
        }

        [Fact]
        public void ToString_WholeNumberFraction_ReturnsCorrectString()
        {
            Fraction f = new Fraction(4, 2);
            Assert.Equals("2", f.ToString());
        }
    }
}
