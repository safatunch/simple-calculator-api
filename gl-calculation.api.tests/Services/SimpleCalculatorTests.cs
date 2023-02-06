using gl_calculation.api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gl_calculation.api.tests.Services
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        ISimpleCalculator _simpleCalculator;

        public SimpleCalculatorTests()
        {
            _simpleCalculator = new SimpleCalculator();
        }

        [Test]
        [TestCase(5, 10, ExpectedResult = 15)]
        [TestCase(5, -7, ExpectedResult = -2)]
        public int Add_should_sum_values(int start, int amount)
        {
            return _simpleCalculator.Add(start, amount);
        }

        [Test]
        [TestCase(int.MaxValue, int.MaxValue)]
        public void Add_should_throw_exception_if_exceedes_int32_limits(int start, int amount)
        {
            Assert.That(() => _simpleCalculator.Add(start, amount), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(5, 10, ExpectedResult = -5)]
        [TestCase(5, 1, ExpectedResult = 4)]
        public int Subtract_should_subtract_values(int start, int amount)
        {
            return _simpleCalculator.Subtract(start, amount);
        }

        [Test]
        [TestCase(int.MinValue, 1)]
        public void Subtract_should_throw_exception_if_exceedes_int32_limits(int start, int amount)
        {
            Assert.That(() => _simpleCalculator.Subtract(start, amount), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
