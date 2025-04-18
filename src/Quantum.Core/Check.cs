using System;
using System.Collections;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Quantum.Core.Exceptions;

namespace Quantum.Core;

public class Check
{
    public static Check That() => new();

    public void ArgumentNotEmpty(string name, string value, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            message = $"فیلد {name} باید مقدار داشته باشد.";

        if (string.IsNullOrWhiteSpace(value))
            throw new ParameterNullOrEmptyDomainException(name, value, message);
    }

    public void ArgumentNotEmpty(string name, object value, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            message = $"فیلد {name} باید مقدار داشته باشد.";

        if (value == null)
            throw new ParameterNullOrEmptyDomainException(name, value, message );
    }

    public void ArgumentLength(string value, int minimumLength, int maxLength, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            message = $"فیلد {value} باید حداقل {minimumLength} و حداکثر {maxLength} کارکتر طول داشته باشد.";

        if (string.IsNullOrWhiteSpace(value) || value.Length < minimumLength || value.Length > maxLength)
            throw ArgumentLengthException.Occured(message );
    }

    public void ArgumentMatches(string pattern, string value, string message)
    {
        var regex = new Regex(pattern);

        if (!regex.IsMatch(value))
            throw new IllegalArgumentException(message);
    }

    public void IsWellRelativeFormedUriString(string url, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            message = $"فرمت برای آدرس اینترنتی صحیح نمی باشد. مقدار وارد شده : {url}";

        var regex = new Regex(@"^((http|ftp|https|www)://)?([\w+?\.\w+])+([a-zA-Z0-9آ-ی\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$");

        if (!regex.IsMatch(url))
            throw new IllegalUrlFormatException(message );
    }
    public void IsWellAbsoluteFormedUriString(string url, string message)
    {
        if (This.Is.False(Uri.IsWellFormedUriString(url, UriKind.Absolute)))
            throw new IllegalUrlFormatException(message);
    }

    public void IsValidEmailAddress(string email, string message)
    {
        try
        {
            MailAddress m = new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new EmailAddressIsInvalidException(email);
        }

    }

    public void CollectionIsNotEmpty(string propertyName, IEnumerable iterator, string empty)
    {
        if (This.Is.True(iterator == null) || This.Is.False(iterator.GetEnumerator().MoveNext()))
            throw CollectionIsEmptyException.Occured(propertyName);
    }
}