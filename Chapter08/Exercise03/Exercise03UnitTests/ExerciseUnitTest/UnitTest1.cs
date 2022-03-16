using Microsoft.VisualStudio.TestTools.UnitTesting;
using Packt.Shared;

namespace Exercise03UnitTest;

[TestClass]
public class  NumbersToWordsUnitTests
{
    // [TestMethod]
    // public void TestMethod1()
    // {
    // }
    [Fact]
    public void Test_Int32_0()
    {
      // arrange
      int number = 0;
      string expected = "zero";

      // act
      string actual = number.ToWords();

      // assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_Int32_1234()
    {
      // arrange
      int number = 1234;
      string expected = "one thousand, two hundred and thirty four";

      // act
      string actual = number.ToWords();

      // assert
      Assert.Equal(expected, actual);
    }
     [Fact]
    public void Test_BigInteger_18456002032011000007()
    {
      // arrange
      BigInteger number = BigInteger.Parse("18456002032011000007");
      string expected = "eighteen quintillion, four hundred and fifty six quadrillion, two trillion, thirty two billion, eleven million and seven";

      // act
      string actual = number.ToWords();

      // assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Test_Int32_minus_13()
    {
      // arrange
      int number = -13;
      string expected = "negative thirteen";

      // act
      string actual = number.ToWords();

      // assert
      Assert.Equal(expected, actual);
    }
}