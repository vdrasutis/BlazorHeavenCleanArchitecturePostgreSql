using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;

namespace BlazorHero.CleanArchitecture.Infrastructure.Contexts
{
    public abstract partial class AuditableContext
    {
        public class DateTimeToIso8601StringConverter : ValueConverter<DateTime, string>
        {
            // https://stackoverflow.com/questions/50727860/ef-core-2-1-hasconversion-on-all-properties-of-type-datetime
            public DateTimeToIso8601StringConverter() : base(Serialize, Deserialize, null)
            {
            }

            static Expression<Func<string, DateTime>> Deserialize = x => DateTime.Parse(x).ToUniversalTime();
            static Expression<Func<DateTime, string>> Serialize = x => x.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}