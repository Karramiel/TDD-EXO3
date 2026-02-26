using Exo3TDD;
using Mono.Cecil.Cil;
using System.Drawing;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DemoBaseTDD.Tests;


[TestClass]
public class RechercheVilleTest
{
    private List<string> _villesTest;
    private RechercheVille _recherche;

    [TestInitialize]
    public void Setup()
    {
        _villesTest = new List<string>
        {
            "Paris", "Budapest", "Skopje", "Rotterdam", "Valence",
            "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York",
            "Londres", "Bangkok", "Hong Kong", "Dubaï", "Rome", "Istanbul"
        };
        _recherche = new RechercheVille(_villesTest);
    }

    [TestMethod]
    public void Rechercher_TexteMoinsDe2Caracteres_LeveNotFoundException()
    {
        try
        {
            _recherche.Rechercher("a");

            Assert.Fail("Une exception de type NotFoundException aurait dû être levée.");
        }
        catch (NotFoundException)
        {
        }
        catch (Exception ex)
        {
            Assert.Fail($"Exception inattendue de type {ex.GetType().Name} levée.");
        }
    }

    [TestMethod]
    public void Rechercher_TexteEgalOuSuperieurA2Caracteres_RenvoieVillesCommencantParTexte()
    {
        // Act
        var result = _recherche.Rechercher("Va");

        // Assert
        //Assert.AreEqual(2, result.Count);
        //CollectionAssert.Contains(result, "Valence");
        CollectionAssert.Contains(result, "Vancouver");
    }

    [TestMethod]
    public void Rechercher_TexteRecherche_EstInsensibleALaCasse()
    {
        // Act
        var result = _recherche.Rechercher("va");

        // Assert
        //Assert.AreEqual(2, result.Count);
        //CollectionAssert.Contains(result, "Valence");
        CollectionAssert.Contains(result, "Vancouver");
    }

    [TestMethod]
    public void Rechercher_TexteEstUnePartieDuNom_RenvoieVilleCorrespondante()
    {
        // Act
        var result = _recherche.Rechercher("ape");

        // Assert
        //Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Budapest", result[0]);
    }

    [TestMethod]
    public void Rechercher_Asterisque_RenvoieToutesLesVilles()
    {
        // Act
        var result = _recherche.Rechercher("*");

        // Assert
        //Assert.AreEqual(_villesTest.Count, result.Count);
        CollectionAssert.AreEquivalent(_villesTest, result);
    }
}




//[TestClass]
//public class FiboTests
//{
//    // --- SCÉNARIO : Range de 1 ---

//    [TestMethod]
//    public void GetFibSeries_Range1_ResultIsNotEmpty()
//    {
//        // Arrange
//        var fib = new Fib(1);

//        // Act
//        List<int> result = fib.GetFibSeries();

//        // Assert
//        Assert.IsNotNull(result);
//        Assert.AreNotEqual(0, result.Count);
//    }

//    [TestMethod]
//    public void GetFibSeries_Range1_ReturnsListWithZero()
//    {
//        var fib = new Fib(1);
//        var expected = new List<int> { 0 };

//        List<int> result = fib.GetFibSeries();

//        CollectionAssert.AreEqual(expected, result);
//    }

//    // --- SCÉNARIO : Range de 6 ---

//    [TestMethod]
//    public void GetFibSeries_Range6_ContainsThree()
//    {
//        var fib = new Fib(6);

//        List<int> result = fib.GetFibSeries();

//        CollectionAssert.Contains(result, 3);
//    }

//    [TestMethod]
//    public void GetFibSeries_Range6_HasSixElements()
//    {
//        var fib = new Fib(6);

//        List<int> result = fib.GetFibSeries();

//        Assert.AreEqual(6, result.Count);
//    }

//    [TestMethod]
//    public void GetFibSeries_Range6_DoesNotContainFour()
//    {
//        var fib = new Fib(6);

//        List<int> result = fib.GetFibSeries();

//        CollectionAssert.DoesNotContain(result, 4);
//    }

//    [TestMethod]
//    public void GetFibSeries_Range6_ReturnsCorrectSequence()
//    {
//        var fib = new Fib(6);
//        var expected = new List<int> { 0, 1, 1, 2, 3, 5 };

