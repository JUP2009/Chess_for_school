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
    public static char[,] nfield = new char[8,8];
    private Piece Kingw = new Piece(Pieces.King, 'K', 0, 3);
    private Piece Towerw1 = new Piece(Pieces.Tower, 'T', 0,0);
    private Piece Towerw2 = new Piece(Pieces.Tower, 'T', 0,7);



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
                        field[i, j] = 'E';
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
                        field[i, j] = 'E';
                    }
                }
            }
        }

        field[Kingw.getxPos(), Kingw.getyPos()] = 'K';
        field[Towerw1.getxPos(), Towerw1.getyPos()] = 'T';
        field[Towerw2.getxPos(), Towerw2.getyPos()] = 'T';
    }

    public void setnfield()
    {
        for(int i = 0; i <8; i++)
        {
            if(i%2 == 0)
            {
                for(int j = 0; j<8; j++)
                {
                    if(j%2 == 0)
                    {
                        nfield[i, j] = ' ';
                    }
                    else
                    {
                        nfield[i, j] = '#';
                    }
                }
            }
            else
            {
                for(int j = 0; j<8; j++)
                {
                    if(j%2 == 0)
                    {
                        nfield[i, j] = '#';
                    }
                    else
                    {
                        nfield[i, j] = ' ';
                    }
                }
            }
        }
    }
    public void turn(Pieces Piecef,int xstartPos, int ystartPos, int xdestPos, int ydestPos)
    {
        setfield();
        setnfield();
        switch (Piecef)
        {
            case Pieces.King: Kingw.Move(xstartPos, ydestPos, xdestPos, ydestPos);break;
        }
    }

    public override string ToString()
    {
        setfield();
        setnfield();
        string letters = "   a   b   c   d   e   f   g   h  ";
        string trennline = " +---+---+---+---+---+---+---+---+";
        string drawfield = letters + Environment.NewLine + trennline + Environment.NewLine;
        for(int i = 0; i <8; i++)
        {
            drawfield += i +1;
            drawfield += "|";
            for(int j = 0; j < 8; j++)
            {
                if(field[i, j] == 'E')
                {
                    drawfield += "   |";
                }
                else
                {
                    drawfield += $" {field[i, j] } |";  
                }
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

    public void Move(int xstartPos, int ystartPos, int xdestPos, int ydestPos)
    {
        switch (Figure)
        {
            case Pieces.King: 
                if(xdestPos < 0 || ydestPos < 0 || ydestPos > 8 || xdestPos > 8){ Console.WriteLine("zu hoch");break;}
                this.Pos = King.checkmove(xstartPos, ystartPos, xdestPos, ydestPos);
                break;
        }
    }

}

public enum Pieces
{
    King,
    Queen,
    Tower
}