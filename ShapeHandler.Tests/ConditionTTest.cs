// <copyright file="ConditionTTest.cs">Copyright ©  2024</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;

namespace ShapeHandler.Objects.Tests
{
    /// <summary>This class contains parameterized unit tests for Condition`1</summary>
    [TestClass]
    [PexClass(typeof(Condition<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ConditionTTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Condition<T> ConstructorTest<T>()
        {
            Condition<T> target = new Condition<T>();
            return target;
        }

        /// <summary>Test stub for Equals(Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool EqualsTest<T>([PexAssumeUnderTest] Condition<T> target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
        }

        /// <summary>Test stub for GetHashCode()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int GetHashCodeTest<T>([PexAssumeUnderTest] Condition<T> target)
        {
            int result = target.GetHashCode();
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool Equals01<T>([PexAssumeUnderTest] Condition<T> target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
            // TODO: add assertions to method ConditionTTest.Equals01(Condition`1<!!0>, Object)
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int GetHashCode01<T>([PexAssumeUnderTest] Condition<T> target)
        {
            int result = target.GetHashCode();
            return result;
            // TODO: add assertions to method ConditionTTest.GetHashCode01(Condition`1<!!0>)
        }
    }
}
