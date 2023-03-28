using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bukva3 // это ПЗ_3 задание 28
                 // если считать 21 задание как задание для первого в списке, то задание 28 соответствует моему варианту (8)
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        class Rational
        {
            private int chislitel;
            private int znamenatel;

            public Rational(int chislitel, int znamenatel)
            {
                this.chislitel = chislitel;
                this.znamenatel = znamenatel;
            }

            public void Read()
            {
                Console.WriteLine("Введите числитель: ");
                chislitel = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите знаменатель: ");
                znamenatel = int.Parse(Console.ReadLine());
            }

            public void Display()
            {
                Console.WriteLine($"{chislitel}/{znamenatel}");
            }

            private int GetNOD(int a, int b) //находит НОД - наибольший общий делитель
            {
                if (b == 0)
                {
                    return a;
                }

                return GetNOD(b, a % b);
            }

            private void Reduce() // делит, чтобы получить несократимую дробь
            {
                int nod = GetNOD(chislitel, znamenatel);

                chislitel /= nod;
                znamenatel /= nod;
            }

            public Rational Add(Rational other) //+плюс
            {
                int newChislitel = chislitel * other.znamenatel + other.chislitel * znamenatel;
                int newZnamenatel = znamenatel * other.znamenatel;

                Rational result = new Rational(newChislitel, newZnamenatel);
                result.Reduce();

                return result;
            }

            public Rational Subtract(Rational other) //-минус
            {
                int newChislitel = chislitel * other.znamenatel - other.chislitel * znamenatel;
                int newZnamenatel = znamenatel * other.znamenatel;

                Rational result = new Rational(newChislitel, newZnamenatel);
                result.Reduce();

                return result;
            }

            public Rational Multiply(Rational other) //*умножить
            {
                int newChislitel = chislitel * other.chislitel;
                int newZnamenatel = znamenatel * other.znamenatel;

                Rational result = new Rational(newChislitel, newZnamenatel);
                result.Reduce();

                return result;
            }

            public Rational Divide(Rational other) // /делить
            {
                int newChislitel = chislitel * other.znamenatel;
                int newZnamenatel = znamenatel * other.chislitel;

                Rational result = new Rational(newChislitel, newZnamenatel);
                result.Reduce();

                return result;
            }

            public bool Equal(Rational other) // =равенство
            {
                Rational reducedThis = new Rational(chislitel, znamenatel);
                reducedThis.Reduce();

                Rational reducedOther = new Rational(other.chislitel, other.znamenatel);
                reducedOther.Reduce();

                return reducedThis.chislitel == reducedOther.chislitel && reducedThis.znamenatel == reducedOther.znamenatel;
            }

            public bool GreaterThan(Rational other) //>больше
            {
                int newChislitel1 = chislitel * other.znamenatel;
                int newChislitel2 = other.chislitel * znamenatel;

                return newChislitel1 > newChislitel2;
            }

            public bool LessThan(Rational other) //<меньше
            {
                int newChislitel1 = chislitel * other.znamenatel;
                int newChislitel2 = other.chislitel * znamenatel;

                return newChislitel1 < newChislitel2;
            }

        }
    }
}
