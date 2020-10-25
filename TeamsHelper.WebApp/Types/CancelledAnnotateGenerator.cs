using System;

namespace TeamsHelper.WebApp
{
    public class CancelledAnnotateGenerator : ICancelledAnnotateGenerator
    {
        public IDateTimeConverter Converter;

        public CancelledAnnotateGenerator(IDateTimeConverter converter)
        {
            Converter = converter;
        }

        public string Generate(DateTime dateTime)
        {
            return $"Anulowano: {Converter.Convert(dateTime, StringDateTime.Simple)}";
        }
    }
}