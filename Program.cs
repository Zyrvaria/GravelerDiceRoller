

class program
{
    static async Task Main(string[] args) 
    {
        DateTime start = DateTime.Now;
        int highestOnes = 0;
        int numOfTasks = 1000;
        int numOfRolls = 1000000;
        int[] results = new int[numOfTasks];
        Parallel.For(0, numOfTasks, i => {
            results[i] = Roll(numOfRolls);
        });
        highestOnes = results.Max();
        DateTime end = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds((end - start).TotalSeconds);
        string timeTaken = string.Format("{0:D2}m:{1:D2}s:{2:D3}ms", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        Console.WriteLine($"Rolled {highestOnes} ones over {numOfTasks*numOfRolls} rolls in {timeTaken}");
        Console.ReadLine();
    }
    static public int Roll(int numOfRolls) 
    {
        int maxOnes = 0;
        Random random = new Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < numOfRolls; i++) 
        {
            int numOfOnes = 0;
            for (int j = 0; j < 231; j++) 
            {
                if (random.Next(4) == 0) {
                    numOfOnes++;
                }
            }
            if(numOfOnes > maxOnes) 
            {
                maxOnes = numOfOnes;
            }
        }
        return maxOnes;
    }
}