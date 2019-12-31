using System.Collections.Generic;

namespace HackerRank
{
    public class GradingStudents
    {
        public static List<int> gradingStudents(List<int> grades)
        {
            if (grades == null || grades.Count == 0)
            {
                return grades;
            }

            int magicNumber = 5;
            int difference = 2; // less than 3
            int failingGrade = 38;

            List<int> result = new List<int>();
            foreach (int grade in grades)
            {
                int diffToRound = magicNumber - (grade % magicNumber);
                if (grade < failingGrade ||
                    (grade % magicNumber) == 0 ||
                    diffToRound > difference)
                {
                    result.Add(grade);
                }
                else
                {
                    result.Add(grade + diffToRound);
                }
            }
            return result;
        }

    }
}