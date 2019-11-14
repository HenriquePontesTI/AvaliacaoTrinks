using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_Sortudos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número para descobrir se ele é Sortudo ou Feliz : ");
            int num;
            string numDigitado = Console.ReadLine();
            Console.WriteLine("");

            if (Int32.TryParse(numDigitado, out num))
            {
                if (EhFeliz(num) && EhSortudo(num))
                    Console.WriteLine("{0} – Número Sortudo e Feliz.", num);
                else if (!EhFeliz(num) && EhSortudo(num))
                    Console.WriteLine("{0} – Número Sortudo e Não-Feliz.", num);
                else if (EhFeliz(num) && !EhSortudo(num))
                    Console.WriteLine("{0} – Número Não-Sortudo e Feliz.", num);
                else if (!EhFeliz(num) && !EhSortudo(num))
                    Console.WriteLine("{0} – Número Não-Sortudo e Não-Feliz", num);
            }
            else
                Console.WriteLine("O número digitado não é um número!");

            Console.WriteLine("Pressione qualquer tecla para fechar o programa.");
            Console.ReadKey();
        }

        private static bool EhFeliz(int num)
        {
            for (int i = 1; i <= 100; i++)
            {
                var lista = num.ToString().ToCharArray();
                double resultado = 0;

                foreach (var item in lista)
                {
                    resultado += Math.Pow(double.Parse(item.ToString()), 2);
                }

                if (resultado == 1)
                {
                    return true;
                }
                else
                {
                    num = Int32.Parse(resultado.ToString());
                }
            }

            return false;
        }

        private static bool EhSortudo(int num)
        {
            List<int> lista = new List<int>();

            for (int i = 1; i <= num; i++)
            {
                lista.Add(i);
            }

            lista.RemoveAll(x => (x % 2 == 0));

            for (int i = 1; i < lista.Count; i++)
            {
                int multi = lista[i];

                int x = 1;

                while (true)
                {
                    var quadrado = Math.Pow(multi, x);

                    if (quadrado < lista.Count)
                    {
                        lista.RemoveAt(int.Parse(quadrado.ToString()) - 1);
                        x++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return lista.Contains(num);
        }
    }
}
