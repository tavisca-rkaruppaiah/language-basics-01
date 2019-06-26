

/*

Program Created By Ragu Balagi Karuppaiah.
Date : 21. 06. 2019

Second Assignment - FirstProgram (Tavisca)


*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment
{
    public static class FixMultiplication
    {
        static int missingDigit = 0, FirstNumber, SecondNumber, ResultNumber, FirstNewNumber, SecondNewNumber;
         

        public static int FindDigit(String equation)
        {
            string[] stringArrayFirst, stringArraySecond, digitsArray;

            stringArrayFirst = equation.Split('=');

            string equationFirstPart = stringArrayFirst[0];
            string equationSecondPart = stringArrayFirst[1];


            if (equationFirstPart.Contains('?'))
            {
                stringArraySecond = equationFirstPart.Split('*');
              
                string equationFirstPartOne = stringArraySecond[0];
                string equationFirstPartTwo = stringArraySecond[1];
                


                if (equationFirstPartOne.Contains('?'))
                {

                    missingDigit = FindMissingDigits(equationFirstPartOne, equationFirstPartTwo, equationFirstPart, equationSecondPart, 0);

                }
                else if (equationFirstPartTwo.Contains('?'))
                {

                    missingDigit = FindMissingDigits(equationFirstPartOne, equationFirstPartTwo, equationFirstPart, equationSecondPart, 1);

                }



            }
            else if (equationSecondPart.Contains('?'))
            {

                digitsArray = equationFirstPart.Split('*');

                if(digitsArray.Length == 2)
                {
                    int.TryParse(digitsArray[0], out FirstNumber);
                    int.TryParse(digitsArray[1], out SecondNumber);

                    ResultNumber = FirstNumber * SecondNumber;

                    string result = ResultNumber.ToString();

                    missingDigit = int.Parse(result[FindMissingPosition(equationSecondPart)].ToString());
                }

            }
            else
            {
                missingDigit = 0;
            }

            return missingDigit;
        }


        public static int FindMissingDigits(string equationPartOne, string equationPartTwo, string equationFirstPart, string equationSecondPart, int input)
        {
            string missingEquation = equationPartOne, divideEquation = equationSecondPart, otherPart=equationPartTwo;
            int missingPosition = 0;

            if(input == 0)
            {
                missingEquation = equationPartOne;
                divideEquation = equationSecondPart;
                otherPart = equationPartTwo;
            }
            else if(input == 1)
            {
                missingEquation = equationPartTwo;
                divideEquation = equationFirstPart;
                otherPart = equationPartOne;
            }



            if (int.Parse(equationSecondPart) % int.Parse(otherPart) == 0)
            {
               
                missingPosition = FindMissingPosition(missingEquation);

                string newEquation = missingEquation.Remove(missingPosition, 1);

                int.TryParse(otherPart, out FirstNewNumber);
                int.TryParse(newEquation, out SecondNewNumber);

                int NewResult = FirstNewNumber * SecondNewNumber;

                if (equationSecondPart.Equals(NewResult.ToString()))
                {
                    missingDigit = -1;
                }
                else
                {
                    int findMissingNumber = int.Parse(equationSecondPart) / FirstNewNumber;

                    string newresult = findMissingNumber.ToString();

                    char digit = newresult[missingPosition];

                    missingDigit = int.Parse(digit.ToString());


                }


            }
            else
            {
                missingDigit = -1;
            }

            return missingDigit;
        }

        public static int FindMissingPosition(string equation)
        {

            int missingPosition = equation.IndexOf("?");

            return missingPosition;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Equation");
            string equation = Console.ReadLine();
            Console.WriteLine(FixMultiplication.FindDigit(equation));
        }
    }
}
