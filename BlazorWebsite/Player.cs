namespace BlazorWebsite;

public class Player
{
    Random rnd = new();
    public int worth { get; set; }
    public double money { get; set; } = 20;
    public double bet { get; set; }
    public int hiddenCard { get; set; }
    public int aceCount { get; set; }

    public void IncreaseBet()
    {
        bet+=0.5;
    }

    public void DecreaseBet()
    {
        bet-=0.5;
    }

    public async Task AddPlayerCard()
    {
        int value = rnd.Next(2, 15);
        if (value >9 && value < 14)
        {
            value = 10;
        }
        else if (value == 14)
        {
            if (worth + value < 22)
            {
                value = 11;
                aceCount++;
            }
            else
                value = 1;
        }
        
        worth += value;
        await Task.Delay(300);
    }

    public void AddHiddenCard()
    {
        int value = rnd.Next(2, 14);
        if (value >9 && value < 14)
        {
            value = 10;
        }
        else if (value == 14)
        {
            value = 11;
        }

        hiddenCard = value;
    }

    public async Task CalcHidden()
    {
        worth += hiddenCard;
        await Task.Delay(300);
    }
}