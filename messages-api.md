# Messages API quickstart

This quick guide aims to help you start with [Infobip Messages API](https://www.infobip.com/docs/api/platform/messages-api/sending-message/send-messages-api-message). After reading it, you should know how to use Messages API, send various types of messages, receive incoming messages, and receive delivery reports.

Messages API supports 11 different channels: SMS, MMS, RCS, WhatsApp, Viber Business Messages, Viber Bots, Apple Messages for Business, Google Business Messages, Instagram Direct Messages, Messenger, and LINE Official Notification.

The first step is to prepare a `Configuration` object for handling authentication.

```csharp
    var configuration = new Configuration()
    {
        BasePath = "<put your base URL here prefixed by https://>",
        ApiKey = "<put your API key here>"
    };
```

With that ready, you can now create an instance of `MessagesApi` which allows you to send messages using Messages API.

```csharp
    var messagesApi = new MessagesApi(configuration);
```

## Activate your test senders

Before sending a message using Messages API, you need to activate your sender(s) and connect to our test domain.

Here you can find the example on how to activate and use **WhatsApp and SMS channels**.

To activate the WhatsApp test sender, add the **447860099299** Infobip sender to your WhatsApp contacts and send a message containing your Infobip account username.

To use the SMS test sender, simply send a message by using **InfoSMS** sender.

You are now ready to send your first message.

**IMPORTANT NOTE:** Keep in mind that for test purposes you can only send messages to a number you registered when you created your Infobip account.

## Send your first message

The easiest way to start with Messages API is to send a text message. First, prepare the message you want to send:

```csharp
    var message = new MessagesApiMessage(
        channel: MessagesApiOutboundMessageChannel.Sms,
        sender: "48123234567",
        destinations: new List<MessagesApiMessageDestination>
        {
            new MessagesApiMessageDestination(new MessagesApiToDestination(to: "447491163443"))
        },
        content: new MessagesApiMessageContent(
            body: new MessagesApiMessageTextBody(text: "Sent using Infobip's C# client library!")
        )
    );

    var request = new MessagesApiRequest(
        messages: new List<MessagesApiBaseMessage>
        {
            new MessagesApiBaseMessage(message)
        }
    );
```

Send the message by invoking the appropriate send method and store the result.

```csharp
    MessageResponse messageInfo = null;
    try
    {
        messageInfo = messagesApi.SendMessagesApiMessage(request);
    }
    catch (ApiException apiException)
    {
        // HANDLE THE EXCEPTION
    }
```

Once the invocation finishes, you can inspect the result and print a status description.

```csharp
    Console.WriteLine(messageInfo.Messages[0].Status.Description);
```

## How to receive messages

To receive messages using Messages API you must set up a webhook.

That is an endpoint implemented on your side where you will accept requests when a new message arrives. It will be called by the Infobip API whenever we receive an incoming message for your registered sender(s).

```csharp
    [HttpPost("incoming-messages")]
    public IActionResult ReceiveMessages([FromBody] JsonElement body)
    {
        var messages = JsonConvert.DeserializeObject<MessagesApiIncomingMessage>(body.GetRawText());
        foreach (var messageData in messages.Results)
        {
            switch (messageData.Event)
            {
                case MessagesApiInboundEventType.Mo:
                    var webhookEvent = (MessagesApiWebhookEvent)messageData;
                    // INSERT YOUR PROCESSING LOGIC HERE
                    break;
                case MessagesApiInboundEventType.TypingStarted:
                    var typingStarted = (MessagesApiInboundTypingStartedEvent)messageData;
                    // INSERT YOUR PROCESSING LOGIC HERE
                    break;
                case MessagesApiInboundEventType.TypingStopped:
                    var typingStopped = (MessagesApiInboundTypingStoppedEvent)messageData;
                    // INSERT YOUR PROCESSING LOGIC HERE
                    break;
                default:
                    throw new ArgumentException("Unexpected event type!");
            }
        }
        return Ok();
    }
```

You can find more details about the structure of the message you can expect on your endpoint on the [docs page](https://www.infobip.com/docs/api/platform/messages-api/incoming-message/receive-messages-api-incoming-messages).

## How to receive delivery reports

For each message that you send out, you can get a message delivery report in real time. Subscribe for reports by contacting our support team at <support@infobip.com>. e.g. `https://{yourDomain}/delivery-reports`

```csharp
    [HttpPost("delivery-reports")]
    public IActionResult ReceiveDeliveryReports([FromBody] JsonElement body)
    {
        var reports = JsonConvert.DeserializeObject<MessagesApiDeliveryReportResponse>(body.GetRawText());
        foreach (var result in reports.Results)
        {
            Console.WriteLine(result.MessageId + " - " + result.Status.Name);
        }
        return Ok();
    }
```

## Use adaptationMode to automatically modify message types

Enhance your Messages API requests by using the `adaptationMode` parameter. It allows you to send messages even if they are unsupported by the channel.

When you set `adaptationMode` to `true`, Messages API automatically adjusts the message to remove any unsupported elements, ensuring successful delivery.

For instance, if you'd like to include an image in your WhatsApp and SMS messages, set `adaptationMode` to `true`. Messages API will handle the delivery for WhatsApp as a message containing an image, while for SMS it will provide a link to the image.

On the other hand, if you set `adaptationMode` to `false` and try to send a message with an unsupported element to a channel, an error will occur. Make sure to choose the right setting based on your specific channel and content requirements.

```csharp
    var options = new MessagesApiMessageOptions(adaptationMode: true);

    var message = new MessagesApiMessage(
        channel: MessagesApiOutboundMessageChannel.Sms,
        sender: "48123234567",
        destinations: new List<MessagesApiMessageDestination>
        {
            new MessagesApiMessageDestination(new MessagesApiToDestination(to: "447491163443"))
        },
        content: new MessagesApiMessageContent(
            body: new MessagesApiMessageImageBody(url: "https://example.com/image.png")
        ),
        options: options
    );
```
