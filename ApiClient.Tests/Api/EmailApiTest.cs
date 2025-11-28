using System.Globalization;
using System.Text;
using Infobip.Api.Client;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Client;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Infobip.Api.Client.Model.EmailAddDomainRequest;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient.Tests.Api;

[TestClass]
public class EmailApiTest : ApiTest
{
    protected const string EMAIL_SEND_FULLY_FEATURED_ENDPOINT = "/email/3/send";
    protected const string EMAIL_VALIDATE_ADDRESSES_ENDPOINT = "/email/2/validation";
    protected const string EMAIL_LOGS_ENDPOINT = "/email/1/reports";
    protected const string EMAIL_REPORTS_ENDPOINT = "/email/1/logs";
    protected const string EMAIL_BULKS_ENDPOINT = "/email/1/bulks";
    protected const string EMAIL_BULKS_STATUS_ENDPOINT = "/email/1/bulks/status";

    protected const string EMAIL_DOMAINS = "/email/1/domains";
    protected const string EMAIL_DOMAIN = "/email/1/domains/{domainName}";
    protected const string EMAIL_DOMAIN_TRACKING = "/email/1/domains/{domainName}/tracking";
    protected const string EMAIL_DOMAIN_RETURN_PATH = "/email/1/domains/{domainName}/return-path";
    protected const string EMAIL_DOMAIN_VERIFY = "/email/1/domains/{domainName}/verify";

    protected const string EMAIL_SUPPRESIONS_ENDPOINT = "/email/1/suppressions";
    protected const string EMAIL_SUPPRESIONS_DOMAINS_ENDPOINT = "/email/1/suppressions/domains";

    protected const string EMAIL_IPS_ENDPOINT = "/email/1/ip-management/ips";
    protected const string EMAIL_IP_ENDPOINT = "/email/1/ip-management/ips/{ipId}";
    protected const string EMAIL_IP_POOLS_ENDPOINT = "/email/1/ip-management/pools";
    protected const string EMAIL_IP_POOL_ENDPOINT = "/email/1/ip-management/pools/{poolId}";

    protected const string EMAIL_IP_POOLS_IPS_ENDPOINT = "/email/1/ip-management/pools/{poolId}/ips";
    protected const string EMAIL_IP_POOLS_IP_ENDPOINT = "/email/1/ip-management/pools/{poolId}/ips/{ipId}";

    protected const string EMAIL_IP_DOMAIN_ENDPOINT = "/email/1/ip-management/domains/{domainId}";
    protected const string EMAIL_IP_DOMAIN_POOLS_ENDPOINT = "/email/1/ip-management/domains/{domainId}/pools";
    protected const string EMAIL_IP_DOMAIN_POOL_ENDPOINT = "/email/1/ip-management/domains/{domainId}/pools/{poolId}";

    protected const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ss.fffzzz";

    internal static readonly Tuple<int, string, string, string>[] ErrorResponses =
    {
        Tuple.Create(400, "BAD_REQUEST", "Bad Request", "[subject : may not be null]"),
        Tuple.Create(500, "GENERAL_ERROR", "Internal Server Error", "Something went wrong. Please contact support.")
    };

    internal static readonly Tuple<int, string, string, string>[] DeliveryReportErrorResponses =
    {
        Tuple.Create(400, "BAD_REQUEST", "Bad Request", "request.message.content.media.file.url: [is not a valid url]"),
        Tuple.Create(500, "BAD_REQUEST", "Internal Server Error",
            "request.message.content.media.file.url: [is not a valid url]")
    };

    [TestMethod]
    public void ShouldSendEmailTest()
    {
        var expectedFrom = "Jane Doe <jane.doe@example.com";
        var expectedTo = "john.smith@example.com";
        var expectedTo2 = "Jane Doe <jane.doe@example.com";
        var expectedCc = "alice.someone@example.com";
        var expectedCc2 = "bob.someone@example.com";
        var expectedBcc = "carol.someone@example.com";
        var expectedBcc2 = "charlie.someone@example.com";
        var expectedReplyTo = "all.replies@example.com";
        var expectedSubject = "Mail subject text";
        var expectedStatusDescription = "Message sent to next instance";
        var expectedMessageCount = 2;
        var expectedStatusId = 1;
        var expectedStatusGroupId = 1;
        var expectedMessageId = "MSG-1234";
        var expectedMessageId2 = "e7zzb1v9yirml2se9zo4";
        var expectedBulkId = "BULK-1234";
        var expectedStatusName = "PENDING";
        var expectedText = "Rich HTML message body.";
        var expectedHtml = "<h1>Html body</h1><p>Rich HTML message body.</p>";


        var expectedResponse = $@"
            {{
                ""messages"": [
                {{
                    ""to"": ""{expectedTo}"",
                    ""messageCount"": {expectedMessageCount},
                    ""messageId"": ""{expectedMessageId}"",
                    ""status"": {{
                        ""groupId"": {expectedStatusGroupId},
                        ""groupName"": ""{expectedStatusName}"",
                        ""id"": {expectedStatusId},
                        ""name"": ""{expectedStatusName}"",
                        ""description"": ""{expectedStatusDescription}""
                    }}
                }},
                {{
                    ""to"": ""{expectedTo2}"",
                    ""messageId"": ""{expectedMessageId2}"",
                    ""status"": {{
                        ""groupId"": {expectedStatusGroupId},
                        ""groupName"": ""{expectedStatusName}"",
                        ""id"": {expectedStatusId},
                        ""name"": ""{expectedStatusName}"",
                        ""description"": ""{expectedStatusDescription}""
                    }}
                }}
                ]
            }}";

        var parts = new Multimap<string, string>
        {
            { "from", expectedFrom },
            { "to", expectedTo },
            { "to", expectedTo2 },
            { "cc", expectedCc },
            { "cc", expectedCc2 },
            { "bcc", expectedBcc },
            { "bcc", expectedBcc2 },
            { "text", expectedText },
            { "html", expectedHtml },
            { "replyTo", expectedReplyTo },
            { "subject", expectedSubject }
        };

        SetUpMultipartFormRequest(EMAIL_SEND_FULLY_FEATURED_ENDPOINT, parts, expectedResponse);

        var sendEmailApi = new EmailApi(configuration);

        var expectedToList = new List<string>
        {
            expectedTo,
            expectedTo2
        };

        var expectedCcList = new List<string>
        {
            expectedCc,
            expectedCc2
        };

        var expectedBccList = new List<string>
        {
            expectedBcc,
            expectedBcc2
        };

        var response = sendEmailApi.SendEmail(
            from: expectedFrom,
            to: expectedToList,
            subject: expectedSubject,
            cc: expectedCcList,
            bcc: expectedBccList,
            text: expectedText,
            bulkId: expectedBulkId,
            messageId: expectedMessageId,
            html: expectedHtml,
            replyTo: expectedReplyTo
        );

        Assert.AreEqual(expectedMessageCount, response.Messages.Count);
        Assert.AreEqual(expectedMessageId, response.Messages[0].MessageId);
        Assert.AreEqual(expectedTo, response.Messages[0].To);
        Assert.AreEqual(expectedStatusId, response.Messages[0].Status.Id);
        Assert.AreEqual(expectedStatusName, response.Messages[0].Status.Name);
        Assert.AreEqual(expectedStatusGroupId, response.Messages[0].Status.GroupId);
        Assert.AreEqual(expectedStatusDescription, response.Messages[0].Status.Description);
        Assert.AreEqual(expectedStatusGroupId, response.Messages[0].Status.GroupId);
        Assert.AreEqual(expectedMessageId2, response.Messages[1].MessageId);
        Assert.AreEqual(expectedTo2, response.Messages[1].To);
        Assert.AreEqual(expectedStatusId, response.Messages[1].Status.Id);
        Assert.AreEqual(expectedStatusName, response.Messages[1].Status.Name);
        Assert.AreEqual(expectedStatusGroupId, response.Messages[1].Status.GroupId);
        Assert.AreEqual(expectedStatusDescription, response.Messages[1].Status.Description);
        Assert.AreEqual(expectedStatusGroupId, response.Messages[1].Status.GroupId);
    }

    [TestMethod]
    public void ShouldSendEmailWithAttachmentTest()
    {
        var expectedFrom = "Jane Doe <jane.doe@example.com";
        var expectedTo = "john.smith@example.com";
        var expectedReplyTo = "all.replies@example.com";
        var expectedSubject = "Mail subject text";
        var expectedStatusDescription = "Message sent to next instance";
        var expectedMessageCount = 1;
        var expectedStatusId = 1;
        var expectedStatusGroupId = 1;
        var expectedMessageId = "MSG-1234";
        var expectedBulkId = "BULK-1234";
        var expectedStatusName = "PENDING";
        var expectedText = "Rich HTML message body.";
        var expectedHtml = "<h1>Html body</h1><p>Rich HTML message body.</p>";
        var expectedAttachmentText = "This is a test file";
        var expectedAttachmentText2 = "This is another test file";

        var expectedResponse = $@"
            {{
                ""messages"": [
                {{
                    ""to"": ""{expectedTo}"",
                    ""messageCount"": {expectedMessageCount},
                    ""messageId"": ""{expectedMessageId}"",
                    ""status"": {{
                        ""groupId"": {expectedStatusGroupId},
                        ""groupName"": ""{expectedStatusName}"",
                        ""id"": {expectedStatusId},
                        ""name"": ""{expectedStatusName}"",
                        ""description"": ""{expectedStatusDescription}""
                    }}
                }}]
            }}";

        var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(expectedAttachmentText));
        var attachmentStream = new FileParameter(memoryStream);

        var memoryStream2 = new MemoryStream(Encoding.UTF8.GetBytes(expectedAttachmentText2));
        var attachmentStream2 = new FileParameter(memoryStream2);

        var parts = new Multimap<string, string>
        {
            { "from", expectedFrom },
            { "to", expectedTo },
            { "text", expectedText },
            { "html", expectedHtml },
            { "replyTo", expectedReplyTo },
            { "subject", expectedSubject },
            { "attachment", expectedAttachmentText },
            { "attachment", expectedAttachmentText2 }
        };

        SetUpMultipartFormRequest(EMAIL_SEND_FULLY_FEATURED_ENDPOINT, parts, expectedResponse);

        var sendEmailApi = new EmailApi(configuration);

        var expectedToList = new List<string>
        {
            expectedTo
        };

        var attachmentList = new List<FileParameter>
        {
            attachmentStream,
            attachmentStream2
        };

        var response = sendEmailApi.SendEmail(
            from: expectedFrom,
            to: expectedToList,
            subject: expectedSubject,
            text: expectedText,
            bulkId: expectedBulkId,
            messageId: expectedMessageId,
            attachment: attachmentList,
            html: expectedHtml,
            replyTo: expectedReplyTo
        );

