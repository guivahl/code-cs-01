namespace ex01
{
    public static class Util
    {
        public static int ToInt(this string? str) =>
            int.TryParse(str, out int number) ? number : default;

        public static int[] ToInt(this string[] arrStr) =>
            arrStr.Select(int.Parse).ToArray();
    }
}