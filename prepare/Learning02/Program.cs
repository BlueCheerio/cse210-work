using System;

class Program
{
    static void Main(string[] args)
    {
        Job job = new Job();
        job._jobTitle = "Garbage Man";
        job._company = "Garbage Inc.";
        job._startYear = 1492;
        job._endYear = 2020;

        Job job2 = new Job();
        job2._jobTitle = "Super Smart Guy";
        job2._company = "Smarty Pants Co.";
        job2._startYear = 2026;
        job2._endYear = 2027;

        Resume resume1 = new Resume();
        resume1._name = "Austin Cope";
        resume1._job.Add(job);
        resume1._job.Add(job2);
        resume1.Display();

    }
}