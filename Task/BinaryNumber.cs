/*
 2. Постановка задачи
Требуется разработать консольное приложение, в котором описать
класс, работающий с одномерным массивом.
Класс должен содержать:
- конструктор с параметрами: количество элементов массива, диапазон
значений элементов массива;
- конструктор с параметрами: количество элементов массива;+
- методы, описанные в задании;
- свойство, доступное только для чтения, описанное в задании;
Вывод значения, возвращаемого свойством, выполнять в методе Main.
Сконструировать несколько объектов класса различными способами.
Продемонстрировать работу методов и свойств.
6. Класс описывает одномерный массив, состоящий из n целых
элементов со значениями 0 и 1 (биты двоичного числа).
Методы класса должны:
- вычислять сумму элементов массива;+
- вычислять десятичное значение двоичного числа.+
Свойство должно получать максимально возможное десятичное
значение+
*/

public class BinaryNumber
{
    private int[] _array;
    private int _bitDepth;
    /// <summary>
    /// Максимальное возможное число для данной разрядности
    /// </summary>
    /// <returns></returns>
    public int MaxValue()
    {
        return (int)(Math.Pow(2, this._bitDepth) - 1);
    }
    public int GetDecimalValue()
    {
        return BinaryToDecimal(_array);
    }
    static public int BinaryToDecimal(int[] binaryArray)
    {
        int decimalValue = 0;
        int power = binaryArray.Length - 1;

        for (int i = 0; i < binaryArray.Length; i++)
        {
            decimalValue += binaryArray[i] * (int)Math.Pow(2, power);
            power--;
        }

        return decimalValue;
    }
    // Конструктор, который будет делать двоичный код заданного числа
    public BinaryNumber(int number)
    {
        _bitDepth = GetIntBitCount(number);
        _array = GetBinaryArray(number, _bitDepth);
    }
    public BinaryNumber(int[] array, int bitDepth)
    {
        _array = array;
        _bitDepth = bitDepth;
    }
    public BinaryNumber()
    {
        _bitDepth = 32;
        _array= new int[_bitDepth];
    }
    public void SetBinaryCode(int[] binaryCode )
    {
        _array = binaryCode;
    }
    /// <summary>
    /// Определяет разрядность положительного числа INT
    /// </summary>
    /// <param name="number">число формата INT</param>
    /// <returns></returns>
    static public int DecimalSumOfBinaryNumber(int[] binaryNumberFirst, int[] binaryNumberSecond)
    {
        return BinaryToDecimal(SumOfBinaryNumber(binaryNumberFirst, binaryNumberSecond));
    }
    static public int[] SumOfBinaryNumber(int[] binaryNumberFirst, int[] binaryNumberSecond)
    {
        int carry = 0;
        int maxLength = Math.Max(binaryNumberFirst.Length, binaryNumberSecond.Length);
        int[] result = new int[maxLength + 1];

        for (int i = 0; i < maxLength; i++)
        {
            int sum = carry;
            if (i < binaryNumberFirst.Length)
                sum += binaryNumberFirst[i];
            if (i < binaryNumberSecond.Length)
                sum += binaryNumberSecond[i];

            result[i] = sum % 2;
            carry = sum / 2;


            if (i == maxLength - 1 && carry > 0)
                result[i + 1] = carry;
        }

        return result;
    }

    static public int GetIntBitCount(int number)
    {
        int bitCount = 0;
        int quotient = number;
        do
        {
            quotient = quotient / 2; // Делим на 2
            bitCount++; // Увеличиваем счетчик битов
        }
        while (quotient > 0);
        return bitCount;
    }
    /// <summary>
    /// Преобразует в int массив бинарный код заданного числа
    /// </summary>
    /// <param name="number">заданное число, которое надо преоброзовать</param>
    /// <param name="bitCount">В какую разрядность (по стандарту 32-х)</param>
    /// <returns></returns>
    static public int[] GetBinaryArray(int number, int bitCount = 32)
    {
        int[] binaryArray = new int[bitCount];

        for (int i = 0; i < bitCount; i++)
        {
            binaryArray[i] = (number >> i) & 1;
        }

        Array.Reverse(binaryArray); // Меняем порядок элементов на обратный (старшие биты в начале массива)
        return binaryArray;
    }
}

