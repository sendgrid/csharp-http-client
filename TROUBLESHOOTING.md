If you have a non-library Twilio SendGrid issue, please contact our [support team](https://support.sendgrid.com).

If you can't find a solution below, please open an [issue](https://github.com/sendgrid/csharp-http-client/issues).

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
