using System;

namespace Lab_3_C_
{
    internal class Program
    {
      
        static void Main()
        {
            double X, function,sumForN,sumForE;
            double E =0.0001;
            for (X = 1.0; X < 2.1; X+= 0.1) //Перебор X
            {
                sumForN = 1;
                double buffForN = 1;
                for (int i = 1; i <= 15; i++) //Вычисление суммированием 15 элементов ряда
                {
                    buffForN *= X;
                    buffForN /= i;
                    sumForN += buffForN;
                }

                sumForE = 1+X;//Сумма с двумя первыми элементами 
                int counter = 1;
                double buffE_SecondElement = 1*X*X/(counter+1);//Вычисление третьего элемента ряда
                double buffE_Firstelement;
                do //Суммирование по точности E
                {
                  counter++;
                  buffE_Firstelement = buffE_SecondElement;
                  buffE_SecondElement = buffE_Firstelement * X / (counter + 1);  //Вычисление следующего элемента ряда       
                  sumForE += buffE_Firstelement;
                } while (Math.Abs(buffE_SecondElement - buffE_Firstelement) >= E) ;
                 function = Math.Pow(Math.E, X);
                Console.WriteLine("X={0} SN={2} SE={3} Y={1}",X,function,sumForN,sumForE);//Вывод в консоль 
            }

        }
    }
}


/*
      static double GetElementOfRow(double x, int n) 
      {
          double elementOfRow = 1;
          if (n==0) return 1.0;
          if (n > 0) 
          {
              for (int i = 1; i <= n; i++) 
              {
                  elementOfRow *=x;
                  elementOfRow /= i;
              }
              return elementOfRow;
          }
          return 0.0;
      } 
      */