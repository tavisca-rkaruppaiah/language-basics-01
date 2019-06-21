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
    public class FixMultiplication
    {

        // Declaring the Variables

        int missingDigit=0, pos, FirstNumber, SecondNumber, ResultNumber, FirstNewNumber, SecondNewNumber, NewResult;
        string[] stringArrayFirst, stringArraySecond, digitsArray;

        // method 

        public int FindDigit(String equation)
        {

            //Split the Equation
           
            stringArrayFirst = equation.Split('=');

            string partone = stringArrayFirst[0];
            string parttwo = stringArrayFirst[1];
           
           // Check the conditions Equation have any Questionmark

            if(partone.Contains('?'))
            {

                //Split the two part of numbers

                stringArraySecond = partone.Split('*');

                string partoneone = stringArraySecond[0];
                string partonetwo = stringArraySecond[1];


                if(partoneone.Contains('?'))
                {

                    if(int.Parse(parttwo) % int.Parse(partonetwo) == 0)
                    {
                        pos = partoneone.IndexOf('?');

                        string newpart = partoneone.Remove(pos, 1);
                        FirstNewNumber = int.Parse(partonetwo);
                        SecondNewNumber = int.Parse(newpart);

                     

                            int NewResult = FirstNewNumber * SecondNewNumber;

                            if (parttwo.Equals(NewResult.ToString()))
                            {
                                missingDigit = -1;
                            }
                            else
                            {
                                int second = int.Parse(parttwo) / FirstNewNumber;

                                string newresult = second.ToString();

                                char digit = newresult[pos];

                                missingDigit = int.Parse(digit.ToString());

                                
                            }

                           
                    }
                    else
                    {
                        missingDigit = -1;
                    }




                }
                else if(partonetwo.Contains('?'))
                {
                 
                    if(int.Parse(parttwo) % int.Parse(partoneone) == 0)
                    {
                        pos = partonetwo.IndexOf('?');


                        string newpart = partonetwo.Remove(pos, 1);
                        FirstNewNumber = int.Parse(partoneone);
                        SecondNewNumber = int.Parse(newpart);

                        NewResult = FirstNewNumber * SecondNewNumber;

                            if (parttwo.Equals(NewResult.ToString()))
                            {
                                missingDigit = -1;
                            }
                            else
                            {
                                int second = int.Parse(parttwo) / FirstNewNumber;

                                string newresult = second.ToString();

                                char digit = newresult[pos];

                                missingDigit = int.Parse(digit.ToString());

                            }

                    }
                    else
                    {
                        missingDigit = -1;
                    }
                    

                }
                
                

            }
            else if(parttwo.Contains('?'))
            {
                pos = parttwo.IndexOf('?');
                
                digitsArray = partone.Split('*');

                FirstNumber = int.Parse(digitsArray[0]);

                SecondNumber = int.Parse(digitsArray[1]);

                ResultNumber = FirstNumber * SecondNumber;

                string result = ResultNumber.ToString();

                missingDigit = int.Parse(result[pos].ToString());
                
            }
            else
            {
                missingDigit = 0;
            }

            return missingDigit;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Equation");
            string equ = Console.ReadLine();

            // Create the object of class
            FixMultiplication fixMultiplication = new FixMultiplication();
            Console.WriteLine(fixMultiplication.FindDigit(equ));
        }
    }
}
