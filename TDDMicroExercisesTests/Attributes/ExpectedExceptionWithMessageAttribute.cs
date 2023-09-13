using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TDDMicroExercisesTests.Attributes
{
    /// <summary>
    ///  Attribute that specifies to expect an exception with message of the specified type
    /// </summary>
    public class ExpectedExceptionWithMessageAttribute : ExpectedExceptionBaseAttribute
    {
        /// <summary>
        /// Type of the expected exception
        /// </summary>
        public Type ExceptionType { get; set; }

        /// <summary>
        /// Exception message
        /// </summary>
        public string ExpectedMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the ExpectedExceptionWithMessageAttribute class with the expected type
        /// </summary>
        /// <param name="exceptionType">Type of the expected exception</param>
        public ExpectedExceptionWithMessageAttribute(Type exceptionType)
        {
            this.ExceptionType = exceptionType;
        }
        /// <summary>
        /// Initializes a new instance of the ExpectedExceptionWithMessageAttribute class with the expected type and message
        /// </summary>
        /// <param name="exceptionType">Type of the expected exception</param>
        /// <param name="expectedMessage">Exception message</param>
        public ExpectedExceptionWithMessageAttribute(Type exceptionType, string expectedMessage)
        {
            this.ExceptionType = exceptionType;
            this.ExpectedMessage = expectedMessage;
        }

        protected override void Verify(Exception e)
        {
            if (e.GetType() != this.ExceptionType)
            {
                Assert.Fail($"ExpectedExceptionWithMessageAttribute failed. Expected exception type: {this.ExceptionType.FullName}. " + $"Actual exception type: {e.GetType().FullName}. Exception message: {e.Message}");
            }

            var actualMessage = e.Message.Trim();
            if (this.ExpectedMessage != null)
            {
                Assert.AreEqual(this.ExpectedMessage, actualMessage);
            }
        }
    }
}
