If you have a SendGrid issue, please contact our [support team](https://support.sendgrid.com).

## Table of Contents

* [Viewing the Request Body](#request-body)

<a name="request-body"></a>
## Viewing the Request Body

When debugging or testing, it may be useful to examine the raw request body to compare against the [documented format](https://sendgrid.com/docs/API_Reference/api_v3.html).

e.g. on a Client instance, myClient.

```csharp
foreach (KeyValuePair<DateTime, string> kvp in myClient.RequestHeaders)
{
    Console.WriteLine("Name = {0}, Value = {1}", kvp.Key, kvp.Value);
}
```
