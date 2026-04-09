using System;

namespace chessclass;

public class King
{
    private int xCord = 0, yCord = 0;
    public void checkPos(char[,] field, char Symbol)
    {
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if(field[i, j] == Symbol)
                {
                    xCord = i;
                    yCord = j;
                    break;
                }
            }
        }
    }

    public void checkmove(char[,] field, char Symbol, int newX, int newY)
    {
        checkPos(field, Symbol);

        if(Math.Abs(xCord - newX) == 1 && Math.Abs(yCord - newY) == 1)
        {
            Console.WriteLine("DONE!!!!");
        }
        else
        {
            throw new Exception("King cannot move to this field. Too far away");
        }
    }
    
}