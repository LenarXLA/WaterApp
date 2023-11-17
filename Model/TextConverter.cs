using System;

namespace WaterApp.Model
{
    public class TextConverter
    {
        private readonly Func<string, int> _convertion;

        public TextConverter(Func<string, int> convertion)
        {
            _convertion = convertion;
        }

        public int ConvertText(string inputText)
        {
            return _convertion(inputText);
        }
    }
}
