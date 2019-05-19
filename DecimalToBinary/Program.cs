using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter in a series of decimal values (separated by spaces): ");

                string valuesInput = Console.ReadLine();
                Console.WriteLine();

                // Lines 18-24 create an array of decimals from the input provided from the user

                string[] inputAsAStringArray = valuesInput.Split(' ');
                decimal[] inputAsADecimalArray = new decimal[inputAsAStringArray.Length];

                for (int i = 0; i < inputAsAStringArray.Length; i++)
                {
                    inputAsADecimalArray[i] = decimal.Parse(inputAsAStringArray[i]);
                }

                for (int i = 0; i < inputAsADecimalArray.Length; i++) // A loop repeating the operations below on each of the 
                                                                      //elements of the input array
                {
                    Console.Write(inputAsADecimalArray[i] + " in binary is "); // writes a portion of the result message
              
                    /* Lines 34-38 determine if an element of the array is negative, if so it prints the "-" value 
                    that will come before the final binary value and then reassigns the element to its absolute value*/

                    if (inputAsADecimalArray[i] != Math.Abs(inputAsADecimalArray[i]))
                    {
                        Console.Write('-');
                        inputAsADecimalArray[i] = Math.Abs(inputAsADecimalArray[i]);
                    }

                    /* At this point, there are two branches to follow depending on whether the value  
                     entered was a decimal integer or a decimal fraction*/
                     
                    if (inputAsADecimalArray[i] == (int)inputAsADecimalArray[i]) // If the decimal type element is equivalent
                                                                                 //to its value when cast as an integer...
                    {
                        decimal inputValueToDivideStepOne = inputAsADecimalArray[i];    //These variables are declared outside the loops
                        decimal inputValueToDivideStepTwo = inputAsADecimalArray[i];    //because element [i] will be alter for two different purposes
                        int numberOfDigitsInBinaryNumber = 0;

                        /* STEP 1. 
                         The decimal to binary conversion is: 
                         1. Divide number by 2.
                         2. There will be a remainder of either 1 or 0. This will be the last digit of 
                             the binary number.
                         3. Repeat this until the integral (the 1's place) is 0. The last remainder value
                            will be the first digit.

                        A counter is used to determine the number of times the value
                        can be divided by 2 before it is 0 (as an integer casting). The total will be used as
                        the length of an array that will hold each digit of the binary number as an element */

                        while ((int)inputValueToDivideStepOne != 0) 
                        {
                            inputValueToDivideStepOne = inputValueToDivideStepOne / 2;
                            numberOfDigitsInBinaryNumber = numberOfDigitsInBinaryNumber + 1;
                        }

                        int[] binaryValueAsAnArray = new int[numberOfDigitsInBinaryNumber]; // This is said array

                        /* STEP 2. Now with an array initalized with the number of possible binary 
                         number digits, we use the modulus function to find if each digit is 1 or 0,
                         assigning the first value to the last element of the array and deincrementing */
                          
                        for (int j = (binaryValueAsAnArray.Length - 1); j >= 0; j--)
                        {
                            int binaryValue = (int)inputValueToDivideStepTwo % 2;
                            binaryValueAsAnArray[j] = binaryValue;
                            inputValueToDivideStepTwo = inputValueToDivideStepTwo / 2;
                        }

                        //Finally there is a loop that prints each element of the array, resulting in the final binary number
                         
                        for (int k = 0; k < binaryValueAsAnArray.Length; k++)
                        {
                            Console.Write(binaryValueAsAnArray[k]);
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    else //If the input value is a decimal fraction...
                    {
                        decimal leftSideOfFraction = (int)inputAsADecimalArray[i];                  //This ""splits"" the decimal into two values,
                        decimal rightSideOfFraction = inputAsADecimalArray[i] - leftSideOfFraction; //the integer and the fraction, as the binary conversion
                                                                                                    // for each is different
                        decimal leftSideToDivideStepOne = leftSideOfFraction;
                        decimal leftSideToDivideStepTwo = leftSideOfFraction;
                        int numberOfBinaryDigitsLeftSide = 0;

                        decimal rightSideToMultiply = rightSideOfFraction;
                        
                        //STEP 1. The integral portion of the binary value is found the same way as in above...

                        while ((int)leftSideToDivideStepOne != 0) 
                        {
                            leftSideToDivideStepOne = leftSideToDivideStepOne / 2;
                            numberOfBinaryDigitsLeftSide = numberOfBinaryDigitsLeftSide + 1;
                        }

                        int[] binaryValueAsAnArrayLeftSide = new int[numberOfBinaryDigitsLeftSide]; // An array that will hold the 
                                                                                                    // binary values to the left of the decimal point

                        // STEP 2. Same as above

                        for (int j = (binaryValueAsAnArrayLeftSide.Length - 1); j >= 0; j--)
                        {
                            int binaryValue = (int)leftSideToDivideStepTwo % 2;
                            binaryValueAsAnArrayLeftSide[j] = binaryValue;
                            leftSideToDivideStepTwo = leftSideToDivideStepTwo / 2;
                        }

                        for (int k = 0; k < binaryValueAsAnArrayLeftSide.Length; k++)  //Prints the binary value digits to the left of the decimal point
                        {
                            Console.Write(binaryValueAsAnArrayLeftSide[k]);
                        }

                        Console.Write("."); //Prints the decimal point

                        /* FINDING FRACTIONAL BINARY NUMBERS
                         1. Multiply the value by 2. The integral value (the 1's place, either 1 or 0) will be your
                            binary digit (this is not reversed, unlike finding integer binary numbers).
                         2. Repeat this until the fractional value (to the right of the decimal point) is zero.
                         3. In some cases, the fractional number will never equal zero (binary numbers can be infinite like 
                         decimals, ex. 0.3333333333) so a place limit has to be predetermined.
                         */
                         
                        int fractionBinaryLeftSideLimit = 0; //This is for the predetermined place limit counter
                     
                        while (((int)rightSideToMultiply != rightSideToMultiply) && fractionBinaryLeftSideLimit!=10)
                        /* If the integer casting of the fractional decimal does not equal the rightSideToMultiply
                        value after the contents of this loop completes, and the place limit counter is less than ten,
                        the while loop will continue*/
                        {
                            if ((int)rightSideToMultiply != 1)
                            {
                                rightSideToMultiply = rightSideToMultiply * 2;
                                Console.Write((int)rightSideToMultiply);    //Using an integer casting ensures the loop either prints a 1 or a 0
                            }
                            else  //This artificially removes the integral value if it is a 1
                            {
                                rightSideToMultiply = rightSideToMultiply - 1;
                                rightSideToMultiply = rightSideToMultiply * 2;
                                Console.Write((int)rightSideToMultiply);
                            }
                            fractionBinaryLeftSideLimit = fractionBinaryLeftSideLimit + 1; //This is our place counter
                        }
             
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                }

               
            }
            
        }
        
    }
}
