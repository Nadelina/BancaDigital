namespace Banca.Application.Utils
{
    public static class StringExtensions
    {
        public static string ToCardFormat(this string cardNumber)
        {
            return string.IsNullOrEmpty(cardNumber)
                ? string.Empty
                : string.Join(" ", Enumerable.Range(0, cardNumber.Length / 4)
                                             .Select(i => cardNumber.Substring(i * 4, 4)));
        }
    }

}
