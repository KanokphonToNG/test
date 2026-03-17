class Student
{
    private double score;

    public double Score
    {
        get { return score; }
        set
        {
            if (value >= 0 && value <= 100)
                score = value;
            else
                Console.WriteLine("Invalid score!");
        }
    }
}