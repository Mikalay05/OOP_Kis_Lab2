namespace Task
{
    internal class Program
    {

        static void Main()
        {
            // Создаем объект класса BinaryNumber с помощью различных конструкторов
            BinaryNumber binary1 = new BinaryNumber(42); // Создаем объект с двоичным представлением числа 42
            BinaryNumber binary2 = new BinaryNumber(new int[] { 1, 0, 1, 0 }, 4); // Создаем объект с заданным двоичным массивом и разрядностью

            // Выводим значения свойств объектов
            Console.WriteLine("Максимальное возможное десятичное значение: " + binary1.MaxValue());
            Console.WriteLine("Десятичное значение двоичного числа: " + binary1.GetDecimalValue());

            // Устанавливаем новый бинарный код для объекта binary2
            binary2.SetBinaryCode(new int[] { 1, 1, 0, 0 });

            // Выводим новое значение свойства объекта binary2
            Console.WriteLine("Десятичное значение нового бинарного числа: " + binary2.GetDecimalValue());

            // Вычисляем сумму двух бинарных чисел
            int[] binarySum = BinaryNumber.SumOfBinaryNumber(new int[] { 1, 0, 1 }, new int[] { 0, 1, 1 });
            Console.Write("Сумма двоичных чисел: ");
            foreach (int bit in binarySum)
            {
                Console.Write(bit);
            }
            Console.WriteLine(); // Переход на новую строку

            // Вычисляем десятичное значение суммы двух бинарных чисел
            int decimalSum = BinaryNumber.DecimalSumOfBinaryNumber(new int[] { 1, 0, 1 }, new int[] { 0, 1, 1 });
            Console.WriteLine("Десятичное значение суммы двоичных чисел: " + decimalSum);
        }
    }
}