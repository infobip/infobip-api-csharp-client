## Two-Factor Authentication (2FA) quickstart

### Prepare configuration

Initialize 2FA API client:

```csharp
    var configuration = new Configuration()
    {
        BasePath = "<put your base URL here prefixed by https://>",
        ApiKey = "<put your API key here>"
    };
    
    var tfaApi = new TfaApi(configuration);
```

Before sending one-time PIN codes you need to set up application and message template.

#### Application setup

The application represents your service. It’s good practice to have separate applications for separate services.

```csharp
    var tfaApplicationRequest = new TfaApplicationRequest(
        name: "2FA Application"
    );

    var tfaApplication = tfaApi.CreateTfaApplication(tfaApplicationRequest);

    string applicationId = tfaApplication.ApplicationId;
```

#### Message template setup

Message template is the message body with the PIN placeholder that is sent to end users.

```csharp
    var tfaCreateMessageRequest = new TfaCreateMessageRequest(
        messageText: "Your pin is {{pin}}",
        pinLength: 4,
        pinType: TfaPinType.Numeric
    );

    var tfaMessage = tfaApi.CreateTfaMessageTemplate(applicationId, tfaCreateMessageRequest);

    string messageId = tfaMessage.MessageId;
```

#### Send 2FA code via SMS

After setting up the application and message template, you can start generating and sending PIN codes via SMS to the provided destination address.

```csharp
    var tfaStartAuthenticationRequest = new TfaStartAuthenticationRequest(
        applicationId: applicationId,
        messageId: messageId,
        from: "InfoSMS",
        to: "41793026727"
    );

    var tfaStartAuthenticationResponse = tfaApi.SendTfaPinCodeOverSms(tfaStartAuthenticationRequest, true);

    bool isSuccessful = tfaStartAuthenticationResponse.SmsStatus.Equals("MESSAGE_SENT");
    string pinId = tfaStartAuthenticationResponse.PinId;
```

#### Verify phone number

Verify a phone number to confirm successful 2FA authentication.

```csharp
    var tfaVerifyPinRequest = new TfaVerifyPinRequest("1598");

    var tfaVerifyPinResponse = tfaApi.VerifyTfaPhoneNumber(pinId, tfaVerifyPinRequest);

    bool verified = tfaVerifyPinResponse.Verified;
```
