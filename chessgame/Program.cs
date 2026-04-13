using chessclass;

namespace Program;

public class Program1
{
    public static int Main()
    {
        Game chess = new Game();
   
        chess.turn();
        System.Console.WriteLine(chess.ToString());
        return 0;
    }
}