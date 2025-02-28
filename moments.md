# Moments quickstart

This quick guide aims to help you start with [Infobip Moments API](https://www.infobip.com/docs/api/customer-engagement/moments). After reading it, you should know how to use Moments.

The first step is to prepare `Configuration` object for handling authentication.

```csharp
    var configuration = new Configuration()
    {
        BasePath = "<put your base URL here prefixed by https://>",
        ApiKey = "<put your API key here>"
    };
```

## Flow API

You can now create an instance of `FlowApi` which allows you to manage your flows.

````csharp
    var flowApi = new FlowApi(configuration);
````
### Add participants to flow

To add participants to a flow, you can use the following code:

````csharp
    var campaignId = 200000000000001L;

    var request = new FlowAddFlowParticipantsRequest(
        participants: new List<FlowParticipant>
        {
            new FlowParticipant(
                identifyBy: new FlowPersonUniqueField(
                    identifier: "test@example.com",
                    type: FlowPersonUniqueFieldType.Email
                ),
                variables: new Dictionary<string, object>
                {
                    { "orderNumber", 1167873391 }
                }
            )
        },
        notifyUrl: "https://example.com"
    );

    var response = flowApi.AddFlowParticipants(campaignId, request);
````

### Get a report on participants added to flow

To fetch a report to confirm that all persons have been successfully added to the flow, you can use the following code:

````csharp
    var givenOperationId = "03f2d474-0508-46bf-9f3d-d8e2c28adaea";

    var response = flowApi.GetFlowParticipantsAddedReport(campaignId, givenOperationId);
````

### Remove person from flow

To remove a person from a flow, you can use the following code:

````csharp
    var externalId = "8edb24b5-0319-48cd-a1d9-1e8bc5d577ab";
    
    flowApi.RemovePeopleFromFlow(campaignId, externalId);
````


## Forms API

You can now create an instance of `FormsApi` which allows you to manage your forms.

````csharp
    var formsApi = new FormsApi(configuration);
````

### Get forms

To get all forms, you can use the following code:

````csharp
    var formsResponse = formsApi.GetForms();
````

### Get form by ID

To get a specific form by ID, you can use the following code:

````csharp
    var formId = "cec5dfd2-4238-48e0-933b-9acbdb2e6f5f";

    var formsResponse = formsApi.GetForm(formId);
````

### Increment form view count

To increase the view counter of a specific form, you can use the following code:

````csharp
    var formsResponse = formsApi.IncrementViewCount(formId);
````

### Submit form data

To submit data to a specific form, you can use the following code:

````csharp
    var formDataRequest = new Dictionary<string, object>
    {
        { "first_name", "John" },
        { "last_name", "Doe" },
        { "company", "Infobip" },
        { "email", "info@example.com" }
    };

    var status = formsApi.SubmitFormData(formId, formDataRequest);
````