//        List<int> result = fib.GetFibSeries();

//        CollectionAssert.AreEqual(expected, result);
//    }

//    [TestMethod]
//    public void GetFibSeries_Range6_IsSortedAscending()
//    {
//        var fib = new Fib(6);

//        List<int> result = fib.GetFibSeries();

//        // On compare la liste avec sa version triée
//        var sortedResult = result.OrderBy(x => x).ToList();
//        CollectionAssert.AreEqual(sortedResult, result);
//    }
//}





//[TestClass]
//public class CalculTest
//{
//    [TestMethod]
//    public void WhenAddition_42_7_Then_49()
//    {
//        var calcul = new Calcul();

//        var result = calcul.Addition(42, 7);

//        Assert.AreEqual(49, result);
//    }


//    [TestMethod]
//    public void WhenDivision_42_7_Then_6()
//    {
//        var calcul = new Calcul();
//        var result = calcul.Division(42, 7);
//        Assert.AreEqual(6, result);
//    }

//    [TestMethod]
//    public void WhenDivision_42_0_Then_Infinity()
//    {
//        var calcul = new Calcul();
//        var result = calcul.Division(42, 0);
//        Assert.AreEqual(double.PositiveInfinity, result);
//    }

//    [TestMethod]
//    public void WhenDivision_0_42_Then_0()
//    {
//        var calcul = new Calcul();
//        var result = calcul.Division(0, 42);
//        Assert.AreEqual(0, result);
//    }

//    [TestMethod]
//    public void WhenDivision_0_0_Then_NaN()
//    {
//        var calcul = new Calcul();
//        var result = calcul.Division(0, 0);
//        Assert.AreEqual(double.NaN, result);
//    }


//    [TestMethod]
//    public void WhenGetGrade_Score95_Attendance90_ReturnsA()
//    {
//        // Arrange
//        var calculator = new GradingCalculator();
//        calculator.Score = 95;
//        calculator.AttendancePercentage = 90;

//        // Act
//        var result = calculator.GetGrade();

//        // Assert
//        Assert.AreEqual('A', result);
//    }

//    [TestMethod]
//    public void WhenGetGrade_Score85_Attendance90_ReturnsB()
//    {
//        var calculator = new GradingCalculator();
//        calculator.Score = 85;
//        calculator.AttendancePercentage = 90;

//        var result = calculator.GetGrade();

//        Assert.AreEqual('B', result);
//    }

//    [TestMethod]
//    public void WhenGetGrade_Score65_Attendance90_ReturnsC()
//    {
//        var calculator = new GradingCalculator();
//        calculator.Score = 65;
//        calculator.AttendancePercentage = 90;

//        var result = calculator.GetGrade();

//        Assert.AreEqual('C', result);
//    }

//    [TestMethod]
//    public void WhenGetGrade_Score95_Attendance65_ReturnsB()
//    {
//        var calculator = new GradingCalculator();
//        calculator.Score = 95;
//        calculator.AttendancePercentage = 65;

//        var result = calculator.GetGrade();

//        Assert.AreEqual('B', result);
//    }

//    [TestMethod]
//    public void WhenGetGrade_Score95_Attendance55_ReturnsF()
//    {
//        var calculator = new GradingCalculator();
//        calculator.Score = 95;
//        calculator.AttendancePercentage = 55;

//        var result = calculator.GetGrade();

//        Assert.AreEqual('F', result);
//    }

//    [TestMethod]
//    public void WhenGetGrade_Score65_Attendance55_ReturnsF()
//    {
//        var calculator = new GradingCalculator();
//        calculator.Score = 65;
//        calculator.AttendancePercentage = 55;

//        var result = calculator.GetGrade();

//        Assert.AreEqual('F', result);
//    }

//    [TestMethod]
//    public void WhenGetGrade_Score50_Attendance90_ReturnsF()
//    {
//        var calculator = new GradingCalculator();
//        calculator.Score = 50;
//        calculator.AttendancePercentage = 90;

//        var result = calculator.GetGrade();

//        Assert.AreEqual('F', result);
//    }



