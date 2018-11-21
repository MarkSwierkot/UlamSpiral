using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlamSpiral
{

    class Program
    {
        public static int arraySize = 9; 

        // arraySize must odd number! When its odd, you can find row and column for which distance between left and right, and top and
        // bottom border is the same

        public static bool isPrimeNumber(int number)
        {
            int dividers = 0;

            for(int i = 1; i <= number; i++)
            {
                if(number%i == 0)
                {
                    dividers++;
                }
            }

            if (number == 1) // from the definition of prime numbers - 1 is not prime
                return false;
            
            if (dividers == 2)
                return true;
            else
                return false;
        }



        // Directions for moving around array starting from its very center: Rigth, Up, Left, Down
        // Vectors    1,1,2,2,3,3,4,4 
        // Movement: right, up, left, left, down down, right, right, right, up, up, up, left, left, left, left, down, down, down, down

  
        public static int MoveRight(int width)
        {
            int value = width+1;
            return value;
        }
        public static int MoveLeft(int width)
        {
            int value = width - 1;
            return value;
        }
        public static int MoveUp(int height)
        {
            int value = height - 1;
            return value;
        }
        public static int MoveDown(int height)
        {
            int value = height  + 1;
            return value;
        }


        public static void UlamSpiral(int arraySize)
        {
            int widthInit, heightInit;
            int[,] UlamArray = new int[arraySize, arraySize];

            widthInit = arraySize / 2; 
            heightInit = arraySize / 2;

            int shift = 1;
            int movement = 1;
            int pom = 2;
            int liczba = 0;

            for(int g = 0; g < arraySize ; g++)
            {
                if(g == arraySize-1)
                {
                    pom = 1;
                }

                for (int i = 0; i < pom; i++)
                {
                    for (int j = 0; j < shift; j++)
                    {
                        liczba++;

                        if (movement == 1)
                        {
                            UlamArray[widthInit, heightInit] = liczba;
                            widthInit = MoveRight(widthInit);
                        }
                        if (movement == 2)
                        {
                            UlamArray[widthInit, heightInit] = liczba;
                            heightInit = MoveUp(heightInit);
                        }
                        if (movement == 3)
                        {
                            UlamArray[widthInit, heightInit] = liczba;
                            widthInit = MoveLeft(widthInit);
                        }
                        if (movement == 4)
                        {    
                            UlamArray[widthInit, heightInit] = liczba;
                            heightInit = MoveDown(heightInit);
                        }



                    }

                    if (movement == 4)
                    {
                        movement = 0;
                    }
                    movement++;
                }
                shift++;
               
            }
            

            for(int i = 0; i < arraySize; i++)
            {
                for(int j = 0; j < arraySize; j++)
                {
                    if(UlamArray[j,i] == 1)
                    {
                        Console.Write(" o ");
                    }
                    if (isPrimeNumber(UlamArray[j, i]) == true)
                    {
                        Console.Write(" + ");
                    }
                   else Console.Write("   ");
                }
                Console.WriteLine("\n");
            }
        }

        static void Main(string[] args)
        {

            UlamSpiral(35);
         
            Console.ReadKey();


        }
    }
}
