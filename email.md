## Email quickstart

### Prepare configuration

First step is to initialize `Configuration` object to handle API authentication. The library supports the [API Key Header](https://www.infobip.com/docs/essentials/api-essentials/api-authentication#api-key-header) authentication method.

To see your base URL, log in to the [Infobip API Resource](https://www.infobip.com/docs/api) hub with your Infobip account.

```csharp
    var configuration = new Configuration()
    {
        BasePath = "<put your base URL here prefixed by https://>",
        ApiKey = "<put your API key here>"
    };
```

Now we can initialize Email API client.

```csharp
    var emailApi = new EmailApi(configuration);
```

#### Send email

We're now ready for sending our first email. Note that response contains `BulkId` property which may be useful for checking the status sent emails.
Fields `from`, `to` and `subject` are required, also the message must contain at least one of these: `text`, `html` or `templateId`.

IMPORTANT NOTE:
Keep in mind following restrictions while using trial account

- you can only send messages to verified email addresses
- you can only use your emails address with Infobip test domain in following form `YourUserName@selfserviceib.com`

```csharp
    string mailTo = "john.doe@company.com";
    string mailFrom = "<set your user name>@selfserviceib.com";
    string mailText = "This is my first email.";
    string mailSubject = "Subject of the mail";
    
    var response = emailApi.SendEmail(
        from: mailFrom,
        to: new List<string> { mailTo },
        subject: mailSubject, 
        text: mailText
    );

    string bulkId = response.BulkId;
```

#### Send Email with file attachment

Example below shows how to send email with attachment.

```csharp
    try
    {
        string attachmentFilePath = "/temp/report.csv";
        using FileStream attachmentFile = new FileStream(attachmentFilePath, FileMode.Open, FileAccess.Read);
    
        EmailSendResponse sendResponse = emailApi.SendEmail(
            from: "john.smith@somedomain.com",
            to: new List<string>
            {
                "jane.smith@somecompany.com"
            },
            subject: "Mail subject text",
            text: "Test message with file",
            attachment: new List<FileParameter>
            {
                attachmentFile
            } 
        );
    
        attachmentFile.Dispose();
    }
    catch (Exception ex)
    {
        // HANDLE EXCEPTION  
    }
```

#### Schedule Email for later sending

You can also send delayed emails very easily. All you need to define is the desired date of the email delivery as `sendAt` parameter of the `SendEmail` method.

```csharp
    try
    {
        string attachmentFilePath = "/temp/report.csv";
        DateTimeOffset sendAtDate = new DateTimeOffset(DateTime.UtcNow.AddMinutes(30), TimeSpan.FromHours(0));
        using FileStream attachmentFile = new FileStream(attachmentFilePath, FileMode.Open, FileAccess.Read);
    
        EmailSendResponse sendResponse = emailApi.SendEmail(
            from: "john.smith@somedomain.com",
            to: new List<string>
            {
                "jane.smith@somecompany.com"
            },
            subject: "Mail subject text",
            text: "Test message with file",
            attachment: new List<FileParameter>
            {
                attachmentFile
            }
        );
    
        attachmentFile.Dispose();
    }
    catch (Exception ex)
    {
        // HANDLE EXCEPTION  
    }
```

#### Delivery reports

For each message that you send out, we can send you a delivery report in real-time.
All you need to do is specify your endpoint when sending email in `notifyUrl` field.
Additionally, you can use our [Delivery reports API](https://www.infobip.com/docs/api/channels/email/get-email-delivery-reports) to fetch reports.
You can filter reports by multiple parameters (see the API's documentation for full list), for example, by `bulkId`, `bulkId` and `limit` like in the snippet below:

```csharp
    try
    {
        string messageId = "<set messageId>";
        string bulkId = "<set bulk id>";
        int limit = 10;
        EmailReportsResult emailReportsResult = emailApi.GetEmailDeliveryReports(
            messageId: messageId,
            bulkId: bulkId,
            limit: limit
        );
    }
    catch (Exception ex)
    {
        // HANDLE EXCEPTION  
    }
```
