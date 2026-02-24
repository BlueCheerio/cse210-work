using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment mathhomework = new MathAssignment("7.3", "7-20","Timmy","Calculus" );
        WritingAssignment writinghomework = new WritingAssignment("Why the World goes round and round", "History IRL", "Sally");

        mathhomework.GetSummary();
        mathhomework.GetHomeworkList();
        Console.WriteLine();
        writinghomework.GetSummary();
        writinghomework.GetWritingInformation();
    }
}