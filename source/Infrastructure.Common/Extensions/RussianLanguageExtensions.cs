namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	public static class RussianLanguageExtensions
	{
		/// <summary>
		/// Возвращает форму слова, которая идет после числа. Например, 41 библиотекА, 42 библиотекИ, 11 библиотеК
		/// </summary>
		/// <param name="value">Число, к которому относится существительное</param>
		/// <param name="oneForm">Единственное число. Например, 41 или 101</param>
		/// <param name="twoForm">Число оканчивается на 2, 3 или 4</param>
		/// <param name="threeForm">Остальные случаи</param>
		/// <returns>Число + правильная форма существительного</returns>
		public static string ToString(this int value, string oneForm, string twoForm, string threeForm)
		{
			if (value >= 11 && value <= 14)
				return string.Format("{0} {1}", value, threeForm);

			int lastDigit = value%10;
			if (lastDigit == 1)
				return string.Format("{0} {1}", value, oneForm);

			if (lastDigit == 2 || lastDigit == 3 || lastDigit == 4)
				return string.Format("{0} {1}", value, twoForm);

			return string.Format("{0} {1}", value, threeForm);
		}
	}
}