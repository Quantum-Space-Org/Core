namespace Quantum.Core;

public static class ArabicCharactersNormalizer
{
    public static void NormalizeArabicCharacters(this object instance)
    {
        foreach (var propertyInfo in instance.GetType().GetProperties())
        {
            if (propertyInfo.PropertyType == typeof(string) && propertyInfo.CanWrite)
            {
                var originalValue = propertyInfo.GetValue(instance, null)?.ToString();
                if (!string.IsNullOrEmpty(originalValue))
                {
                    originalValue = originalValue
                        .Replace('ي', 'ی')
                        .Replace('ك', 'ک')
                        .Replace('أ', 'ا')
                        .Replace('ة', 'ه')
                        .Trim();
                    propertyInfo.SetValue(instance, originalValue);
                }
            }
        }
    }
}