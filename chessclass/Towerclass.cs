namespace chessclass;

public class Tower
{
    public int[] checkmove(int oldX, int oldY, int newX, int newY)
    {
        if (Math.Abs(newX - oldX) <= 1 && Math.Abs(newY - oldY) <= 1)
        {
            Console.WriteLine($"Target: '{Game.field[newX,newY]}'");

            if (Game.field[newX, newY] == 'E' || Game.field[newX, newY] == '#')
            {
                Game.field[oldX, oldY] = Game.nfield[oldX, oldY];
                return [newX, newY];
            }
            else
            {
                throw new Exception("Field not free");
            }
        }
        else
        {
            throw new Exception("Field too far away");
        }
        return null;
    }
}