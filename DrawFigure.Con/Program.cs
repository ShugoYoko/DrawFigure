

namespace DrawFigure.Con;

internal class Program
{
    private const string BITMAP_PATH = @".\generated_cat.png";
    static void Main(string[] args)
    {
        CatDrawer drawer = new CatDrawer();
        drawer.Draw(BITMAP_PATH);
        var plot = new PlotDrawer();
    }


}
        





