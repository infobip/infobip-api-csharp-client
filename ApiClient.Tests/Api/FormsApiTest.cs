using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiClient.Tests.Api;

[TestClass]
public class FormsApiTest : ApiTest
{
    protected const string FORMS_ENDPOINT = "/forms/1/forms";
    protected const string FORM_ENDPOINT = "/forms/1/forms/{id}";
    protected const string FORM_VIEW_ENDPOINT = "/forms/1/forms/{id}/views";
    protected const string FORM_DATA_ENDPOINT = "/forms/1/forms/{id}/data";

    protected const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ss.fffzzz";

    [TestMethod]
    public void ShouldGetForms()
    {
        var expectedId = "f23f0f7c-9898-4feb-8f21-5afe2c29db7e";
        var expectedName = "Test form";
        var expectedComponent = FormsComponentType.Text;
        var expectedFieldId = "first_name";
        var expectedPersonField = "firstName";
        var expectedLabel = "First Name";
        var expectedIsRequired = false;
        var expectedIsHidden = false;
        var expectedMaxLength = 255;
        var expectedSample = "James";
        var expectedPlaceholder = "First Name";
        var expectedSecondComponent = FormsComponentType.Text;
        var expectedSecondFieldId = "country";
        var expectedSecondPersonField = "country";
        var expectedSecondLabel = "Country";
        var expectedSecondIsRequired = false;
        var expectedSecondIsHidden = false;
        var expectedSecondMaxLength = 1000;
        var expectedSecondSample = "Lorem ipsum";
        var expectedSecondPlaceholder = "Country";
        var expectedThirdComponent = FormsComponentType.SubmitButton;
        var expectedThirdLabel = "Submit";
        var expectedCreatedAt = new DateTimeOffset(2022, 6, 15, 13, 21, 38, 195, TimeSpan.FromHours(0));
        var expectedUpdatedAt = new DateTimeOffset(2022, 6, 15, 13, 21, 46, 286, TimeSpan.FromHours(0));
        var expectedResubmitEnabled = true;
        var expectedFormType = FormsType.OptIn;
        var expectedFormStatus = FormsStatus.Active;
        var expectedOffset = 0;
        var expectedLimit = 25;
        var expectedTotal = 2;

        var expectedResponse = $@"
            {{
              ""forms"": [
                {{
                  ""id"": ""{expectedId}"",
                  ""name"": ""{expectedName}"",
                  ""elements"": [
                    {{
                      ""component"": ""{expectedComponent}"",
                      ""fieldId"": ""{expectedFieldId}"",
                      ""personField"": ""{expectedPersonField}"",
                      ""label"": ""{expectedLabel}"",
                      ""isRequired"": {expectedIsRequired.ToString().ToLower()},
                      ""isHidden"": {expectedIsHidden.ToString().ToLower()},
                      ""validationRules"": {{
                        ""maxLength"": {expectedMaxLength},
                        ""sample"": ""{expectedSample}"",
                        ""forbiddenSymbols"": [
                          ""^"",
                          ""&"",
                          ""<"",
                          "">"",
                          ""\"""",
                          ""/"",
                          ""\\""
                        ]
                      }},
                      ""placeholder"": ""{expectedPlaceholder}""
                    }},
                    {{
                      ""component"": ""{expectedSecondComponent}"",
                      ""fieldId"": ""{expectedSecondFieldId}"",
                      ""personField"": ""{expectedSecondPersonField}"",
                      ""label"": ""{expectedSecondLabel}"",
                      ""isRequired"": {expectedSecondIsRequired.ToString().ToLower()},
                      ""isHidden"": {expectedSecondIsHidden.ToString().ToLower()},
                      ""validationRules"": {{
                        ""maxLength"": {expectedSecondMaxLength},
                        ""sample"": ""{expectedSecondSample}""
                      }},
                      ""placeholder"": ""{expectedSecondPlaceholder}""
                    }},
                    {{
                      ""component"": ""{expectedThirdComponent}"",
                      ""label"": ""{expectedThirdLabel}""
                    }}
                  ],
                  ""createdAt"": ""{expectedCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""updatedAt"": ""{expectedUpdatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""resubmitEnabled"": {expectedResubmitEnabled.ToString().ToLower()},
                  ""formType"": ""{expectedFormType}"",
                  ""formStatus"": ""{expectedFormStatus}""
                }}
              ],
              ""offset"": {expectedOffset},
              ""limit"": {expectedLimit},
              ""total"": {expectedTotal}
            }}";

        var givenOffset = 0;
        var givenLimit = 25;
        var givenFormType = FormsType.Apple;
        var givenFormStatus = FormsStatus.Active;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "offset", givenOffset.ToString() },
            { "limit", givenLimit.ToString() },
            { "formType", givenFormType.ToString() },
            { "formStatus", givenFormStatus.ToString() }
        };

        SetUpGetRequest(FORMS_ENDPOINT, 200, expectedResponse, givenQueryParameters);

        var formsApi = new FormsApi(configuration);

        void AssertFormsResponse(FormsResponse formsResponse)
        {
            Assert.IsNotNull(formsResponse);
            Assert.IsNotNull(formsResponse.Forms);
            Assert.AreEqual(1, formsResponse.Forms.Count);

            var formsResponseContent = formsResponse.Forms[0];

            Assert.AreEqual(expectedId, formsResponseContent.Id);
            Assert.AreEqual(expectedName, formsResponseContent.Name);

            Assert.IsNotNull(formsResponseContent.Elements);
            Assert.AreEqual(3, formsResponseContent.Elements.Count);

            var firstElement = formsResponseContent.Elements[0];
            Assert.AreEqual(expectedComponent, firstElement.Component);
            Assert.AreEqual(expectedFieldId, firstElement.FieldId);
            Assert.AreEqual(expectedPersonField, firstElement.PersonField);
            Assert.AreEqual(expectedLabel, firstElement.Label);
            Assert.AreEqual(expectedIsRequired, firstElement.IsRequired);
            Assert.AreEqual(expectedIsHidden, firstElement.IsHidden);
            Assert.AreEqual(expectedPlaceholder, firstElement.Placeholder);

            var firstValidationRules = firstElement.ValidationRules;
            Assert.IsNotNull(firstValidationRules);
            Assert.AreEqual(expectedMaxLength, firstValidationRules.MaxLength);
            Assert.AreEqual(expectedSample, firstValidationRules.Sample);

            var forbiddenSymbols = firstValidationRules.ForbiddenSymbols;
            Assert.IsNotNull(forbiddenSymbols);
            Assert.AreEqual(7, forbiddenSymbols.Count);
            Assert.AreEqual("^", forbiddenSymbols[0]);
            Assert.AreEqual("&", forbiddenSymbols[1]);
            Assert.AreEqual("<", forbiddenSymbols[2]);
            Assert.AreEqual(">", forbiddenSymbols[3]);
            Assert.AreEqual("\"", forbiddenSymbols[4]);
            Assert.AreEqual("/", forbiddenSymbols[5]);
            Assert.AreEqual("\\", forbiddenSymbols[6]);

            var secondElement = formsResponseContent.Elements[1];
            Assert.AreEqual(expectedSecondComponent, secondElement.Component);
            Assert.AreEqual(expectedSecondFieldId, secondElement.FieldId);
            Assert.AreEqual(expectedSecondPersonField, secondElement.PersonField);
            Assert.AreEqual(expectedSecondLabel, secondElement.Label);
            Assert.AreEqual(expectedSecondIsRequired, secondElement.IsRequired);
            Assert.AreEqual(expectedSecondIsHidden, secondElement.IsHidden);
            Assert.AreEqual(expectedSecondPlaceholder, secondElement.Placeholder);

            var secondValidationRules = secondElement.ValidationRules;
            Assert.IsNotNull(secondValidationRules);
            Assert.AreEqual(expectedSecondMaxLength, secondValidationRules.MaxLength);
            Assert.AreEqual(expectedSecondSample, secondValidationRules.Sample);

            var thirdElement = formsResponseContent.Elements[2];
            Assert.IsNotNull(thirdElement);
            Assert.AreEqual(expectedThirdComponent, thirdElement.Component);
            Assert.AreEqual(expectedThirdLabel, thirdElement.Label);

            Assert.AreEqual(expectedCreatedAt, formsResponseContent.CreatedAt);
            Assert.AreEqual(expectedUpdatedAt, formsResponseContent.UpdatedAt);
            Assert.AreEqual(expectedResubmitEnabled, formsResponseContent.ResubmitEnabled);
            Assert.AreEqual(expectedFormType, formsResponseContent.FormType);
            Assert.AreEqual(expectedFormStatus, formsResponseContent.FormStatus);

            Assert.AreEqual(expectedOffset, formsResponse.Offset);
            Assert.AreEqual(expectedLimit, formsResponse.Limit);
            Assert.AreEqual(expectedTotal, formsResponse.Total);
        }

        AssertResponse(formsApi.GetForms(givenOffset, givenLimit, givenFormType, givenFormStatus), AssertFormsResponse);
        AssertResponse(formsApi.GetFormsAsync(givenOffset, givenLimit, givenFormType, givenFormStatus).Result,
            AssertFormsResponse);
        AssertResponseWithHttpInfo(
            formsApi.GetFormsWithHttpInfo(givenOffset, givenLimit, givenFormType, givenFormStatus), AssertFormsResponse,
            200);
        AssertResponseWithHttpInfo(
            formsApi.GetFormsWithHttpInfoAsync(givenOffset, givenLimit, givenFormType, givenFormStatus).Result,
            AssertFormsResponse, 200);
    }

    [TestMethod]
    public void ShouldGetForm()
    {
        var expectedId = "f23f0f7c-9898-4feb-8f21-5afe2c29db7e";
        var expectedName = "Test form";
        var expectedComponent = FormsComponentType.Text;
        var expectedFieldId = "first_name";
        var expectedPersonField = "firstName";
        var expectedLabel = "First Name";
        var expectedIsRequired = false;
        var expectedIsHidden = false;
        var expectedMaxLength = 255;
        var expectedSample = "James";
        var expectedPlaceholder = "First Name";
        var expectedSecondComponent = FormsComponentType.Text;
        var expectedSecondFieldId = "country";
        var expectedSecondPersonField = "country";
        var expectedSecondLabel = "Country";
        var expectedSecondIsRequired = false;
        var expectedSecondIsHidden = false;
        var expectedSecondMaxLength = 1000;
        var expectedSecondSample = "Lorem ipsum";
        var expectedSecondPlaceholder = "Country";
        var expectedThirdComponent = FormsComponentType.SubmitButton;
        var expectedThirdLabel = "Submit";
        var expectedCreatedAt = new DateTimeOffset(2022, 6, 15, 13, 21, 38, 195, TimeSpan.FromHours(0));
        var expectedUpdatedAt = new DateTimeOffset(2022, 6, 15, 13, 21, 46, 286, TimeSpan.FromHours(0));
        var expectedResubmitEnabled = true;
        var expectedFormType = FormsType.OptIn;
        var expectedFormStatus = FormsStatus.Active;

        var expectedResponse = $@"
            {{
              ""id"": ""{expectedId}"",
              ""name"": ""{expectedName}"",
              ""elements"": [
                {{
                  ""component"": ""{expectedComponent}"",
                  ""fieldId"": ""{expectedFieldId}"",
                  ""personField"": ""{expectedPersonField}"",
                  ""label"": ""{expectedLabel}"",
                  ""isRequired"": {expectedIsRequired.ToString().ToLower()},
                  ""isHidden"": {expectedIsHidden.ToString().ToLower()},
                  ""validationRules"": {{
                    ""maxLength"": {expectedMaxLength},
                    ""sample"": ""{expectedSample}"",
                    ""forbiddenSymbols"": [
                      ""^"",
                      ""&"",
                      ""<"",
                      "">"",
                      ""\"""",
                      ""/"",
                      ""\\""
                    ]
                  }},
                  ""placeholder"": ""{expectedPlaceholder}""
                }},
                {{
                  ""component"": ""{expectedSecondComponent}"",
                  ""fieldId"": ""{expectedSecondFieldId}"",
                  ""personField"": ""{expectedSecondPersonField}"",
                  ""label"": ""{expectedSecondLabel}"",
                  ""isRequired"": {expectedSecondIsRequired.ToString().ToLower()},
                  ""isHidden"": {expectedSecondIsHidden.ToString().ToLower()},
                  ""validationRules"": {{
                    ""maxLength"": {expectedSecondMaxLength},
                    ""sample"": ""{expectedSecondSample}""
                  }},
                  ""placeholder"": ""{expectedSecondPlaceholder}""
                }},
                {{
                  ""component"": ""{expectedThirdComponent}"",
                  ""label"": ""{expectedThirdLabel}""
                }}
              ],
              ""createdAt"": ""{expectedCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
              ""updatedAt"": ""{expectedUpdatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
              ""resubmitEnabled"": {expectedResubmitEnabled.ToString().ToLower()},
              ""formType"": ""{expectedFormType}"",
              ""formStatus"": ""{expectedFormStatus}""
            }}";

        SetUpGetRequest(FORM_ENDPOINT.Replace("{id}", expectedId), 200, expectedResponse);

        var formsApi = new FormsApi(configuration);

        void AssertFormsResponseContent(FormsResponseContent formsResponseContent)
        {
            Assert.IsNotNull(formsResponseContent);
            Assert.AreEqual(expectedId, formsResponseContent.Id);
            Assert.AreEqual(expectedName, formsResponseContent.Name);

            Assert.IsNotNull(formsResponseContent.Elements);
            Assert.AreEqual(3, formsResponseContent.Elements.Count);

            var firstElement = formsResponseContent.Elements[0];
            Assert.AreEqual(expectedComponent, firstElement.Component);
            Assert.AreEqual(expectedFieldId, firstElement.FieldId);
            Assert.AreEqual(expectedPersonField, firstElement.PersonField);
            Assert.AreEqual(expectedLabel, firstElement.Label);
            Assert.AreEqual(expectedIsRequired, firstElement.IsRequired);
            Assert.AreEqual(expectedIsHidden, firstElement.IsHidden);
            Assert.AreEqual(expectedPlaceholder, firstElement.Placeholder);

            var firstValidationRules = firstElement.ValidationRules;
            Assert.IsNotNull(firstValidationRules);
            Assert.AreEqual(expectedMaxLength, firstValidationRules.MaxLength);
            Assert.AreEqual(expectedSample, firstValidationRules.Sample);

            var forbiddenSymbols = firstValidationRules.ForbiddenSymbols;
            Assert.IsNotNull(forbiddenSymbols);
            Assert.AreEqual(7, forbiddenSymbols.Count);
            Assert.AreEqual("^", forbiddenSymbols[0]);
            Assert.AreEqual("&", forbiddenSymbols[1]);
            Assert.AreEqual("<", forbiddenSymbols[2]);
            Assert.AreEqual(">", forbiddenSymbols[3]);
            Assert.AreEqual("\"", forbiddenSymbols[4]);
            Assert.AreEqual("/", forbiddenSymbols[5]);
            Assert.AreEqual("\\", forbiddenSymbols[6]);

            var secondElement = formsResponseContent.Elements[1];
            Assert.AreEqual(expectedSecondComponent, secondElement.Component);
            Assert.AreEqual(expectedSecondFieldId, secondElement.FieldId);
            Assert.AreEqual(expectedSecondPersonField, secondElement.PersonField);
            Assert.AreEqual(expectedSecondLabel, secondElement.Label);
            Assert.AreEqual(expectedSecondIsRequired, secondElement.IsRequired);
            Assert.AreEqual(expectedSecondIsHidden, secondElement.IsHidden);
            Assert.AreEqual(expectedSecondPlaceholder, secondElement.Placeholder);

            var secondValidationRules = secondElement.ValidationRules;
            Assert.IsNotNull(secondValidationRules);
            Assert.AreEqual(expectedSecondMaxLength, secondValidationRules.MaxLength);
            Assert.AreEqual(expectedSecondSample, secondValidationRules.Sample);

            var thirdElement = formsResponseContent.Elements[2];
            Assert.IsNotNull(thirdElement);
            Assert.AreEqual(expectedThirdComponent, thirdElement.Component);
            Assert.AreEqual(expectedThirdLabel, thirdElement.Label);

            Assert.AreEqual(expectedCreatedAt, formsResponseContent.CreatedAt);
            Assert.AreEqual(expectedUpdatedAt, formsResponseContent.UpdatedAt);
            Assert.AreEqual(expectedResubmitEnabled, formsResponseContent.ResubmitEnabled);
            Assert.AreEqual(expectedFormType, formsResponseContent.FormType);
            Assert.AreEqual(expectedFormStatus, formsResponseContent.FormStatus);
        }

        AssertResponse(formsApi.GetForm(expectedId), AssertFormsResponseContent);
        AssertResponse(formsApi.GetFormAsync(expectedId).Result, AssertFormsResponseContent);
        AssertResponseWithHttpInfo(formsApi.GetFormWithHttpInfo(expectedId), AssertFormsResponseContent, 200);
        AssertResponseWithHttpInfo(formsApi.GetFormWithHttpInfoAsync(expectedId).Result, AssertFormsResponseContent,
            200);
    }

    [TestMethod]
    public void ShouldIncrementFormViewCount()
    {
        var expectedStatus = "OK";

        var expectedResponse = $@"
            {{
              ""status"": ""{expectedStatus}""
            }}";

        var givenId = "cec5dfd2-4238-48e0-933b-9acbdb2e6f5f";

        SetUpPostRequest(FORM_VIEW_ENDPOINT.Replace("{id}", givenId), 200, expectedResponse: expectedResponse);

        var formsApi = new FormsApi(configuration);

        void AssertFormsStatusResponse(FormsStatusResponse formsStatusResponse)
        {
            Assert.IsNotNull(formsStatusResponse);
            Assert.AreEqual(expectedStatus, formsStatusResponse.Status);
        }

        AssertResponse(formsApi.IncrementViewCount(givenId), AssertFormsStatusResponse);
        AssertResponse(formsApi.IncrementViewCountAsync(givenId).Result, AssertFormsStatusResponse);
        AssertResponseWithHttpInfo(formsApi.IncrementViewCountWithHttpInfo(givenId), AssertFormsStatusResponse, 200);
        AssertResponseWithHttpInfo(formsApi.IncrementViewCountWithHttpInfoAsync(givenId).Result,
            AssertFormsStatusResponse, 200);
    }

    [TestMethod]
    public void ShouldSubmitFormData()
    {
        var expectedStatus = "OK";

        var expectedResponse = $@"
            {{
              ""status"": ""{expectedStatus}""
            }}";

        var givenString = "string";
        var givenNumber = 26;
        var givenFloat = 1.5f;
        var givenBoolean = true;
        var givenRequest = $@"
            {{
              ""string"": ""{givenString}"",
              ""number"": {givenNumber},
              ""float"": {givenFloat},
              ""boolean"": {givenBoolean.ToString().ToLower()}
            }}";

        var givenFormData = new Dictionary<string, object>
        {
            { "string", givenString },
            { "number", givenNumber },
            { "float", givenFloat },
            { "boolean", givenBoolean }
        };

        var givenId = "cec5dfd2-4238-48e0-933b-9acbdb2e6f5f";

        SetUpPostRequest(FORM_DATA_ENDPOINT.Replace("{id}", givenId), 200, givenRequest, expectedResponse);

        var formsApi = new FormsApi(configuration);

        void AssertFormsStatusResponse(FormsStatusResponse formsStatusResponse)
        {
            Assert.IsNotNull(formsStatusResponse);
            Assert.AreEqual(expectedStatus, formsStatusResponse.Status);
        }

        AssertResponse(formsApi.SubmitFormData(givenId, givenFormData), AssertFormsStatusResponse);
        AssertResponse(formsApi.SubmitFormDataAsync(givenId, givenFormData).Result, AssertFormsStatusResponse);
        AssertResponseWithHttpInfo(formsApi.SubmitFormDataWithHttpInfo(givenId, givenFormData),
            AssertFormsStatusResponse, 200);
        AssertResponseWithHttpInfo(formsApi.SubmitFormDataWithHttpInfoAsync(givenId, givenFormData).Result,
            AssertFormsStatusResponse, 200);
    }
}