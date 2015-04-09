using System;

namespace ModuleSecond
{
    class Program
    {
        public const int Size = 8;

        static void Main(string[] args)
        {

            bool[,] checkDesk = new bool[Size,Size];


            bool init = true;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    checkDesk[i, j] = init;
                    init = !init;
                }
                init = !init;
            }

            Show(checkDesk);

            Console.ReadLine();
        }

        static void Show(bool[,] checkDesk)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(ConvertToFigure(checkDesk[i, j]));
                }
                Console.WriteLine();
            }
        }

        static Char ConvertToFigure(bool b)
        {
            return b ? 'X' : 'O';
        }
    }
}
