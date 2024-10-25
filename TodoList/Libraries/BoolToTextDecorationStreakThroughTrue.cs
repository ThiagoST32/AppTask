using System.Globalization;

namespace TodoList.Libraries
{
    public class BoolToTextDecorationStreakThroughTrue : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            bool isCompleted = (bool)value;
            Console.WriteLine("CONVERSOR -> "+isCompleted);

            return isCompleted ? TextDecorations.Strikethrough : TextDecorations.None;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
