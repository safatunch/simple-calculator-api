using gl_calculation.api.Controllers;
using gl_calculation.api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gl_calculation.api.tests.Controllers
{
    [TestFixture]
    public class SimpleCalculatorControllerTests
    {
        private readonly Mock<ISimpleCalculator> simpleCalculatorMock;
        private readonly SimpleCalculatorController simpleCalculatorController;

        public SimpleCalculatorControllerTests()
        {
            simpleCalculatorMock = new Mock<ISimpleCalculator>();

            simpleCalculatorController = new SimpleCalculatorController(simpleCalculatorMock.Object);
        }

        [Test]
        public void Add_Returns_Ok_Result_With_The_Sum()
        {
            simpleCalculatorMock.Setup(s => s.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(It.IsAny<int>());

            var res = simpleCalculatorController.Add(1, 2);

            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public void Add_Returns_BadRequest_When_Sum_Is_Exceeding_Int32()
        {
            simpleCalculatorMock.Setup(s => s.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Throws<ArgumentOutOfRangeException>();

            var res = simpleCalculatorController.Add(int.MaxValue, 5);

            Assert.IsInstanceOf<BadRequestObjectResult>(res);
        }


        [Test]
        public void Subtract_Returns_Ok_Result_With_The_Sum()
        {
            simpleCalculatorMock.Setup(s => s.Subtract(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(It.IsAny<int>());

            var res = simpleCalculatorController.Subtract(1, 2);

            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public void Subtract_Returns_BadRequest_When_Subtraction_Is_Exceeding_Int32()
        {
            simpleCalculatorMock.Setup(s => s.Subtract(It.IsAny<int>(), It.IsAny<int>()))
                .Throws<ArgumentOutOfRangeException>();

            var res = simpleCalculatorController.Subtract(int.MinValue, 5);

            Assert.IsInstanceOf<BadRequestObjectResult>(res);
        }
    }
}
