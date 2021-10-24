## Quickstart

#### Initialize the client with configuration

We support multiple authentication methods, e.g. you can use [API Key Header](https://www.infobip.com/docs/essentials/api-authentication#api-key-header). In this case value for `ApiKeyPrefix` in example below will be `App`.

To see your base URL, log in to the [Infobip API Resource](https://www.infobip.com/docs/api) hub with your Infobip credentials.

```csharp
    var configuration = new Configuration()
    {
        BasePath = "<set your base URL here>",
        ApiKeyPrefix = "<set API key prefix here (App/Basic/IBSSO/Bearer)>",
        ApiKey = "<set your API key here>"
    };
    
    SendEmailApi sendEmailApi = new SendEmailApi(configuration);
```

Before sending email messages you need to verify the domain with which you will be sending emails.

#### Send Email with file attachment
Fields `from`, `to` and `subject` are required, also the message must contain at least one of these: `text`, `html` or `templateId`.

IMPORTANT NOTE:

If you are using Infobip free trial account you can only send messages to registered email.
Also make sure that from parameter is set to YourUserName@selfserviceib.com.

```csharp
    try  
    {  
        string attachmentFilePath = "/temp/report.csv";  
        using FileStream attachmentFile = new FileStream(attachmentFilePath, FileMode.Open, FileAccess.Read);  
        
        EmailSendResponse sendResponse = sendEmailApi.SendEmail(  
                     "<set your user name>@selfserviceib.com",  
                     "<set your test mail>@<test mail>.com",  
                     "Mail subject text",  
                     text:"Test message with file 2",  
                     attachment:attachmentFile
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
You can use data models from the library and the pre-configured `com.infobip.JSON` serializer.

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

Exampe of messageId:

```csharp
    messageId = "u3qre3bqdxgom8qhq4ae"
```