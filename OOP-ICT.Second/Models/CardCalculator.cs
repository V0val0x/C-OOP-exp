using OOP_ICT.Models;


namespace OOP_ICT.Second.Models;

public class CardCalculator
{
    private const int LowAce = 2, HighAce = 11, HandMax = 21;
    private static readonly Dictionary<CardValues, int> CardValuesMapping = new Dictionary<CardValues, int>
    {
        { CardValues.Ace, 0 },    // Значение для Ace
        { CardValues.King, 10 },  // Значение для King
        { CardValues.Queen, 10 }, // Значение для Queen
        { CardValues.Jack, 10 },  // Значение для Jack
        { CardValues.Ten, 10 },   // Значение для Ten
        { CardValues.Nine, 9 },   // Значение для Nine
        { CardValues.Eight, 8 },  // Значение для Eight
        { CardValues.Seven, 7 },  // Значение для Seven
        { CardValues.Six, 6 },    // Значение для Six
        { CardValues.Five, 5 },   // Значение для Five
        { CardValues.Four, 4 },   // Значение для Four
        { CardValues.Three, 3 },  // Значение для Three
        { CardValues.Two, 2 }     // Значение для Two
    };

    public static int CalculateSum(CardValues[] cards)
    {
        int sum = 0;
        int acesCount = 0;
        foreach (var card in cards)
        {
            int value;
            if (CardValuesMapping.TryGetValue(card, out value))
            {
                sum += value;
            }
            if (card == CardValues.Ace) // Если это Ace, то увеличиваем счетчик тузов
            {
                acesCount++;
            }
        }
        // Добавляем тузы в сумму, считая их как 11, пока общая сумма меньше 21
        while (acesCount > 0 && sum + HighAce <= HandMax)
        {
            sum += HighAce;
            acesCount--;
        }

        // Добавляем оставшиеся тузы в сумму, считая их как 2
        sum += acesCount * LowAce;

        // Если общая сумма превышает 21 и есть тузы, то считаем все тузы как 2
        while (sum > HandMax && acesCount > 0)
        {
            sum -= HighAce - LowAce;
            acesCount--;
        }

        return sum;
    }
}