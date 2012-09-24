namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	public static class RussianLanguageExtensions
	{
		/// <summary>
		/// Возвращает форму слова для указанного количества. Например, 41 библиотекА, 42 библиотекИ, 45 библиотеК.
		/// </summary>
		/// <param name="value">Число, к которому относится существительное.</param>
		/// <param name="oneForm">Форма слова для единственного числа.</param>
		/// <param name="twoForm">Форма слова для пары.</param>
        /// <param name="fiveForm">Форма слова для пяти.</param>
		/// <returns>Число и через пробел правильная форма существительного.</returns>
		public static string ToString(this int value, string oneForm, string twoForm, string fiveForm)
		{
            var significantValue = value % 100;

            if (significantValue >= 10 && significantValue <= 20)
                return string.Format("{0} {1}", value, fiveForm);

            var lastDigit = value % 10;
            if (lastDigit == 1)
                return string.Format("{0} {1}", value, oneForm);

            if (lastDigit == 2 || lastDigit == 3 || lastDigit == 4)
                return string.Format("{0} {1}", value, twoForm);

            return string.Format("{0} {1}", value, fiveForm);		    
		}
	}
}