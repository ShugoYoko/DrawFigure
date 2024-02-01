using DrawFigure.Con;
namespace DrawFigure.Con.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var neko = new Neko();
        neko.SayHello();
    }
}