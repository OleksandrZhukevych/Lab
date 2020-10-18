using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VectorWork;
using System.Linq;
using System.CodeDom;

namespace ConsoleWorkTest
{
    [TestClass]
    public class VectorTest
    {

        [TestMethod]
        public void Init_Dimensions_Of_List_And_Vector_AreEquel()
        {
            //Arrange
            double n = 2;
            List<double> coord = new List<double>();
            Vector vector = new Vector(n, coord);
            bool expected = true;

            //Act
            coord.Add(1);
            coord.Add(2);
            bool actual = Vector.isValid(n, coord);

            //Assert
            Assert.AreEqual(expected, actual, "Cant initialise this vector");
        }

        [TestMethod]
        public void Init_Dimensions_Of_List_And_Vector_AreNotEquel_Should_Throw_ArgumentOutOfRangeException() {
            //Arrange
            double n = 2;
            List<double> coord = new List<double>();
            Vector vector = new Vector(n, coord);
            bool expected = false;

            //Act
            coord.Add(1);
            coord.Add(2);
            coord.Add(3);
            bool actual = Vector.isValid(n, coord);

            //Assert
            Assert.AreEqual(expected, actual, "Can't initialise this vector");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Addition_Of_Vectors_With_Different_Dimensions_Should_Throw_ArgumentOutOfRangeException()
        {
            //Arrange
            double N1 = 2;
            double N2 = 3;
            List<double> coord1 = new List<double>() { 3, 1 };
            List<double> coord2 = new List<double>() { 1, 2, 3};
            List<double> res1 = new List<double>();

            //Act
            Vector vector1 = new Vector(N1, coord1);
            Vector vector2 = new Vector(N2, coord2);
            Vector.Addition(vector1, vector2);

            //Assert
        }
        
        [TestMethod]
        public void Addition_Of_Vectors()
        {
            //Arrange
            double N1 = 3;
            double N2 = 3;
            List<double> coord1 = new List<double>() { 3, 1, 1};
            List<double> coord2 = new List<double>() { 1, 2, 3};
            List<double> res1 = new List<double>() { 4, 3 ,4};
            bool expected = true;

            //Act
            Vector vector1 = new Vector(N1, coord1);
            Vector vector2 = new Vector(N2, coord2);
            List<double> res2 = Vector.Addition(vector1, vector2);
            bool actual = res1.SequenceEqual(res2);

            //Assert
            Assert.AreEqual(expected, actual, "Vectors cant be added");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Subtraction_Of_Vectors_With_Different_Dimensions_Should_Throw_ArgumentOutOfRangeException()
        {
            //Arrange
            double N1 = 2;
            double N2 = 3;
            List<double> coord1 = new List<double>() { 3, 1 };
            List<double> coord2 = new List<double>() { 1, 2, 3 };

            //Act
            Vector vector1 = new Vector(N1, coord1);
            Vector vector2 = new Vector(N2, coord2);
            Vector.Subtraction(vector1, vector2);

            //Assert
        }

        [TestMethod]
        public void Substraction_Of_Vectors()
        {
            //Arrange
            double N1 = 3;
            double N2 = 3;
            List<double> coord1 = new List<double>() { 3, 1, 1 };
            List<double> coord2 = new List<double>() { 1, 2, 3};
            List<double> res1 = new List<double>() { 2, -1, -2};
            List<double> res2 = new List<double>();
            bool expected = true;

            //Act
            Vector vector1 = new Vector(N1, coord1);
            Vector vector2 = new Vector(N2, coord2);
            res2 = Vector.Subtraction(vector1, vector2);
            bool actual = res1.SequenceEqual(res2);

            //Assert
            Assert.AreEqual(expected, actual, "Vectors cant be subtracted");
        }
        
        [TestMethod]
        public void Multiplication()
        {
            //Arrange
            double N1 = 3;
            double l = 4;
            List<double> coord1 = new List<double>() { 3, 1, 1};
            List<double> res1 = new List<double>() { 12, 4, 4};
            bool expected = true;

            //Act
            Vector vector1 = new Vector(N1, coord1);
            List<double> res2 = vector1.Multipication(l);
            bool actual = res1.SequenceEqual(res2);

            //Assert
            Assert.AreEqual(expected, actual, "Vector cant be multiplied");
        }

            
        [TestMethod]
        public void Module()
        {
            //Arrange
            double n = 3;
            List<double> coord1 = new List<double>() { 3, 1, 1 };
            Vector vector1 = new Vector(n, coord1);
            double res1 = 3.31662;
            double res2;

            //Act
            res2 = vector1.Module();

            //Assert
            Assert.AreEqual(res1, res2, 0.001, "Module cant be complited");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Scalar_Multiplication_Of_Vectors_With_Different_Dimensions_Should_Throw_ArgumentOutOfRangeException()
        {
            //Arrange
            double N1 = 2;
            double N2 = 3;
            List<double> coord1 = new List<double>() { 3, 1 };
            List<double> coord2 = new List<double>() { 1, 2, 3 };

            //Act
            Vector vector1 = new Vector(N1, coord1);
            Vector vector2 = new Vector(N2, coord2);
            Vector.Scalar(vector1, vector2);

            //Assert

        }

        [TestMethod]
        public void Scalar()
        {
            //Arrange
            double N1 = 3;
            double N2 = 3;
            List<double> coord1 = new List<double>() { 3, 1 , 1};
            List<double> coord2 = new List<double>() { 1, 2, 3};
            double res1 = 8;

            //Act
            Vector vector1 = new Vector(N1, coord1);
            Vector vector2 = new Vector(N2, coord2);
            double res2 = Vector.Scalar(vector1, vector2);

            //Assert
            Assert.AreEqual(res1, res2, 0.001, "Scalar multiplication cant be done");
        }
     
        [TestMethod]
        public void If_Dimensions_Of_Vectors_Are_Equal() {
            //Arrange
            double n = 2;
            List<double> coord1 = new List<double>() { 2, 7};
            Vector vector1 = new Vector(n,coord1);
            Vector vector2 = new Vector(n,coord1);
            bool expected = true;

            //Act
            bool actual = vector1.AreDimensionsEqual(vector2);

            //Assert
            Assert.AreEqual(expected, actual, "Dimensions of vectors are not equal");
        }

        [TestMethod]
        public void If_Dimensions_Of_Vectors_Are_Not_Equal()
        {
            //Arrange
            double n1 = 2, n2 = 4;
            List<double> coord1 = new List<double>() { 2, 7 };
            List<double> coord2 = new List<double>() { 2, 7, 7, 6 };
            Vector vector1 = new Vector(n1, coord1);
            Vector vector2 = new Vector(n2, coord2);
            bool expected = false;

            //Act
            bool actual = vector1.AreDimensionsEqual(vector2);

            //Assert
            Assert.AreEqual(expected, actual, "Dimensions of vectors are equal");
        }

        [TestMethod]
        public void Two_Vectors_AreEquel()
        {
            //Arrange
            double n = 2;
            List<double> coord = new List<double>() { 7, 9 };
            bool expected = true;

            //Act
            Vector vector1 = new Vector(n, coord);
            Vector vector2 = new Vector(n, coord);
            bool actual = Vector.Comparison(vector1, vector2);

            //Assert
            Assert.AreEqual(expected, actual, "Two vectors are not equel");
        }

        [TestMethod]
        public void Two_Vectors_AreNotEquel_By_Coord()
        {
            //Arrange
            double n = 2;
            List<double> coord1 = new List<double>() { 8, 9 };
            List<double> coord2 = new List<double>() { 8, 2 };
            bool expected = false;

            //Act
            Vector vector1 = new Vector(n, coord1);
            Vector vector2 = new Vector(n, coord2);
            bool actual = Vector.Comparison(vector1, vector2);

            //Assert
            Assert.AreEqual(expected, actual, "Two vectors are equel");
        }

        [TestMethod]
        public void Two_Vectors_AreNotEquel_By_Dimensions()
        {
            //Arrange
            double n1 = 2, n2 = 4;
            List<double> coord1 = new List<double>() { 7, 9 };
            List<double> coord2 = new List<double>() { 8, 7, 7, 9 };
            bool expected = false;

            //Act
            Vector vector1 = new Vector(n1, coord1);
            Vector vector2 = new Vector(n2, coord2);
            bool actual = Vector.Comparison(vector1, vector2);

            //Assert
            Assert.AreEqual(expected, actual, "Two vectors are equel");
        }
    }
}
