using System.Collections.Specialized;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace chessclass;

public class Game
{
    public static char[,] field = new char[8,8];
    private Piece Kingw = new Piece(Pieces.King, 'K', 0, 3);

    public void turn()
    {
        Piece.Move(Game.field, Pieces.King, 1, 2);
    }

    private void setfield()
    {
        for(int i = 0; i <8; i++)
        {
            if(i%2 == 0)
            {
                for(int j = 0; j<8; j++)
                {
                    if(j%2 == 0)
                    {
                        field[i, j] = ' ';
                    }
                    else
                    {
                        field[i, j] = '#';
                    }
                }
            }
            else
            {
                for(int j = 0; j<8; j++)
                {
                    if(j%2 == 0)
                    {
                        field[i, j] = '#';
                    }
                    else
                    {
                        field[i, j] = ' ';
                    }
                }
            }
        }

        field[Kingw.getxPos(), Kingw.getyPos()] = 'K';

    }

    public override string ToString()
    {
        setfield();
        string letters = "   a   b   c   d   e   f   g   h  ";
        string trennline = " +---+---+---+---+---+---+---+---+";
        string drawfield = letters + Environment.NewLine + trennline + Environment.NewLine;
        for(int i = 0; i <8; i++)
        {
            drawfield += i +1;
            drawfield += "|";
            for(int j = 0; j < 8; j++)
            {
                drawfield += $" {field[i, j] } |";
            }
            drawfield += Environment.NewLine + trennline + Environment.NewLine;
        }
        
        return drawfield;
    }
    
    
}

public class Piece
{
    private Pieces Figure;
    private char Symbol;

    King King = new King();

    private int[] Pos = new int[2];


    public Piece(Pieces fFigure, char fSymbol, int xPos, int yPos)
    {
        this.Figure = fFigure;
        this.Symbol = fSymbol;
        this.Pos[0] = xPos;
        this.Pos[1] = yPos;
    }

    public int getxPos() => this.Pos[0];

    public int getyPos() => this.Pos[1];

    public void Move(char[,] field, Pieces fPiece, /*int[] startpos,*/ int xdestPos, int ydestPos)
    {
        switch (Figure)
        {
            case Pieces.King: King.checkmove(Game.field, 'K', 1, 2); break;
        }
    }

}

public enum Pieces
{
    King,
    Queen
}