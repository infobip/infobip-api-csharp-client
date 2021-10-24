## Quickstart

### Prepare configuration

First step is to initialize `Configuration` object to handle API authentication. In this case value for `ApiKeyPrefix` in example below will be `App`.
```csharp
    var configuration = new Configuration()
    {
        BasePath = "<put your base URL here>",
        ApiKeyPrefix = "<put API key prefix here (App/Basic/IBSSO/Bearer)>",
        ApiKey = "<put your API key here>"
    };
```

Now we can initialize Email API client.
```csharp
    var sendEmailApi = new SendEmailApi(configuration);
```

#### Send email
We're now ready for sending our first email. Note that response contains `BulkId` property which may be useful for checking the status sent emails. 
Fields `from`, `to` and `subject` are required, also the message must contain at least one of these: `text`, `html` or `templateId`.

IMPORTANT NOTE:
Keep in mind folowing restrictions while using trial account 
- you can only send messages to verified email addresses
- you can only use your emails addres with Infobip test domain in following form `YourUserName@selfserviceib.com`

```csharp
    string mailTo = "john.doe@company.com";
    string mailFrom = "<set your user name>@selfserviceib.com";
    string mailText = "This is my first email.";

    var response = sendEmailApi.SendEmail(from: mailFrom, to: mailTo, subject: subject, cc: null, bcc: null, text: mailText);

    string bulkId = response.BulkId;
```

#### Send Email with file attachment

Example below shows how to send email with attachment.

```csharp
    try  
    {  
        string attachmentFilePath = "/temp/report.csv";  
        using FileStream attachmentFile = new FileStream(attachmentFilePath, FileMode.Open, FileAccess.Read);  
        
        EmailSendResponse sendResponse = sendEmailApi.SendEmail(  
                     "<set your user name>@selfserviceib.com",  
                     "<set your test mail>@<verified email>.com",  
                     "Mail subject text",  
                     text:"Test message with file",  
                     attachment:attachmentFile);     
                     
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
        DateTimeOffset sendAtDate = new DateTimeOffset(DateTime.UtcNow.AddMinutes(30), TimeSpan.FromHours(0));
        using FileStream attachmentFile = new FileStream(attachmentFilePath, FileMode.Open, FileAccess.Read);  
        
        EmailSendResponse sendResponse = sendEmailApi.SendEmail(  
                     "<set your user name>@selfserviceib.com",  
                     "<set your test mail>@<verified email>.com",  
                     "Mail subject text",  
                     text:"Test message with file", 
                     sendAt: sendAtDate);     
                     
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
Additionally you can use `messageId` or `bulkId` to fetch reports.

```csharp
    try  
    {  
        string messageId = "<set message>";
        string bulkId = "<set bulk id>" 
        int limit = 10;
        ApiReportsResponse apiReportsResponse = sendEmailApi.GetEmailDeliveryReports(messageId, bulkId, limit);  
    }  
    catch (Exception ex)  
    {  
         // HANDLE EXCEPTION  
    }
```
