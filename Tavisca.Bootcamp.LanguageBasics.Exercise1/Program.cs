using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
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