        Assert.AreEqual(expectedMessageCount, response.Messages.Count);
        Assert.AreEqual(expectedMessageId, response.Messages[0].MessageId);
        Assert.AreEqual(expectedTo, response.Messages[0].To);
        Assert.AreEqual(expectedStatusId, response.Messages[0].Status.Id);
        Assert.AreEqual(expectedStatusName, response.Messages[0].Status.Name);
        Assert.AreEqual(expectedStatusGroupId, response.Messages[0].Status.GroupId);
        Assert.AreEqual(expectedStatusDescription, response.Messages[0].Status.Description);
        Assert.AreEqual(expectedStatusGroupId, response.Messages[0].Status.GroupId);
    }

    [TestMethod]
    public void ShouldGetEmailLogsTest()
    {
        var expectedTo = "john.smith@example.com";
        var expectedMessageCount = 1;
        var expectedMessageId = "MSG-1234";
        var expectedBulkId = "BULK-1234";
        var expectedSentAt = new DateTimeOffset(2021, 9, 2, 9, 57, 56, TimeSpan.FromHours(0));
        var expectedDoneAt = new DateTimeOffset(2021, 9, 2, 9, 58, 33, TimeSpan.FromHours(0));
        var expectedCurrency = "EUR";
        var expectedPricePerMessage = 0.0M;
        var expectedStatusName = "DELIVERED_TO_HANDSET";
        var expectedStatusId = 5;
        var expectedStatusDescription = "Message delivered to handset";
        var expectedStatusGroupId = 3;
        var expectedStatusGroupName = "DELIVERED";
        var expectedErrorName = "NO_ERROR";
        var expectedErrorId = 5;
        var expectedErrorDescription = "No Error";
        var expectedErrorGroupId = 0;
        var expectedErrorGroupName = "OK";
        var expectedErrorPermanent = false;
        var expectedChannel = "EMAIL";

        var expectedResponse = $@"
            {{
                ""results"": [
                    {{
                        ""bulkId"": ""{expectedBulkId}"",
                        ""messageId"": ""{expectedMessageId}"",
                        ""to"": ""{expectedTo}"",
                        ""sentAt"": ""{expectedSentAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                        ""doneAt"": ""{expectedDoneAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                        ""messageCount"": {expectedMessageCount},
                        ""price"": {{
                            ""pricePerMessage"": {expectedPricePerMessage.ToString("N", CultureInfo.InvariantCulture)},
                            ""currency"": ""{expectedCurrency}""
                        }},
                        ""status"": {{
                            ""groupId"": {expectedStatusGroupId},
                            ""groupName"": ""{expectedStatusGroupName}"",
                            ""id"": {expectedStatusId},
                            ""name"": ""{expectedStatusName}"",
                            ""description"": ""{expectedStatusDescription}""
                        }},
                        ""error"": {{
                            ""groupId"": {expectedErrorGroupId},
                            ""groupName"": ""{expectedErrorGroupName}"",
                            ""id"": {expectedErrorId},
                            ""name"": ""{expectedErrorName}"",
                            ""description"": ""{expectedErrorDescription}"",
                            ""permanent"": {expectedErrorPermanent.ToString().ToLower()}
                        }},
                        ""channel"": ""{expectedChannel}""
                    }}
                ]
            }}";

        SetUpGetRequest(EMAIL_LOGS_ENDPOINT, 200, expectedResponse);

        var sendEmailApi = new EmailApi(configuration);

        var response = sendEmailApi.GetEmailDeliveryReports(expectedBulkId, expectedMessageId, limit: 2);

        Assert.AreEqual(1, response.Results.Count);
        Assert.AreEqual(expectedBulkId, response.Results[0].BulkId);
        Assert.AreEqual(expectedMessageId, response.Results[0].MessageId);

        Assert.AreEqual(expectedSentAt, response.Results[0].SentAt);
        Assert.AreEqual(expectedDoneAt, response.Results[0].DoneAt);
        Assert.AreEqual(expectedMessageCount, response.Results[0].MessageCount);

        Assert.AreEqual(expectedStatusDescription, response.Results[0].Status.Description);
        Assert.AreEqual(expectedStatusGroupId, response.Results[0].Status.GroupId);
        Assert.AreEqual(expectedStatusGroupName, response.Results[0].Status.GroupName);
        Assert.AreEqual(expectedStatusId, response.Results[0].Status.Id);
        Assert.AreEqual(expectedStatusName, response.Results[0].Status.Name);

        Assert.AreEqual(expectedPricePerMessage, response.Results[0].Price.PricePerMessage);

        Assert.AreEqual(expectedErrorDescription, response.Results[0].Error.Description);
        Assert.AreEqual(expectedErrorGroupId, response.Results[0].Error.GroupId);
        Assert.AreEqual(expectedErrorGroupName, response.Results[0].Error.GroupName);
        Assert.AreEqual(expectedErrorId, response.Results[0].Error.Id);
        Assert.AreEqual(expectedErrorName, response.Results[0].Error.Name);
        Assert.AreEqual(expectedErrorPermanent, response.Results[0].Error.Permanent);
    }

    [TestMethod]
    public void ShouldGetEmailDeliveryReportsTest()
    {
        var expectedFrom = "Jane Doe <jane.doe@example.com";
        var expectedTo = "john.smith@example.com";
        var expectedText = "Mail body text";
        var expectedMessageCount = 1;
        var expectedMessageId = "MSG-1234";
        var expectedBulkId = "BULK-1234";
        var expectedSentAt = new DateTimeOffset(2021, 9, 2, 9, 57, 56, TimeSpan.FromHours(0));
        var expectedDoneAt = new DateTimeOffset(2021, 9, 2, 9, 57, 56, TimeSpan.FromHours(0));
        var expectedCurrency = "EUR";
        var expectedPricePerMessage = 0.0m;
        var expectedStatusName = "DELIVERED_TO_HANDSET";
        var expectedStatusId = 5;
        var expectedStatusDescription = "Message delivered to handset";
        var expectedStatusGroupId = 3;
        var expectedStatusGroupName = "DELIVERED";
        var expectedChannel = "EMAIL";

        var expectedResponse = $@"
            {{
                ""results"": [
                {{
                    ""messageId"": ""{expectedMessageId}"",
                    ""to"": ""{expectedTo}"",
                    ""from"": ""{expectedFrom}"",
                    ""text"": ""{expectedText}"",
                    ""sentAt"": ""{expectedSentAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                    ""doneAt"": ""{expectedDoneAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                    ""messageCount"": {expectedMessageCount},
                    ""price"": {{
                        ""pricePerMessage"": {expectedPricePerMessage.ToString("N", CultureInfo.InvariantCulture)},
                        ""currency"": ""{expectedCurrency}""
                    }},
                    ""status"": {{
                        ""groupId"": {expectedStatusGroupId},
                        ""groupName"": ""{expectedStatusGroupName}"",
                        ""id"": {expectedStatusId},
                        ""name"": ""{expectedStatusName}"",
                        ""description"": ""{expectedStatusDescription}""
                    }},
                    ""channel"": ""{expectedChannel}"",
                    ""bulkId"": ""{expectedBulkId}""
                }}
                ]
            }}";

        SetUpGetRequest(EMAIL_REPORTS_ENDPOINT, 200, expectedResponse);

        var sendEmailApi = new EmailApi(configuration);

        var response = sendEmailApi.GetEmailLogs(
            bulkId: expectedBulkId,
            messageId: expectedMessageId,
            limit: 2
        );

        Assert.AreEqual(1, response.Results.Count);

        Assert.AreEqual(expectedFrom, response.Results[0].From);
        Assert.AreEqual(expectedBulkId, response.Results[0].BulkId);
        Assert.AreEqual(expectedMessageId, response.Results[0].MessageId);
        Assert.AreEqual(expectedSentAt, response.Results[0].SentAt);
        Assert.AreEqual(expectedDoneAt, response.Results[0].DoneAt);
        Assert.AreEqual(expectedText, response.Results[0].Text);
        Assert.AreEqual(expectedTo, response.Results[0].To);
        Assert.AreEqual(expectedMessageCount, response.Results[0].MessageCount);

        Assert.AreEqual(expectedStatusDescription, response.Results[0].Status.Description);
        Assert.AreEqual(expectedStatusGroupId, response.Results[0].Status.GroupId);
        Assert.AreEqual(expectedStatusGroupName, response.Results[0].Status.GroupName);
        Assert.AreEqual(expectedStatusId, response.Results[0].Status.Id);
        Assert.AreEqual(expectedStatusName, response.Results[0].Status.Name);

        Assert.AreEqual(expectedPricePerMessage, response.Results[0].Price.PricePerMessage);
    }

    [TestMethod]
    public void ShouldGetScheduledEmailsTest()
    {
        var expectedExternalBulkId = "BULK-1234";
        var expectedBulkId = "1234593932111";
        var expectedSentAt = new DateTimeOffset(2021, 9, 2, 9, 56, 53, TimeSpan.FromHours(0));

        var expectedResponse = $@"
            {{
                ""externalBulkId"": ""{expectedExternalBulkId}"",
                ""bulks"": [
                    {{
                        ""bulkId"": ""{expectedBulkId}"",
                        ""sendAt"": ""{expectedSentAt.ToUniversalTime().ToString(DATE_FORMAT)}""
                    }}
                ]
            }}";

        SetUpGetRequest(EMAIL_BULKS_ENDPOINT, 200, expectedResponse);

        var scheduledEmailApi = new EmailApi(configuration);

        var response = scheduledEmailApi.GetScheduledEmails(expectedBulkId);

        Assert.AreEqual(1, response.Bulks.Count);
        Assert.AreEqual(expectedExternalBulkId, response.ExternalBulkId);

        Assert.AreEqual(expectedBulkId, response.Bulks[0].BulkId);
        Assert.AreEqual(expectedSentAt, response.Bulks[0].SendAt);
    }

    [TestMethod]
    public void ShouldRescheduleEmailsTest()
    {
        var expectedBulkId = "1234593932111";
        var expectedSentAt = new DateTimeOffset(2023, 5, 16, 11, 55, 51, TimeSpan.FromHours(0));

        var givenRequest = $@"
            {{
                ""sendAt"": ""{expectedSentAt.ToUniversalTime().ToString(DATE_FORMAT)}""
            }}";

        var expectedResponse = $@"
            {{
                ""bulkId"": ""{expectedBulkId}"",
                ""sendAt"": ""{expectedSentAt.ToUniversalTime().ToString(DATE_FORMAT)}""
            }}";

        SetUpPutRequest(EMAIL_BULKS_ENDPOINT, 200, givenRequest, expectedResponse);

        var scheduledEmailApi = new EmailApi(configuration);
        var rescheduleRequest = new EmailBulkRescheduleRequest(expectedSentAt);

        var response = scheduledEmailApi.RescheduleEmails(expectedBulkId, rescheduleRequest);

        Assert.AreEqual(expectedBulkId, response.BulkId);
        Assert.AreEqual(expectedSentAt, response.SendAt);
    }

    [TestMethod]
    public void ShouldGetScheduledEmailStatusTest()
    {
        var expectedExternalBulkId = "BULK-1234";
        var expectedBulkId = "1234593932111";
        var expectedBulkId2 = "1234594942111";

        var expectedStatus = EmailBulkStatus.Finished;
        var expectedStatus2 = EmailBulkStatus.Pending;

        var expectedResponse = $@"
            {{
                ""externalBulkId"": ""{expectedExternalBulkId}"",
                ""bulks"": [
                {{
                    ""bulkId"": ""{expectedBulkId}"",
                    ""status"": ""{expectedStatus}""
                }},
                {{
                    ""bulkId"": ""{expectedBulkId2}"",
                    ""status"": ""{expectedStatus2}""
                }}
                ]
            }}";

        SetUpGetRequest(EMAIL_BULKS_STATUS_ENDPOINT, 200, expectedResponse);

        var scheduledEmailApi = new EmailApi(configuration);

        var response = scheduledEmailApi.GetScheduledEmailStatuses(expectedBulkId);

        Assert.AreEqual(2, response.Bulks.Count);
        Assert.AreEqual(expectedExternalBulkId, response.ExternalBulkId);
        Assert.AreEqual(expectedBulkId, response.Bulks[0].BulkId);
        Assert.AreEqual(expectedStatus, response.Bulks[0].Status);
        Assert.AreEqual(expectedBulkId2, response.Bulks[1].BulkId);
        Assert.AreEqual(expectedStatus2, response.Bulks[1].Status);
    }

    [TestMethod]
    public void ShouldUpdateEmailStatusTest()
    {
        var expectedBulkId = "1234593932111";
        var expectedStatus = EmailBulkStatus.Paused;

        var givenRequest = $@"
            {{
                ""status"": ""{expectedStatus}"",
            }}";

        var expectedResponse = $@"
            {{
                ""bulkId"": ""{expectedBulkId}"",
                ""status"": ""{expectedStatus}""
            }}";

        SetUpPutRequest(EMAIL_BULKS_STATUS_ENDPOINT, 200, givenRequest, expectedResponse);

        var scheduledEmailApi = new EmailApi(configuration);

        var updateStatusRequest = new EmailBulkUpdateStatusRequest(expectedStatus);

        var response = scheduledEmailApi.UpdateScheduledEmailStatuses(expectedBulkId, updateStatusRequest);

        Assert.AreEqual(expectedBulkId, response.BulkId);
        Assert.AreEqual(expectedStatus, response.Status);
    }

    [TestMethod]
    public void ValidateEmailAddressesTest()
    {
        var expectedTo = "john.smith@example.com";
        var expectedValidMailbox = "true";
        var expectedValidSyntax = true;
        var expectedCatchAll = false;
        var expectedDidYouMean = "true";
        var expectedDisposable = false;
        var expectedRoleBased = true;

        var givenRequest = $@"
            {{
                ""to"": ""{expectedTo}"",
            }}";

        var expectedResponse = $@"
            {{
                ""to"": ""{expectedTo}"",
                ""validMailbox"": {expectedValidMailbox},
                ""validSyntax"": {expectedValidSyntax.ToString().ToLower()},
                ""catchAll"": {expectedCatchAll.ToString().ToLower()},
                ""didYouMean"": {expectedDidYouMean},
                ""disposable"": {expectedDisposable.ToString().ToLower()},
                ""roleBased"": {expectedRoleBased.ToString().ToLower()}
            }}";

        SetUpPostRequest(EMAIL_VALIDATE_ADDRESSES_ENDPOINT, 200, givenRequest, expectedResponse);

        var emailValidationApi = new EmailApi(configuration);

        var validationRequest = new EmailValidationRequest(expectedTo);

        var response = emailValidationApi.ValidateEmailAddresses(validationRequest);

        Assert.IsNotNull(response);
        Assert.AreEqual(expectedTo, response.To);
        Assert.AreEqual(expectedCatchAll, response.CatchAll);
        Assert.AreEqual(expectedDidYouMean, response.DidYouMean);
        Assert.AreEqual(expectedDisposable, response.Disposable);
        Assert.AreEqual(expectedRoleBased, response.RoleBased);
        Assert.AreEqual(expectedValidMailbox, response.ValidMailbox);
        Assert.AreEqual(expectedValidSyntax, response.ValidSyntax);
    }

    [TestMethod]
    public void ShouldGetAllDomainsForTheAccount()
    {
        var expectedPage = 0;
        var expectedSize = 0;
        var expectedTotalPages = 0;
        var expectedTotalResults = 0;
        var expectedDomainId = 1;
        var expectedDomainName = "example.com";
        var expectedActive = false;
        var expectedClicks = true;
        var expectedOpens = true;
        var expectedUnsubscribe = true;
        var expectedRecordType = "string";
        var expectedName = "string";
        var expectedExpectedValue = "string";
        var expectedVerified = true;
        var expectedBlocked = false;
        var expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
        var expectedReturnPathAddress = "returnpath@example.com";

        var expectedResponse = $@"
            {{
                ""paging"": {{
                    ""page"": {expectedPage},
                    ""size"": {expectedSize},
                    ""totalPages"": {expectedTotalPages},
                    ""totalResults"": {expectedTotalResults}
                }},
                ""results"": [
                    {{
                         ""domainId"": {expectedDomainId},
                         ""domainName"": ""{expectedDomainName}"",
                         ""active"": {expectedActive.ToString().ToLower()},
                         ""tracking"": {{
                            ""clicks"": {expectedClicks.ToString().ToLower()},
                            ""opens"": {expectedOpens.ToString().ToLower()},
                            ""unsubscribe"": {expectedUnsubscribe.ToString().ToLower()}
                         }},
                         ""dnsRecords"": [
                            {{
                                ""recordType"": ""{expectedRecordType}"",
                                ""name"": ""{expectedName}"",
                                ""expectedValue"": ""{expectedExpectedValue}"",
                                ""verified"": {expectedVerified.ToString().ToLower()}
                            }}
                         ],
                         ""blocked"": {expectedBlocked.ToString().ToLower()},
                         ""createdAt"": ""{expectedCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                         ""returnPathAddress"": ""{expectedReturnPathAddress}""
                    }}
                ]
            }}";

        var expectedQueryParameters = new Dictionary<string, string>
        {
            { "size", expectedSize.ToString() },
            { "page", expectedPage.ToString() }
        };

        SetUpGetRequest(EMAIL_DOMAINS, 200, expectedResponse, expectedQueryParameters);

        var emailApi = new EmailApi(configuration);

        void AssertEmailAllDomainsResponse(EmailAllDomainsResponse emailAllDomainsResponse)
        {
            Assert.IsNotNull(emailAllDomainsResponse.Paging);
            Assert.AreEqual(expectedPage, emailAllDomainsResponse.Paging.Page);
            Assert.AreEqual(expectedSize, emailAllDomainsResponse.Paging.Size);
            Assert.AreEqual(expectedTotalPages, emailAllDomainsResponse.Paging.TotalPages);
            Assert.AreEqual(expectedTotalResults, emailAllDomainsResponse.Paging.TotalResults);

            Assert.IsNotNull(emailAllDomainsResponse.Results);
            Assert.AreEqual(expectedDomainId, emailAllDomainsResponse.Results[0].DomainId);
            Assert.AreEqual(expectedDomainName, emailAllDomainsResponse.Results[0].DomainName);
            Assert.AreEqual(expectedActive, emailAllDomainsResponse.Results[0].Active);
            Assert.AreEqual(expectedClicks, emailAllDomainsResponse.Results[0].Tracking.Clicks);
            Assert.AreEqual(expectedOpens, emailAllDomainsResponse.Results[0].Tracking.Opens);
            Assert.AreEqual(expectedUnsubscribe, emailAllDomainsResponse.Results[0].Tracking.Unsubscribe);
            Assert.AreEqual(expectedRecordType, emailAllDomainsResponse.Results[0].DnsRecords[0].RecordType);
            Assert.AreEqual(expectedName, emailAllDomainsResponse.Results[0].DnsRecords[0].Name);
            Assert.AreEqual(expectedExpectedValue, emailAllDomainsResponse.Results[0].DnsRecords[0].ExpectedValue);
            Assert.AreEqual(expectedVerified, emailAllDomainsResponse.Results[0].DnsRecords[0].Verified);
            Assert.AreEqual(expectedBlocked, emailAllDomainsResponse.Results[0].Blocked);
            Assert.AreEqual(expectedCreatedAt, emailAllDomainsResponse.Results[0].CreatedAt);
            Assert.AreEqual(expectedReturnPathAddress, emailAllDomainsResponse.Results[0].ReturnPathAddress);
        }

        AssertResponse(emailApi.GetAllDomains(expectedSize, expectedPage), AssertEmailAllDomainsResponse);
        AssertResponse(emailApi.GetAllDomainsAsync(expectedSize, expectedPage).Result, AssertEmailAllDomainsResponse);

        AssertResponseWithHttpInfo(emailApi.GetAllDomainsWithHttpInfo(expectedSize, expectedPage),
            AssertEmailAllDomainsResponse, 200);
        AssertResponseWithHttpInfo(emailApi.GetAllDomainsWithHttpInfoAsync(expectedSize, expectedPage).Result,
            AssertEmailAllDomainsResponse, 200);
    }

    [TestMethod]
    public void ShouldAddNewDomain()
    {
        var givenDkimKeyLength = 1024;
        long givenTargetedDailyTraffic = 1000;
        var givenApplicationId = "string";
        var givenEntityId = "string";

        var expectedDomainId = 1;
        var expectedDomainName = "example.com";
        var expectedActive = false;
        var expectedClicks = true;
        var expectedOpens = true;
        var expectedUnsubscribe = true;
        var expectedRecordType = "string";
        var expectedName = "string";
        var expectedExpectedValue = "string";
        var expectedVerified = true;
        var expectedBlocked = false;
        var expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
        var expectedReturnPathAddress = "returnpath@example.com";

        var givenRequest = $@"
            {{
                ""domainName"": ""{expectedDomainName}"",
                ""dkimKeyLength"": {givenDkimKeyLength},
                ""targetedDailyTraffic"": {givenTargetedDailyTraffic},
                ""applicationId"": ""{givenApplicationId}"",
                ""entityId"": ""{givenEntityId}"",
                ""returnPathAddress"": ""{expectedReturnPathAddress}""
            }}";

        var expectedResponse = $@"
            {{
                ""domainId"": {expectedDomainId},
                ""domainName"": ""{expectedDomainName}"",
                ""active"": {expectedActive.ToString().ToLower()},
                ""tracking"": {{
                    ""clicks"": {expectedClicks.ToString().ToLower()},
                    ""opens"": {expectedOpens.ToString().ToLower()},
                    ""unsubscribe"": {expectedUnsubscribe.ToString().ToLower()}
                }},
                ""dnsRecords"": [
                    {{
                        ""recordType"": ""{expectedRecordType}"",
                        ""name"": ""{expectedName}"",
                        ""expectedValue"": ""{expectedExpectedValue}"",
                        ""verified"": {expectedVerified.ToString().ToLower()}
                    }}
                ],
                ""blocked"": {expectedBlocked.ToString().ToLower()},
                ""createdAt"": ""{expectedCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                ""returnPathAddress"": ""{expectedReturnPathAddress}""
            }}";

        SetUpPostRequest(EMAIL_DOMAINS, 200, givenRequest, expectedResponse);

        var emailApi = new EmailApi(configuration);

        var emailAddDomainRequest = new EmailAddDomainRequest(
            expectedDomainName,
            DkimKeyLengthEnum.NUMBER1024,
            givenTargetedDailyTraffic,
            givenApplicationId,
            givenEntityId,
            expectedReturnPathAddress
        );

        void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
        {
            Assert.IsNotNull(emailDomainResponse);
            Assert.AreEqual(expectedDomainId, emailDomainResponse.DomainId);
            Assert.AreEqual(expectedDomainName, emailDomainResponse.DomainName);
            Assert.AreEqual(expectedActive, emailDomainResponse.Active);
            Assert.AreEqual(expectedClicks, emailDomainResponse.Tracking.Clicks);
            Assert.AreEqual(expectedOpens, emailDomainResponse.Tracking.Opens);
            Assert.AreEqual(expectedUnsubscribe, emailDomainResponse.Tracking.Unsubscribe);
            Assert.AreEqual(expectedRecordType, emailDomainResponse.DnsRecords[0].RecordType);
            Assert.AreEqual(expectedName, emailDomainResponse.DnsRecords[0].Name);
            Assert.AreEqual(expectedExpectedValue, emailDomainResponse.DnsRecords[0].ExpectedValue);
            Assert.AreEqual(expectedVerified, emailDomainResponse.DnsRecords[0].Verified);
            Assert.AreEqual(expectedBlocked, emailDomainResponse.Blocked);
            Assert.AreEqual(expectedCreatedAt, emailDomainResponse.CreatedAt);
            Assert.AreEqual(expectedReturnPathAddress, emailDomainResponse.ReturnPathAddress);
        }

        AssertResponse(emailApi.AddDomain(emailAddDomainRequest), AssertEmailDomainResponse);
        AssertResponse(emailApi.AddDomainAsync(emailAddDomainRequest).Result, AssertEmailDomainResponse);

        AssertResponseWithHttpInfo(emailApi.AddDomainWithHttpInfo(emailAddDomainRequest), AssertEmailDomainResponse,
            200);
        AssertResponseWithHttpInfo(emailApi.AddDomainWithHttpInfoAsync(emailAddDomainRequest).Result,
            AssertEmailDomainResponse, 200);
    }

    [TestMethod]
    public void ShouldGetDomainDetails()
    {
        var expectedDomainId = 1;
        var expectedDomainName = "example.com";
        var expectedActive = false;
        var expectedClicks = true;
        var expectedOpens = true;
        var expectedUnsubscribe = true;
        var expectedRecordType = "string";
        var expectedName = "string";
        var expectedExpectedValue = "string";
        var expectedVerified = true;
        var expectedBlocked = false;
        var expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
        var expectedReturnPathAddress = "returnpath@example.com";

        var expectedResponse = $@"
            {{
                ""domainId"": {expectedDomainId},
                ""domainName"": ""{expectedDomainName}"",
                ""active"": {expectedActive.ToString().ToLower()},
                ""tracking"": {{
                    ""clicks"": {expectedClicks.ToString().ToLower()},
                    ""opens"": {expectedOpens.ToString().ToLower()},
                    ""unsubscribe"": {expectedUnsubscribe.ToString().ToLower()}
                }},
                ""dnsRecords"": [
                    {{
                        ""recordType"": ""{expectedRecordType}"",
                        ""name"": ""{expectedName}"",
                        ""expectedValue"": ""{expectedExpectedValue}"",
                        ""verified"": {expectedVerified.ToString().ToLower()}
                    }}
                ],
                ""blocked"": {expectedBlocked.ToString().ToLower()},
                ""createdAt"": ""{expectedCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                ""returnPathAddress"": ""{expectedReturnPathAddress}""
            }}";

        SetUpGetRequest(EMAIL_DOMAIN.Replace("{domainName}", expectedDomainName), 200, expectedResponse);

        var emailApi = new EmailApi(configuration);

        void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
        {
            Assert.IsNotNull(emailDomainResponse);
            Assert.AreEqual(expectedDomainId, emailDomainResponse.DomainId);
            Assert.AreEqual(expectedDomainName, emailDomainResponse.DomainName);
            Assert.AreEqual(expectedActive, emailDomainResponse.Active);
            Assert.AreEqual(expectedClicks, emailDomainResponse.Tracking.Clicks);
            Assert.AreEqual(expectedOpens, emailDomainResponse.Tracking.Opens);
            Assert.AreEqual(expectedUnsubscribe, emailDomainResponse.Tracking.Unsubscribe);
            Assert.AreEqual(expectedRecordType, emailDomainResponse.DnsRecords[0].RecordType);
            Assert.AreEqual(expectedName, emailDomainResponse.DnsRecords[0].Name);
            Assert.AreEqual(expectedExpectedValue, emailDomainResponse.DnsRecords[0].ExpectedValue);
            Assert.AreEqual(expectedVerified, emailDomainResponse.DnsRecords[0].Verified);
            Assert.AreEqual(expectedBlocked, emailDomainResponse.Blocked);
            Assert.AreEqual(expectedCreatedAt, emailDomainResponse.CreatedAt);
            Assert.AreEqual(expectedReturnPathAddress, emailDomainResponse.ReturnPathAddress);
        }

        AssertResponse(emailApi.GetDomainDetails(expectedDomainName), AssertEmailDomainResponse);
        AssertResponse(emailApi.GetDomainDetailsAsync(expectedDomainName).Result, AssertEmailDomainResponse);

        AssertResponseWithHttpInfo(emailApi.GetDomainDetailsWithHttpInfo(expectedDomainName),
            AssertEmailDomainResponse, 200);
        AssertResponseWithHttpInfo(emailApi.GetDomainDetailsWithHttpInfoAsync(expectedDomainName).Result,
            AssertEmailDomainResponse, 200);
    }

    [TestMethod]
    public void ShouldDeleteExistingDomain()
    {
        var givenDomainName = "domainName";

        SetUpDeleteRequest(EMAIL_DOMAIN.Replace("{domainName}", givenDomainName), 204);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(emailApi.DeleteDomainWithHttpInfo(givenDomainName), 204);
        AssertNoBodyResponseWithHttpInfo(emailApi.DeleteDomainWithHttpInfoAsync(givenDomainName).Result,
            204);
    }

    [TestMethod]
    public void ShouldUpdateTrackingEvents()
    {
        var expectedDomainId = 1;
        var expectedDomainName = "example.com";
        var expectedActive = false;
        var expectedClicks = true;
        var expectedOpens = true;
        var expectedUnsubscribe = true;
        var expectedRecordType = "string";
        var expectedName = "string";
        var expectedExpectedValue = "string";
        var expectedVerified = true;
        var expectedBlocked = false;
        var expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
        var expectedReturnPathAddress = "returnpath@example.com";

        var givenRequest = $@"
            {{
                ""open"": {expectedOpens.ToString().ToLower()},
                ""clicks"": {expectedClicks.ToString().ToLower()},
                ""unsubscribe"": {expectedUnsubscribe.ToString().ToLower()}
            }}";

        var expectedResponse = $@"
            {{
                ""domainId"": {expectedDomainId},
                ""domainName"": ""{expectedDomainName}"",
                ""active"": {expectedActive.ToString().ToLower()},
                ""tracking"": {{
                    ""clicks"": {expectedClicks.ToString().ToLower()},
                    ""opens"": {expectedOpens.ToString().ToLower()},
                    ""unsubscribe"": {expectedUnsubscribe.ToString().ToLower()}
                }},
                ""dnsRecords"": [
                    {{
                        ""recordType"": ""{expectedRecordType}"",
                        ""name"": ""{expectedName}"",
                        ""expectedValue"": ""{expectedExpectedValue}"",
                        ""verified"": {expectedVerified.ToString().ToLower()}
                    }}
                ],
                ""blocked"": {expectedBlocked.ToString().ToLower()},
                ""createdAt"": ""{expectedCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                ""returnPathAddress"": ""{expectedReturnPathAddress}""
            }}";

        SetUpPutRequest(EMAIL_DOMAIN_TRACKING.Replace("{domainName}", expectedDomainName), 200, givenRequest,
            expectedResponse);

        var emailApi = new EmailApi(configuration);

        var emailTrackingEventRequest = new EmailTrackingEventRequest(
            expectedOpens,
            expectedClicks,
            expectedUnsubscribe
        );

        void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
        {
            Assert.IsNotNull(emailDomainResponse);
            Assert.AreEqual(expectedDomainId, emailDomainResponse.DomainId);
            Assert.AreEqual(expectedDomainName, emailDomainResponse.DomainName);
            Assert.AreEqual(expectedActive, emailDomainResponse.Active);
            Assert.AreEqual(expectedClicks, emailDomainResponse.Tracking.Clicks);
            Assert.AreEqual(expectedOpens, emailDomainResponse.Tracking.Opens);
            Assert.AreEqual(expectedUnsubscribe, emailDomainResponse.Tracking.Unsubscribe);
            Assert.AreEqual(expectedRecordType, emailDomainResponse.DnsRecords[0].RecordType);
            Assert.AreEqual(expectedName, emailDomainResponse.DnsRecords[0].Name);
            Assert.AreEqual(expectedExpectedValue, emailDomainResponse.DnsRecords[0].ExpectedValue);
            Assert.AreEqual(expectedVerified, emailDomainResponse.DnsRecords[0].Verified);
            Assert.AreEqual(expectedBlocked, emailDomainResponse.Blocked);
            Assert.AreEqual(expectedCreatedAt, emailDomainResponse.CreatedAt);
            Assert.AreEqual(expectedReturnPathAddress, emailDomainResponse.ReturnPathAddress);
        }

        AssertResponse(emailApi.UpdateTrackingEvents(expectedDomainName, emailTrackingEventRequest),
            AssertEmailDomainResponse);
        AssertResponse(emailApi.UpdateTrackingEventsAsync(expectedDomainName, emailTrackingEventRequest).Result,
            AssertEmailDomainResponse);

        AssertResponseWithHttpInfo(
            emailApi.UpdateTrackingEventsWithHttpInfo(expectedDomainName, emailTrackingEventRequest),
            AssertEmailDomainResponse, 200);
        AssertResponseWithHttpInfo(
            emailApi.UpdateTrackingEventsWithHttpInfoAsync(expectedDomainName, emailTrackingEventRequest).Result,
            AssertEmailDomainResponse, 200);
    }

    [TestMethod]
    public void ShouldUpdateReturnPath()
    {
        var expectedDomainId = 1;
        var expectedDomainName = "example.com";
        var expectedActive = false;
        var expectedClicks = true;
        var expectedOpens = true;
        var expectedUnsubscribe = true;
        var expectedRecordType = "string";
        var expectedName = "string";
        var expectedExpectedValue = "string";
        var expectedVerified = true;
        var expectedBlocked = false;
        var expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
        var expectedReturnPathAddress = "returnpath@example.com";

        var givenRequest = $@"
            {{
                ""returnPathAddress"": ""{expectedReturnPathAddress}"",
            }}";

        var expectedResponse = $@"
            {{
                ""domainId"": {expectedDomainId},
                ""domainName"": ""{expectedDomainName}"",
                ""active"": {expectedActive.ToString().ToLower()},
                ""tracking"": {{
                    ""clicks"": {expectedClicks.ToString().ToLower()},
                    ""opens"": {expectedOpens.ToString().ToLower()},
                    ""unsubscribe"": {expectedUnsubscribe.ToString().ToLower()}
                }},
                ""dnsRecords"": [
                    {{
                        ""recordType"": ""{expectedRecordType}"",
                        ""name"": ""{expectedName}"",
                        ""expectedValue"": ""{expectedExpectedValue}"",
                        ""verified"": {expectedVerified.ToString().ToLower()}
                    }}
                ],
                ""blocked"": {expectedBlocked.ToString().ToLower()},
                ""createdAt"": ""{expectedCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                ""returnPathAddress"": ""{expectedReturnPathAddress}""
            }}";

        SetUpPutRequest(EMAIL_DOMAIN_RETURN_PATH.Replace("{domainName}", expectedDomainName), 200, givenRequest,
            expectedResponse);

        var emailApi = new EmailApi(configuration);

        var emailReturnPathAddressRequest = new EmailReturnPathAddressRequest(
            expectedReturnPathAddress
        );

        void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
        {
            Assert.IsNotNull(emailDomainResponse);
            Assert.AreEqual(expectedDomainId, emailDomainResponse.DomainId);
            Assert.AreEqual(expectedDomainName, emailDomainResponse.DomainName);
            Assert.AreEqual(expectedActive, emailDomainResponse.Active);
            Assert.AreEqual(expectedClicks, emailDomainResponse.Tracking.Clicks);
            Assert.AreEqual(expectedOpens, emailDomainResponse.Tracking.Opens);
            Assert.AreEqual(expectedUnsubscribe, emailDomainResponse.Tracking.Unsubscribe);
            Assert.AreEqual(expectedRecordType, emailDomainResponse.DnsRecords[0].RecordType);
            Assert.AreEqual(expectedName, emailDomainResponse.DnsRecords[0].Name);
            Assert.AreEqual(expectedExpectedValue, emailDomainResponse.DnsRecords[0].ExpectedValue);
            Assert.AreEqual(expectedVerified, emailDomainResponse.DnsRecords[0].Verified);
            Assert.AreEqual(expectedBlocked, emailDomainResponse.Blocked);
            Assert.AreEqual(expectedCreatedAt, emailDomainResponse.CreatedAt);
            Assert.AreEqual(expectedReturnPathAddress, emailDomainResponse.ReturnPathAddress);
        }

        AssertResponse(emailApi.UpdateReturnPath(expectedDomainName, emailReturnPathAddressRequest),
            AssertEmailDomainResponse);
        AssertResponse(emailApi.UpdateReturnPathAsync(expectedDomainName, emailReturnPathAddressRequest).Result,
            AssertEmailDomainResponse);

        AssertResponseWithHttpInfo(
            emailApi.UpdateReturnPathWithHttpInfo(expectedDomainName, emailReturnPathAddressRequest),
            AssertEmailDomainResponse, 200);
        AssertResponseWithHttpInfo(
            emailApi.UpdateReturnPathWithHttpInfoAsync(expectedDomainName, emailReturnPathAddressRequest).Result,
            AssertEmailDomainResponse, 200);
    }

    [TestMethod]
    public void ShouldVerifyDomain()
    {
        var givenDomainName = "domainName";

        SetUpPostRequest(EMAIL_DOMAIN_VERIFY.Replace("{domainName}", givenDomainName), 202);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(emailApi.VerifyDomainWithHttpInfo(givenDomainName), 202);
        AssertNoBodyResponseWithHttpInfo(emailApi.VerifyDomainWithHttpInfoAsync(givenDomainName).Result,
            202);
    }

    [TestMethod]
    public void ShouldGetSuppresions()
    {
        var expectedDomainName = "example.com";
        var expectedEmailAddress = "jane.smith@example.org";
        var expectedType = "BOUNCE";
        var expectedCreatedDate = "2024-08-14T14:02:17.366Z";
        var expectedReason = "550 5.1.1 <jane.smith@example.org>: user does not exist";
        var expectedPage = 0;
        var expectedSize = 100;

        var expectedResponse = $@"
            {{
              ""results"": [
                {{
                  ""domainName"": ""{expectedDomainName}"",
                  ""emailAddress"": ""{expectedEmailAddress}"",
                  ""type"": ""{expectedType}"",
                  ""createdDate"": ""{expectedCreatedDate}"",
                  ""reason"": ""{expectedReason}""
                }}
              ],
              ""paging"": {{
                ""page"": {expectedPage},
                ""size"": {expectedSize}
              }}
            }}";

        var givenDomainName = "example.com";
        var givenType = EmailSuppressionType.Bounce;
        var givenPage = 0;
        var givenSize = 100;

        var givenQueryParameters = new Dictionary<string, string>
        {
            { "domainName", expectedEmailAddress },
            { "type", GetEnumAttributeValue(EmailSuppressionType.Bounce) },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        SetUpGetRequest(EMAIL_SUPPRESIONS_ENDPOINT, 200, expectedResponse, givenQueryParameters);

        var emailApi = new EmailApi(configuration);

        void AssertEmailSuppressionInfoPageResponse(EmailSuppressionInfoPageResponse emailSuppressionInfoPageResponse)
        {
            Assert.IsNotNull(emailSuppressionInfoPageResponse);

            var results = emailSuppressionInfoPageResponse.Results;
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(expectedDomainName, results[0].DomainName);
            Assert.AreEqual(expectedEmailAddress, results[0].EmailAddress);
            Assert.AreEqual(expectedType, results[0].Type);
            Assert.AreEqual(DateTimeOffset.Parse(expectedCreatedDate), results[0].CreatedDate);
            Assert.AreEqual(expectedReason, results[0].Reason);

            Assert.AreEqual(expectedPage, emailSuppressionInfoPageResponse.Paging.Page);
            Assert.AreEqual(expectedSize, emailSuppressionInfoPageResponse.Paging.Size);
        }

        AssertResponse(emailApi.GetSuppressions(domainName: givenDomainName, type: givenType, page: givenPage, size:givenSize),
            AssertEmailSuppressionInfoPageResponse);
        AssertResponse(emailApi.GetSuppressionsAsync(domainName: givenDomainName, type: givenType, page: givenPage, size:givenSize).Result,
            AssertEmailSuppressionInfoPageResponse);

        AssertResponseWithHttpInfo(
            emailApi.GetSuppressionsWithHttpInfo(domainName: givenDomainName, type: givenType, page: givenPage, size:givenSize),
            AssertEmailSuppressionInfoPageResponse, 200);
        AssertResponseWithHttpInfo(
            emailApi.GetSuppressionsWithHttpInfoAsync(domainName: givenDomainName, type: givenType, page: givenPage, size:givenSize).Result,
            AssertEmailSuppressionInfoPageResponse, 200);
    }

    [TestMethod]
    public void ShouldAddSuppresions()
    {
        var givenDomainName = "example.com";
        var givenEmailAddress = "jane.smith@example.org";
        var givenSecondEmailAddress = "john.doe@example.org";
        var givenType = "BOUNCE";
        var givenAnotherDomainName = "another.example.com";
        var givenAnotherEmailAddress = "john.smith@example.org";
        var givenAnotherSecondEmailAddress = "john.perry@example.org";
        var givenAnotherType = "BOUNCE";

        var givenRequest = $@"
            {{
              ""suppressions"": [
                {{
                  ""domainName"": ""{givenDomainName}"",
                  ""emailAddress"": [
                    ""{givenEmailAddress}"",
                    ""{givenSecondEmailAddress}""
                  ],
                  ""type"": ""{givenType}""
                }},
                {{
                  ""domainName"": ""{givenAnotherDomainName}"",
                  ""emailAddress"": [
                    ""{givenAnotherEmailAddress}"",
                    ""{givenAnotherSecondEmailAddress}""
                  ],
                  ""type"": ""{givenAnotherType}""
                }}
              ]
            }}";

        var emailAddSuppressionRequest = new EmailAddSuppressionRequest(
            new List<EmailAddSuppression>
            {
                new(
                    givenDomainName,
                    new List<string>
                    {
                        givenEmailAddress,
                        givenSecondEmailAddress
                    },
                    EmailAddSuppressionType.Bounce
                ),
                new(
                    givenAnotherDomainName,
                    new List<string>
                    {
                        givenAnotherEmailAddress,
                        givenAnotherSecondEmailAddress
                    },
                    EmailAddSuppressionType.Bounce
                )
            }
        );

        SetUpPostRequest(EMAIL_SUPPRESIONS_ENDPOINT, 204, givenRequest);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(
            emailApi.AddSuppressionsWithHttpInfo(emailAddSuppressionRequest), 204);
        AssertNoBodyResponseWithHttpInfo(
            emailApi.AddSuppressionsWithHttpInfoAsync(emailAddSuppressionRequest).Result, 204);
    }

    [TestMethod]
    public void ShouldDeleteSuppresions()
    {
        var givenDomainName = "example.com";
        var givenEmailAddress = "jane.smith@example.org";
        var givenSecondEmailAddress = "john.doe@example.org";
        var givenType = "BOUNCE";
        var givenAnotherDomainName = "another.example.com";
        var givenAnotherEmailAddress = "john.smith@example.org";
        var givenAnotherSecondEmailAddress = "john.perry@example.org";
        var givenAnotherType = "COMPLAINT";
        var givenYetAnotherDomainName = "example.com";
        var givenYetAnotherEmailAddress = "jack@peterson@example.org";
        var givenYetAnotherType = "OVER_QUOTA";

        var givenRequest = $@"
            {{
              ""suppressions"": [
                {{
                  ""domainName"": ""{givenDomainName}"",
                  ""emailAddress"": [
                    ""{givenEmailAddress}"",
                    ""{givenSecondEmailAddress}""
                  ],
                  ""type"": ""{givenType}""
                }},
                {{
                  ""domainName"": ""{givenAnotherDomainName}"",
                  ""emailAddress"": [
                    ""{givenAnotherEmailAddress}"",
                    ""{givenAnotherSecondEmailAddress}""
                  ],
                  ""type"": ""{givenAnotherType}""
                }},
                {{
                  ""domainName"": ""{givenYetAnotherDomainName}"",
                  ""emailAddress"": [
                    ""{givenYetAnotherEmailAddress}""
                  ],
                  ""type"": ""{givenYetAnotherType}""
                }}
              ]
            }}";

        var emailDeleteSuppressionRequest = new EmailDeleteSuppressionRequest(
            new List<EmailDeleteSuppression>
            {
                new(
                    givenDomainName,
                    new List<string>
                    {
                        givenEmailAddress,
                        givenSecondEmailAddress
                    },
                    EmailSuppressionType.Bounce
                ),
                new(
                    givenAnotherDomainName,
                    new List<string>
                    {
                        givenAnotherEmailAddress,
                        givenAnotherSecondEmailAddress
                    },
                    EmailSuppressionType.Complaint
                ),
                new(
                    givenYetAnotherDomainName,
                    new List<string>
                    {
                        givenYetAnotherEmailAddress
                    },
                    EmailSuppressionType.OverQuota
                )
            }
        );

        SetUpDeleteRequest(EMAIL_SUPPRESIONS_ENDPOINT, 204, givenRequest);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(
            emailApi.DeleteSuppressionsWithHttpInfo(emailDeleteSuppressionRequest), 204);
        AssertNoBodyResponseWithHttpInfo(
            emailApi.DeleteSuppressionsWithHttpInfoAsync(emailDeleteSuppressionRequest).Result, 204);
    }

    [TestMethod]
    public void ShouldGetSuppresionDomains()
    {
        var expectedDomainName = "another.example.com";
        var expectedDataAccess = EmailDomainAccess.Owner;
        var expectedReadBounces = true;
        var expectedCreateBounces = true;
        var expectedDeleteBounces = true;
        var expectedReadComplaints = true;
        var expectedCreateComplaints = true;
        var expectedDeleteComplaints = true;
        var expectedReadOverquotas = true;
        var expectedDeleteOverquotas = true;
        var expectedSecondDomainName = "example.com";
        var expectedSecondDataAccess = EmailDomainAccess.Granted;
        var expectedSecondReadBounces = true;
        var expectedSecondCreateBounces = true;
        var expectedSecondDeleteBounces = false;
        var expectedSecondReadComplaints = true;
        var expectedSecondCreateComplaints = false;
        var expectedSecondDeleteComplaints = false;
        var expectedSecondReadOverquotas = false;
        var expectedSecondDeleteOverquotas = false;
        var expectedPage = 0;
        var expectedSize = 100;

        var expectedResponse = $@"
            {{
              ""results"": [
                {{
                  ""domainName"": ""{expectedDomainName}"",
                  ""dataAccess"": ""{GetEnumAttributeValue(expectedDataAccess)}"",
                  ""readBounces"": {expectedReadBounces.ToString().ToLower()},
                  ""createBounces"": {expectedCreateBounces.ToString().ToLower()},
                  ""deleteBounces"": {expectedDeleteBounces.ToString().ToLower()},
                  ""readComplaints"": {expectedReadComplaints.ToString().ToLower()},
                  ""createComplaints"": {expectedCreateComplaints.ToString().ToLower()},
                  ""deleteComplaints"": {expectedDeleteComplaints.ToString().ToLower()},
                  ""readOverquotas"": {expectedReadOverquotas.ToString().ToLower()},
                  ""deleteOverquotas"": {expectedDeleteOverquotas.ToString().ToLower()}
                }},
                {{
                  ""domainName"": ""{expectedSecondDomainName.ToLower()}"",
                  ""dataAccess"": ""{GetEnumAttributeValue(expectedSecondDataAccess)}"",
                  ""readBounces"": {expectedSecondReadBounces.ToString().ToLower()},
                  ""createBounces"": {expectedSecondCreateBounces.ToString().ToLower()},
                  ""deleteBounces"": {expectedSecondDeleteBounces.ToString().ToLower()},
                  ""readComplaints"": {expectedSecondReadComplaints.ToString().ToLower()},
                  ""createComplaints"": {expectedSecondCreateComplaints.ToString().ToLower()},
                  ""deleteComplaints"": {expectedSecondDeleteComplaints.ToString().ToLower()},
                  ""readOverquotas"": {expectedSecondReadOverquotas.ToString().ToLower()},
                  ""deleteOverquotas"": {expectedSecondDeleteOverquotas.ToString().ToLower()}
                }}
              ],
              ""paging"": {{
                ""page"": {expectedPage},
                ""size"": {expectedSize}
              }}
            }}";

        var givenPage = 0;
        var givenSize = 100;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        SetUpGetRequest(EMAIL_SUPPRESIONS_DOMAINS_ENDPOINT, 200, expectedResponse, givenQueryParameters);

        var emailApi = new EmailApi(configuration);

        void AssertEmailDomainInfoPageResponse(EmailDomainInfoPageResponse emailDomainInfoPageResponse)
        {
            Assert.IsNotNull(emailDomainInfoPageResponse);

            var results = emailDomainInfoPageResponse.Results;
            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(expectedDomainName, results[0].DomainName);
            Assert.AreEqual(expectedDataAccess, results[0].DataAccess);
            Assert.AreEqual(expectedReadBounces, results[0].ReadBounces);
            Assert.AreEqual(expectedCreateBounces, results[0].CreateBounces);
            Assert.AreEqual(expectedDeleteBounces, results[0].DeleteBounces);
            Assert.AreEqual(expectedReadComplaints, results[0].ReadComplaints);
            Assert.AreEqual(expectedCreateComplaints, results[0].CreateComplaints);
            Assert.AreEqual(expectedDeleteComplaints, results[0].DeleteComplaints);
            Assert.AreEqual(expectedReadOverquotas, results[0].ReadOverquotas);
            Assert.AreEqual(expectedDeleteOverquotas, results[0].DeleteOverquotas);

            Assert.AreEqual(expectedSecondDomainName, results[1].DomainName);
            Assert.AreEqual(expectedSecondDataAccess, results[1].DataAccess);
            Assert.AreEqual(expectedSecondReadBounces, results[1].ReadBounces);
            Assert.AreEqual(expectedSecondCreateBounces, results[1].CreateBounces);
            Assert.AreEqual(expectedSecondDeleteBounces, results[1].DeleteBounces);
            Assert.AreEqual(expectedSecondReadComplaints, results[1].ReadComplaints);
            Assert.AreEqual(expectedSecondCreateComplaints, results[1].CreateComplaints);
            Assert.AreEqual(expectedSecondDeleteComplaints, results[1].DeleteComplaints);
            Assert.AreEqual(expectedSecondReadOverquotas, results[1].ReadOverquotas);
            Assert.AreEqual(expectedSecondDeleteOverquotas, results[1].DeleteOverquotas);

            Assert.AreEqual(expectedPage, emailDomainInfoPageResponse.Paging.Page);
            Assert.AreEqual(expectedSize, emailDomainInfoPageResponse.Paging.Size);
        }

        AssertResponse(emailApi.GetDomains(givenPage, givenSize), AssertEmailDomainInfoPageResponse);
        AssertResponse(emailApi.GetDomainsAsync(givenPage, givenSize).Result, AssertEmailDomainInfoPageResponse);

        AssertResponseWithHttpInfo(emailApi.GetDomainsWithHttpInfo(givenPage, givenSize),
            AssertEmailDomainInfoPageResponse, 200);
        AssertResponseWithHttpInfo(emailApi.GetDomainsWithHttpInfoAsync(givenPage, givenSize).Result,
            AssertEmailDomainInfoPageResponse, 200);
    }

    [TestMethod]
    public void ShouldGetIps()
    {
        var expectedId = "DB3F9D439088BF73F5560443C8054AC4";
        var expectedIp = "198.51.100.0";

        var expectedResponse = $@"
            [
              {{
                ""id"": ""{expectedId}"",
                ""ip"": ""{expectedIp}""
              }}
            ]";

        SetUpGetRequest(EMAIL_IPS_ENDPOINT, 200, expectedResponse);

        var emailApi = new EmailApi(configuration);

        void AssertEmailIpResponse(List<EmailIpResponse> emailIpResponses)
        {
            Assert.IsNotNull(emailIpResponses);
            Assert.AreEqual(1, emailIpResponses.Count);

            Assert.AreEqual(expectedId, emailIpResponses[0].Id);
            Assert.AreEqual(expectedIp, emailIpResponses[0].Ip);
        }

        AssertResponse(emailApi.GetAllIps(), AssertEmailIpResponse);
        AssertResponse(emailApi.GetAllIpsAsync().Result, AssertEmailIpResponse);

        AssertResponseWithHttpInfo(emailApi.GetAllIpsWithHttpInfo(), AssertEmailIpResponse, 200);
        AssertResponseWithHttpInfo(emailApi.GetAllIpsWithHttpInfoAsync().Result, AssertEmailIpResponse, 200);
    }

    [TestMethod]
    public void ShouldGetIp()
    {
        var expectedId = "DB3F9D439088BF73F5560443C8054AC4";
        var expectedIp = "198.51.100.0";
        var expectedPoolId = "08A3A7608750CC6E6080325A6ADF45B6";
        var expectedPoolName = "IP pool name";

        var expectedResponse = $@"
            {{
              ""id"": ""{expectedId}"",
              ""ip"": ""{expectedIp}"",
              ""pools"": [
                {{
                  ""id"": ""{expectedPoolId}"",
                  ""name"": ""{expectedPoolName}""
                }}
              ]
            }}";

        var givenIpId = "DB3F9D439088BF73F5560443C8054AC4";

        SetUpGetRequest(EMAIL_IP_ENDPOINT.Replace("{ipId}", givenIpId), 200, expectedResponse);

        var emailApi = new EmailApi(configuration);

        void AssertEmailIpDetailResponse(EmailIpDetailResponse emailIpDetailResponse)
        {
            Assert.IsNotNull(emailIpDetailResponse);

            Assert.AreEqual(expectedId, emailIpDetailResponse.Id);
            Assert.AreEqual(expectedIp, emailIpDetailResponse.Ip);

            Assert.IsNotNull(emailIpDetailResponse.Pools);
            Assert.AreEqual(1, emailIpDetailResponse.Pools.Count);

            Assert.AreEqual(expectedPoolId, emailIpDetailResponse.Pools[0].Id);
            Assert.AreEqual(expectedPoolName, emailIpDetailResponse.Pools[0].Name);
        }

        AssertResponse(emailApi.GetIpDetails(givenIpId), AssertEmailIpDetailResponse);
        AssertResponse(emailApi.GetIpDetailsAsync(givenIpId).Result, AssertEmailIpDetailResponse);

        AssertResponseWithHttpInfo(emailApi.GetIpDetailsWithHttpInfo(givenIpId), AssertEmailIpDetailResponse, 200);
        AssertResponseWithHttpInfo(emailApi.GetIpDetailsWithHttpInfoAsync(givenIpId).Result,
            AssertEmailIpDetailResponse, 200);
    }

    [TestMethod]
    public void ShouldGetIpPools()
    {
        var expectedId = "08A3A7608750CC6E6080325A6ADF45B6";
        var expectedName = "IP pool name";

        var expectedResponse = $@"
            [
              {{
                ""id"": ""{expectedId}"",
                ""name"": ""{expectedName}""
              }}
            ]";

        var givenName = "IP pool name";
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "name", givenName }
        };

        SetUpGetRequest(EMAIL_IP_POOLS_ENDPOINT, 200, expectedResponse, givenQueryParameters);

        var emailApi = new EmailApi(configuration);

        void AssertEmailIpPoolResponse(List<EmailIpPoolResponse> emailIpPoolResponses)
        {
            Assert.IsNotNull(emailIpPoolResponses);
            Assert.AreEqual(1, emailIpPoolResponses.Count);

            Assert.AreEqual(expectedId, emailIpPoolResponses[0].Id);
            Assert.AreEqual(expectedName, emailIpPoolResponses[0].Name);
        }

        AssertResponse(emailApi.GetIpPools(givenName), AssertEmailIpPoolResponse);
        AssertResponse(emailApi.GetIpPoolsAsync(givenName).Result, AssertEmailIpPoolResponse);

        AssertResponseWithHttpInfo(emailApi.GetIpPoolsWithHttpInfo(givenName), AssertEmailIpPoolResponse, 200);
        AssertResponseWithHttpInfo(emailApi.GetIpPoolsWithHttpInfoAsync(givenName).Result, AssertEmailIpPoolResponse,
            200);
    }

    [TestMethod]
    public void ShouldCreateIpPool()
    {
        var expectedId = "08A3A7608750CC6E6080325A6ADF45B6";
        var expectedName = "IP pool name";

        var expectedResponse = $@"
            {{
              ""id"": ""{expectedId}"",
              ""name"": ""{expectedName}""
            }}";

        var givenName = "IP Pool name";

        var givenRequest = $@"
            {{
              ""name"": ""{givenName}""
            }}";

        SetUpPostRequest(EMAIL_IP_POOLS_ENDPOINT, 201, givenRequest, expectedResponse);

        var emailIpPoolCreateRequest = new EmailIpPoolCreateApiRequest(
            givenName
        );

        var emailApi = new EmailApi(configuration);

        void AssertEmailIpPoolResponse(EmailIpPoolResponse emailIpPoolResponse)
        {
            Assert.IsNotNull(emailIpPoolResponse);

            Assert.AreEqual(expectedId, emailIpPoolResponse.Id);
            Assert.AreEqual(expectedName, emailIpPoolResponse.Name);
        }

        AssertResponse(emailApi.CreateIpPool(emailIpPoolCreateRequest), AssertEmailIpPoolResponse);
        AssertResponse(emailApi.CreateIpPoolAsync(emailIpPoolCreateRequest).Result, AssertEmailIpPoolResponse);

        AssertResponseWithHttpInfo(emailApi.CreateIpPoolWithHttpInfo(emailIpPoolCreateRequest),
            AssertEmailIpPoolResponse, 201);
        AssertResponseWithHttpInfo(emailApi.CreateIpPoolWithHttpInfoAsync(emailIpPoolCreateRequest).Result,
            AssertEmailIpPoolResponse, 201);
    }

    [TestMethod]
    public void ShouldGetIpPool()
    {
        var expectedId = "08A3A7608750CC6E6080325A6ADF45B6";
        var expectedName = "IP pool name";
        var expectedIpsId = "DB3F9D439088BF73F5560443C8054AC4";
        var expectedIpsIp = "example.com";

        var expectedResponse = $@"
            {{
              ""id"": ""{expectedId}"",
              ""name"": ""{expectedName}"",
              ""ips"": [
                {{
                  ""id"": ""{expectedIpsId}"",
                  ""ip"": ""{expectedIpsIp}""
                }}
              ]
            }}";

        var givenPoolId = "08A3A7608750CC6E6080325A6ADF45B6";

        SetUpGetRequest(EMAIL_IP_POOL_ENDPOINT.Replace("{poolId}", givenPoolId), 200, expectedResponse);

        var emailApi = new EmailApi(configuration);

        void AssertEmailIpPoolDetailResponse(EmailIpPoolDetailResponse emailIpPoolDetailResponse)
        {
            Assert.IsNotNull(emailIpPoolDetailResponse);

            Assert.AreEqual(expectedId, emailIpPoolDetailResponse.Id);
            Assert.AreEqual(expectedName, emailIpPoolDetailResponse.Name);

            Assert.IsNotNull(emailIpPoolDetailResponse.Ips);
            Assert.AreEqual(1, emailIpPoolDetailResponse.Ips.Count);

            Assert.AreEqual(expectedIpsId, emailIpPoolDetailResponse.Ips[0].Id);
            Assert.AreEqual(expectedIpsIp, emailIpPoolDetailResponse.Ips[0].Ip);
        }

        AssertResponse(emailApi.GetIpPool(givenPoolId), AssertEmailIpPoolDetailResponse);
        AssertResponse(emailApi.GetIpPoolAsync(givenPoolId).Result, AssertEmailIpPoolDetailResponse);

        AssertResponseWithHttpInfo(emailApi.GetIpPoolWithHttpInfo(givenPoolId), AssertEmailIpPoolDetailResponse, 200);
        AssertResponseWithHttpInfo(emailApi.GetIpPoolWithHttpInfoAsync(givenPoolId).Result,
            AssertEmailIpPoolDetailResponse, 200);
    }

    [TestMethod]
    public void ShouldUpdateIpPool()
    {
        var expectedId = "08A3A7608750CC6E6080325A6ADF45B6";
        var expectedName = "IP pool name";

        var expectedResponse = $@"
            {{
              ""id"": ""{expectedId}"",
              ""name"": ""{expectedName}""
            }}";

        var givenName = "IP Pool name";

        var givenRequest = $@"
            {{
              ""name"": ""{givenName}""
            }}";

        var givenPoolId = "08A3A7608750CC6E6080325A6ADF45B6";

        SetUpPutRequest(EMAIL_IP_POOL_ENDPOINT.Replace("{poolId}", givenPoolId), 200, givenRequest, expectedResponse);

        var emailIpPoolCreateRequest = new EmailIpPoolCreateApiRequest(
            givenName
        );

        var emailApi = new EmailApi(configuration);

        void AssertEmailIpPoolResponse(EmailIpPoolResponse emailIpPoolResponse)
        {
            Assert.IsNotNull(emailIpPoolResponse);

            Assert.AreEqual(expectedId, emailIpPoolResponse.Id);
            Assert.AreEqual(expectedName, emailIpPoolResponse.Name);
        }

        AssertResponse(emailApi.UpdateIpPool(givenPoolId, emailIpPoolCreateRequest), AssertEmailIpPoolResponse);
        AssertResponse(emailApi.UpdateIpPoolAsync(givenPoolId, emailIpPoolCreateRequest).Result,
            AssertEmailIpPoolResponse);

        AssertResponseWithHttpInfo(emailApi.UpdateIpPoolWithHttpInfo(givenPoolId, emailIpPoolCreateRequest),
            AssertEmailIpPoolResponse, 200);
        AssertResponseWithHttpInfo(emailApi.UpdateIpPoolWithHttpInfoAsync(givenPoolId, emailIpPoolCreateRequest).Result,
            AssertEmailIpPoolResponse, 200);
    }

    [TestMethod]
    public void ShouldDeletePool()
    {
        var givenPoolId = "08A3A7608750CC6E6080325A6ADF45B6";

        SetUpDeleteRequest(EMAIL_IP_POOL_ENDPOINT.Replace("{poolId}", givenPoolId), 204);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(emailApi.DeleteIpPoolWithHttpInfo(givenPoolId), 204);
        AssertNoBodyResponseWithHttpInfo(emailApi.DeleteIpPoolWithHttpInfoAsync(givenPoolId).Result, 204);
    }

    [TestMethod]
    public void ShouldAssignIpToPool()
    {
        var givenIpId = "DB3F9D439088BF73F5560443C8054AC4";

        var givenRequest = $@"
            {{
              ""ipId"": ""{givenIpId}""
            }}";

        var givenPoolId = "08A3A7608750CC6E6080325A6ADF45B6";

        var emailIpPoolAssignIpRequest = new EmailIpPoolAssignIpApiRequest(
            givenIpId
        );

        SetUpPostRequest(EMAIL_IP_POOLS_IPS_ENDPOINT.Replace("{poolId}", givenPoolId), 204, givenRequest);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(emailApi.AssignIpToPoolWithHttpInfo(givenPoolId, emailIpPoolAssignIpRequest),
            204);
        AssertNoBodyResponseWithHttpInfo(
            emailApi.AssignIpToPoolWithHttpInfoAsync(givenPoolId, emailIpPoolAssignIpRequest).Result, 204);
    }

    [TestMethod]
    public void ShouldUnassignIpFromPool()
    {
        var givenPoolId = "08A3A7608750CC6E6080325A6ADF45B6";
        var givenIpId = "DB3F9D439088BF73F5560443C8054AC4";

        SetUpDeleteRequest(EMAIL_IP_POOLS_IP_ENDPOINT.Replace("{poolId}", givenPoolId).Replace("{ipId}", givenIpId),
            204);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(emailApi.RemoveIpFromPoolWithHttpInfo(givenPoolId, givenIpId), 204);
        AssertNoBodyResponseWithHttpInfo(emailApi.RemoveIpFromPoolWithHttpInfoAsync(givenPoolId, givenIpId).Result,
            204);
    }

    [TestMethod]
    public void ShouldGetDomain()
    {
        var expectedId = 1;
        var expectedName = "example.com";
        var expectedPoolsId = "08A3A7608750CC6E6080325A6ADF45B6";
        var expectedPoolsName = "IP pool name";
        var expectedPoolsPriority = 0;
        var expectedIpsId = "DB3F9D439088BF73F5560443C8054AC4";
        var expectedIpsIp = "198.51.100.0";

        var expectedResponse = $@"
            {{
              ""id"": {expectedId},
              ""name"": ""{expectedName}"",
              ""pools"": [
                {{
                  ""id"": ""{expectedPoolsId}"",
                  ""name"": ""{expectedPoolsName}"",
                  ""priority"": {expectedPoolsPriority},
                  ""ips"": [
                    {{
                      ""id"": ""{expectedIpsId}"",
                      ""ip"": ""{expectedIpsIp}""
                    }}
                  ]
                }}
              ]
            }}";

        var givenDomainId = 1;

        SetUpGetRequest(EMAIL_IP_DOMAIN_ENDPOINT.Replace("{domainId}", givenDomainId.ToString()), 200,
            expectedResponse);

        var emailApi = new EmailApi(configuration);

        void AssertEmailIpDomainResponse(EmailIpDomainResponse emailIpDomainResponse)
        {
            Assert.IsNotNull(emailIpDomainResponse);

            Assert.AreEqual(expectedId, emailIpDomainResponse.Id);
            Assert.AreEqual(expectedName, emailIpDomainResponse.Name);

            var pools = emailIpDomainResponse.Pools;
            Assert.IsNotNull(pools);
            Assert.AreEqual(1, pools.Count);

            Assert.AreEqual(expectedPoolsId, pools[0].Id);
            Assert.AreEqual(expectedPoolsName, pools[0].Name);
            Assert.AreEqual(expectedPoolsPriority, pools[0].Priority);

            var ips = pools[0].Ips;
            Assert.IsNotNull(ips);
            Assert.AreEqual(1, ips.Count);

            Assert.AreEqual(expectedIpsId, ips[0].Id);
            Assert.AreEqual(expectedIpsIp, ips[0].Ip);
        }

        AssertResponse(emailApi.GetIpDomain(givenDomainId), AssertEmailIpDomainResponse);
        AssertResponse(emailApi.GetIpDomainAsync(givenDomainId).Result, AssertEmailIpDomainResponse);

        AssertResponseWithHttpInfo(emailApi.GetIpDomainWithHttpInfo(givenDomainId), AssertEmailIpDomainResponse, 200);
        AssertResponseWithHttpInfo(emailApi.GetIpDomainWithHttpInfoAsync(givenDomainId).Result,
            AssertEmailIpDomainResponse, 200);
    }

    [TestMethod]
    public void ShouldAssignIpPoolToDomain()
    {
        var givenPoolId = "08A3A7608750CC6E6080325A6ADF45B6";
        var givenPriority = 0;

        var givenRequest = $@"
            {{
              ""poolId"": ""{givenPoolId}"",
              ""priority"": {givenPriority}
            }}";

        var emailDomainIpPoolAssignRequest = new EmailDomainIpPoolAssignApiRequest(
            givenPoolId,
            givenPriority
        );

        var givenDomainId = 1;

        SetUpPostRequest(EMAIL_IP_DOMAIN_POOLS_ENDPOINT.Replace("{domainId}", givenDomainId.ToString()), 204,
            givenRequest);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(
            emailApi.AssignPoolToDomainWithHttpInfo(givenDomainId, emailDomainIpPoolAssignRequest), 204);
        AssertNoBodyResponseWithHttpInfo(
            emailApi.AssignPoolToDomainWithHttpInfoAsync(givenDomainId, emailDomainIpPoolAssignRequest).Result, 204);
    }

    [TestMethod]
    public void ShouldUpdateIpPoolSendingPriority()
    {
        var givenPriority = 0;

        var givenRequest = $@"
            {{
             ""priority"": {givenPriority}
            }}";

        var givenDomainId = 1;
        var givenPoolId = "08A3A7608750CC6E6080325A6ADF45B6";

        var emailDomainIpPoolUpdateRequest = new EmailDomainIpPoolUpdateApiRequest(
            givenPriority
        );

        SetUpPutRequest(
            EMAIL_IP_DOMAIN_POOL_ENDPOINT.Replace("{domainId}", givenDomainId.ToString())
                .Replace("{poolId}", givenPoolId), 204, givenRequest);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(
            emailApi.UpdateDomainPoolPriorityWithHttpInfo(givenDomainId, givenPoolId, emailDomainIpPoolUpdateRequest),
            204);
        AssertNoBodyResponseWithHttpInfo(
            emailApi.UpdateDomainPoolPriorityWithHttpInfoAsync(givenDomainId, givenPoolId,
                emailDomainIpPoolUpdateRequest).Result, 204);
    }

    [TestMethod]
    public void ShouldUnassignIpPoolFromDomain()
    {
        var givenDomainId = 1;
        var givenPoolId = "08A3A7608750CC6E6080325A6ADF45B6";

        SetUpDeleteRequest(
            EMAIL_IP_DOMAIN_POOL_ENDPOINT.Replace("{domainId}", givenDomainId.ToString())
                .Replace("{poolId}", givenPoolId), 204);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(emailApi.RemoveIpPoolFromDomainWithHttpInfo(givenDomainId, givenPoolId), 204);
        AssertNoBodyResponseWithHttpInfo(
            emailApi.RemoveIpPoolFromDomainWithHttpInfoAsync(givenDomainId, givenPoolId).Result, 204);
    }

    [DataTestMethod]
    [DataRow(0)]
    [DataRow(1)]
    public void SendEmailErrorResponseTest(int errorResponseIndex)
    {
        var expectedHttpCode = ErrorResponses[errorResponseIndex].Item1;
        var expectedMessageId = ErrorResponses[errorResponseIndex].Item2;
        var expectedErrorText = ErrorResponses[errorResponseIndex].Item4;
        var expectedErrorPhrase = ErrorResponses[errorResponseIndex].Item3;

        var givenTo = "john.smith@example.com";
        var givenMessageCount = 1;
        var givenMessageId = "somexternalMessageId";
        var givenGroupId = 1;
        var givenGroupName = "PENDING";
        var givenId = 7;
        var givenName = "PENDING_ENROUTE";
        var givenDescription = "Message sent to next instance";
        var givenFrom = "jane.smith@example.com";
        var givenSubject = "Mail subject text";
        var givenMailText = "Mail text";

        var givenRequest = $@"
            {{
              ""messages"": [
                {{
                  ""to"": ""{givenTo}"",
                  ""messageCount"": {givenMessageCount},
                  ""messageId"": ""{givenMessageId}"",
                  ""status"": {{
                    ""groupId"": {givenGroupId},
                    ""groupName"": ""{givenGroupName}"",
                    ""id"": {givenId},
                    ""name"": ""{givenName}"",
                    ""description"": ""{givenDescription}""
                  }}
                }}
              ]
            }}";

        var expectedJson = $@"
            {{
                ""requestError"": {{
                    ""serviceException"": {{
                        ""messageId"": ""{expectedMessageId}"",
                        ""text"": ""{expectedErrorText}""
                    }}
                }}
            }}";

        var responseHeaders = new Dictionary<string, string>
        {
            { "Server", "SMS,API" },
            { "X-Request-ID", "1608758729810312842" },
            { "Content-Type", "application/json; charset=utf-8" }
        };

        var givenParts = new Multimap<string, string>
        {
            { "from", givenFrom },
            { "to", givenTo },
            { "subject", givenSubject },
            { "text", givenMailText }
        };

        SetUpMultipartFormRequest(EMAIL_SEND_FULLY_FEATURED_ENDPOINT, givenParts, expectedJson, expectedHttpCode);

        var emailApi = new EmailApi(configuration);

        var toList = new List<string>
        {
            givenTo
        };

        try
        {
            var result = emailApi.SendEmail(from: givenFrom, to: toList, subject: givenSubject, text: givenMailText);
        }
        catch (ApiException ex)
        {
            Assert.AreEqual(expectedHttpCode, ex.ErrorCode);
            Assert.AreEqual(expectedJson, ex.ErrorContent);
            Assert.IsInstanceOfType(ex, typeof(ApiException));
            Assert.IsTrue(ex.Message.Contains(expectedErrorPhrase));
            Assert.IsTrue(ex.ErrorContent.ToString()?.Contains(expectedMessageId) == true);
            Assert.IsTrue(ex.ErrorContent.ToString()?.Contains(expectedErrorText) == true);
            Assert.IsTrue(responseHeaders.All(h =>
                ex.Headers.ContainsKey(h.Key) && ex.Headers[h.Key].First().Equals(h.Value)));
        }
    }

    [TestMethod]
    public void ShouldReceiveEmailDeliveryReport()
    {
        var givenBulkId = "aszzmbhu62l7bxkhmyrj";
        var givenPricePerMessage = 0;
        var givenCurrency = "UNKNOWN";
        var givenStatusId = 5;
        var givenStatusGroupId = 3;
        var givenStatusGroupName = "DELIVERED";
        var givenStatusName = "DELIVERED_TO_HANDSET";
        var givenStatusDescription = "Message delivered to handset";
        var givenErrorId = 0;
        var givenErrorName = "NO_ERROR";
        var givenErrorDescription = "No Error";
        var givenErrorGroupId = 0;
        var givenErrorGroupName = "OK";
        var givenErrorPermanent = false;
        var givenMessageId = "hgtesn8bcmc71pujp92d";
        var givenDoneAt = "2020-09-08T05:27:59.256+0000";
        var givenSmsCount = 1;
        var givenSentAt = "2020-09-08T05:27:57.628+0000";
        var givenBrowserLink =
            "http://tracking.domain.com/render/content?id=9A31C6F61DBAE9664D74C7A5A5A01F92283F581D11EA80A28C12E83BC83D449BC4A9F32F1AE3C3E";
        var givenSendingIp = "1.2.3.4";
        var givenCallbackData = "something you want back";
        var givenTo = "john.doe@example.com";

        var givenResponse = $@"
            {{
              ""results"": [
                {{
                  ""bulkId"": ""{givenBulkId}"",
                  ""price"": {{
                    ""pricePerMessage"": {givenPricePerMessage},
                    ""currency"": ""{givenCurrency}""
                  }},
                  ""status"": {{
                    ""id"": {givenStatusId},
                    ""groupId"": {givenStatusGroupId},
                    ""groupName"": ""{givenStatusGroupName}"",
                    ""name"": ""{givenStatusName}"",
                    ""description"": ""{givenStatusDescription}""
                  }},
                  ""error"": {{
                    ""id"": {givenErrorId},
                    ""name"": ""{givenErrorName}"",
                    ""description"": ""{givenErrorDescription}"",
                    ""groupId"": {givenErrorGroupId},
                    ""groupName"": ""{givenErrorGroupName}"",
                    ""permanent"": {givenErrorPermanent.ToString().ToLower()}
                  }},
                  ""messageId"": ""{givenMessageId}"",
                  ""doneAt"": ""{givenDoneAt}"",
                  ""smsCount"": {givenSmsCount},
                  ""sentAt"": ""{givenSentAt}"",
                  ""browserLink"": ""{givenBrowserLink}"",
                  ""sendingIp"": ""{givenSendingIp}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""to"": ""{givenTo}""
                }}
              ]
            }}";

        var emailWebhookDLRReportResponse = JsonConvert.DeserializeObject<EmailWebhookDLRReportResponse>(givenResponse);
        AssertEmailWebhookDLRReportResponse(emailWebhookDLRReportResponse!);

        var emailWebhookDLRReportResponseSystemTextJson =
            JsonSerializer.Deserialize<EmailWebhookDLRReportResponse>(givenResponse);
        AssertEmailWebhookDLRReportResponse(emailWebhookDLRReportResponseSystemTextJson!);

        void AssertEmailWebhookDLRReportResponse(EmailWebhookDLRReportResponse emailWebhookDLRReportResponse)
        {
            Assert.IsNotNull(emailWebhookDLRReportResponse);
            Assert.IsNotNull(emailWebhookDLRReportResponse.Results);
            Assert.AreEqual(1, emailWebhookDLRReportResponse.Results.Count);

            var emailWebhookDeliveryReport = emailWebhookDLRReportResponse.Results[0];
            Assert.AreEqual(givenBulkId, emailWebhookDeliveryReport.BulkId);

            Assert.AreEqual(givenPricePerMessage, emailWebhookDeliveryReport.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, emailWebhookDeliveryReport.Price.Currency);

            Assert.AreEqual(givenStatusGroupId, emailWebhookDeliveryReport.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, emailWebhookDeliveryReport.Status.GroupName);
            Assert.AreEqual(givenStatusId, emailWebhookDeliveryReport.Status.Id);
            Assert.AreEqual(givenStatusName, emailWebhookDeliveryReport.Status.Name);
            Assert.AreEqual(givenStatusDescription, emailWebhookDeliveryReport.Status.Description);

            Assert.AreEqual(givenErrorGroupId, emailWebhookDeliveryReport.Error.GroupId);
            Assert.AreEqual(givenErrorGroupName, emailWebhookDeliveryReport.Error.GroupName);
            Assert.AreEqual(givenErrorId, emailWebhookDeliveryReport.Error.Id);
            Assert.AreEqual(givenErrorName, emailWebhookDeliveryReport.Error.Name);
            Assert.AreEqual(givenErrorDescription, emailWebhookDeliveryReport.Error.Description);

            Assert.AreEqual(givenMessageId, emailWebhookDeliveryReport.MessageId);
            Assert.AreEqual(DateTimeOffset.Parse(givenDoneAt), emailWebhookDeliveryReport.DoneAt);
            Assert.AreEqual(givenSmsCount, emailWebhookDeliveryReport.SmsCount);
            Assert.AreEqual(DateTimeOffset.Parse(givenSentAt), emailWebhookDeliveryReport.SentAt);
            Assert.AreEqual(givenBrowserLink, emailWebhookDeliveryReport.BrowserLink);
            Assert.AreEqual(givenSendingIp, emailWebhookDeliveryReport.SendingIp);
            Assert.AreEqual(givenCallbackData, emailWebhookDeliveryReport.CallbackData);
            Assert.AreEqual(givenTo, emailWebhookDeliveryReport.To);
        }
    }

    [TestMethod]
    public void ShouldReceiveUserEvents()
    {
        var givenNotificationType = "OPENED";
        var givenDomain = "some-domain.com";
        var givenRecipient = "john.doe@example.com";
        var givenSendDateTime = 1704106800000;
        var givenMessageId = "14b734recsf69n8zkao5";
        var givenBulkId = "ikzzmbhu6223bxkhmyrj";
        var givenCallbackData = "Callback data";
        var givenDeviceType = "Phone";
        var givenOs = "iOS 12";
        var givenDeviceName = "Apple";
        var givenCity = "Los Angeles";
        var givenCountryName = "United States";

        var givenResponse = $@"
            {{
              ""notificationType"": ""{givenNotificationType}"",
              ""domain"": ""{givenDomain}"",
              ""recipient"": ""{givenRecipient}"",
              ""sendDateTime"": {givenSendDateTime},
              ""messageId"": ""{givenMessageId}"",
              ""bulkId"": ""{givenBulkId}"",
              ""callbackData"": ""{givenCallbackData}"",
              ""recipientInfo"": {{
                ""deviceType"": ""{givenDeviceType}"",
                ""os"": ""{givenOs}"",
                ""deviceName"": ""{givenDeviceName}""
              }},
              ""geoLocation"": {{
                ""city"": ""{givenCity}"",
                ""countryName"": ""{givenCountryName}""
              }}
            }}";

        var emailWebhookTrackResponse = JsonConvert.DeserializeObject<EmailWebhookTrackResponse>(givenResponse);
        AssertEmailWebhookTrackResponse(emailWebhookTrackResponse!);

        var emailWebhookTrackResponseSystemTextJson =
            JsonSerializer.Deserialize<EmailWebhookTrackResponse>(givenResponse);
        AssertEmailWebhookTrackResponse(emailWebhookTrackResponseSystemTextJson!);

        void AssertEmailWebhookTrackResponse(EmailWebhookTrackResponse emailWebhookTrackResponse)
        {
            Assert.IsNotNull(emailWebhookTrackResponse);
            Assert.AreEqual(givenNotificationType, emailWebhookTrackResponse.NotificationType);
            Assert.AreEqual(givenDomain, emailWebhookTrackResponse.Domain);
            Assert.AreEqual(givenRecipient, emailWebhookTrackResponse.Recipient);
            Assert.AreEqual(givenSendDateTime, emailWebhookTrackResponse.SendDateTime);
            Assert.AreEqual(givenMessageId, emailWebhookTrackResponse.MessageId);
            Assert.AreEqual(givenBulkId, emailWebhookTrackResponse.BulkId);
            Assert.AreEqual(givenCallbackData, emailWebhookTrackResponse.CallbackData);
            Assert.AreEqual(givenDeviceType, emailWebhookTrackResponse.RecipientInfo.DeviceType);
            Assert.AreEqual(givenOs, emailWebhookTrackResponse.RecipientInfo.Os);
            Assert.AreEqual(givenDeviceName, emailWebhookTrackResponse.RecipientInfo.DeviceName);
            Assert.AreEqual(givenCity, emailWebhookTrackResponse.GeoLocation.City);
            Assert.AreEqual(givenCountryName, emailWebhookTrackResponse.GeoLocation.CountryName);
        }
    }

    [DataTestMethod]
    [DataRow(0)]
    [DataRow(1)]
    public void GetEmailDeliveryReportsResponseTest(int errorResponseIndex)
    {
        var expectedHttpCode = DeliveryReportErrorResponses[errorResponseIndex].Item1;
        var expectedMessageId = DeliveryReportErrorResponses[errorResponseIndex].Item2;
        var expectedErrorPhrase = DeliveryReportErrorResponses[errorResponseIndex].Item3;
        var expectedErrorText = DeliveryReportErrorResponses[errorResponseIndex].Item4;

        var givenMessageId = "MSG-TEST-123";
        var givenBulkId = "BULK-1234";
        var givenLimit = 2;

        var expectedJson = $@"
            {{
                ""requestError"": {{
                    ""serviceException"": {{
                        ""messageId"": ""{expectedMessageId}"",
                        ""text"": ""{expectedErrorPhrase}"",
                        ""validationErrors"": ""{expectedErrorText}""
                    }}
                }}
            }}";

        var responseHeaders = new Dictionary<string, string>
        {
            { "Server", SERVER_HEADER_VALUE_COMMA },
            { "X-Request-ID", X_REQUEST_ID_HEADER_VALUE },
            { "Content-Type", CONTENT_TYPE_HEADER_VALUE }
        };

        SetUpGetRequest(EMAIL_LOGS_ENDPOINT, expectedHttpCode, expectedJson);

        var emailApi = new EmailApi(configuration);

        try
        {
            var result =
                emailApi.GetEmailDeliveryReports(messageId: givenMessageId, bulkId: givenBulkId, limit: givenLimit);
        }
        catch (ApiException ex)
        {
            Assert.AreEqual(expectedHttpCode, ex.ErrorCode);
            Assert.AreEqual(expectedJson, ex.ErrorContent);
            Assert.IsInstanceOfType(ex, typeof(ApiException));
            Assert.IsTrue(ex.Message.Contains(expectedErrorPhrase));
            Assert.IsTrue(ex.ErrorContent.ToString()?.Contains(expectedMessageId) == true);
            Assert.IsTrue(ex.ErrorContent.ToString()?.Contains(expectedErrorText) == true);
            Assert.IsTrue(responseHeaders.All(h =>
                ex.Headers.ContainsKey(h.Key) && ex.Headers[h.Key].First().Equals(h.Value)));
        }
    }
}