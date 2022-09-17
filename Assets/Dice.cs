using System;

public class Dice
{
    public static int Roll()
    {
        Random rnd = new Random();
        int value = rnd.Next(1, 7);
        return value;
    }
}
