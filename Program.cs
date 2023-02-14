﻿using System;
using System.IO;
using System.Linq;

namespace getOrderedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Leitura dos numeros dentro do arquivo de texto:
            
            string[] lines = File.ReadAllLines("unordered_values.txt");
            int[] numbers = Array.ConvertAll(lines, int.Parse);
            
            Console.WriteLine("Numeros obtidos do arquivo de texto:");
            Console.WriteLine(string.Join(", ", numbers));
            
            // Ordenação dos numeros dentro do vetor:

            int auxNumber, minNumber;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                minNumber = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minNumber])
                    {
                        minNumber = j;
                    }
                }
                if (minNumber != i)
                {
                    auxNumber = numbers[i];
                    numbers[i] = numbers[minNumber];
                    numbers[minNumber] = auxNumber;
                }
            }
            
            Console.WriteLine("Numeros obtidos no vetor:");
            Console.WriteLine(string.Join(", ", numbers));
            
            // Criação de uma lista com os numeros obtidos no vetor em ordem
            var sortedNumber = numbers.ToList();
            
            Console.WriteLine("Numeros ordenados e alocados no novo arquivo de texto:");
            Console.WriteLine(string.Join(", ", sortedNumber));
            
            // Verificação dos valores na lista e no vetor. Se forem iguais, escreve na tela que são iguais, se não, escreve que são diferentes.
            if (numbers.SequenceEqual(sortedNumber))
            {
                Console.WriteLine("Os valores presentes na lista e no vetor são iguais!");
            }
            else
            {
                Console.WriteLine("Os valores presentes na lista e no vetor são diferentes!");
            }
            
            // Insere os numeros já ordenados em um arquivo de texto secundário.
            File.WriteAllLines("ordered_values.txt", sortedNumber.Select(x => x.ToString()));
        }
    }

}
