using System.Globalization;
using System.Net;
using System.Text;
using Infobip.Api.Client;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Client;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Infobip.Api.Client.Model.EmailAddDomainRequest;

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
    protected const string EMAIL_IPS = "/email/1/ips";
    protected const string EMAIL_DOMAIN_IPS = "/email/1/domain-ips";

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
        var expectedFrom = "Jane Doe <jane.doe@somecompany.com";
        var expectedTo = "john.smith@somedomain.com";
        var expectedTo2 = "Jane Doe <jane.doe@somecompany.com";
        var expectedCc = "alice.someone@somedomain.com";
        var expectedCc2 = "bob.someone@somedomain.com";
        var expectedBcc = "carol.someone@somedomain.com";
        var expectedBcc2 = "charlie.someone@somedomain.com";
        var expectedReplyTo = "all.replies@somedomain.com";
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
        var expectedFrom = "Jane Doe <jane.doe@somecompany.com";
        var expectedTo = "john.smith@somedomain.com";
        var expectedReplyTo = "all.replies@somedomain.com";
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
    public void ShouldGetEmailDeliveryReportsTest()
    {
        var expectedTo = "john.smith@somedomain.com";
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

        SetUpGetRequest(EMAIL_LOGS_ENDPOINT, expectedResponse, 200);

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
    public void ShouldGetEmailLogsTest()
    {
        var expectedFrom = "Jane Doe <jane.doe@somecompany.com";
        var expectedTo = "john.smith@somedomain.com";
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

        SetUpGetRequest(EMAIL_REPORTS_ENDPOINT, expectedResponse, 200);

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

        SetUpGetRequest(EMAIL_BULKS_ENDPOINT, expectedResponse, 200);

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

        SetUpPutRequest(EMAIL_BULKS_ENDPOINT, givenRequest, expectedResponse, 200);

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

        SetUpGetRequest(EMAIL_BULKS_STATUS_ENDPOINT, expectedResponse, 200);

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

        SetUpPutRequest(EMAIL_BULKS_STATUS_ENDPOINT, givenRequest, expectedResponse, 200);

        var scheduledEmailApi = new EmailApi(configuration);

        var updateStatusRequest = new EmailBulkUpdateStatusRequest(expectedStatus);

        var response = scheduledEmailApi.UpdateScheduledEmailStatuses(expectedBulkId, updateStatusRequest);

        Assert.AreEqual(expectedBulkId, response.BulkId);
        Assert.AreEqual(expectedStatus, response.Status);
    }

    [TestMethod]
    public void ValidateEmailAddressesTest()
    {
        var expectedTo = "john.smith@somedomain.com";
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

        SetUpPostRequest(EMAIL_VALIDATE_ADDRESSES_ENDPOINT, givenRequest, expectedResponse, 200);

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

        SetUpGetRequest(EMAIL_DOMAINS, expectedQueryParameters, expectedResponse, 200);

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
            AssertEmailAllDomainsResponse);
        AssertResponseWithHttpInfo(emailApi.GetAllDomainsWithHttpInfoAsync(expectedSize, expectedPage).Result,
            AssertEmailAllDomainsResponse);
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

        SetUpPostRequest(EMAIL_DOMAINS, givenRequest, expectedResponse, 200);

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

        AssertResponseWithHttpInfo(emailApi.AddDomainWithHttpInfo(emailAddDomainRequest), AssertEmailDomainResponse);
        AssertResponseWithHttpInfo(emailApi.AddDomainWithHttpInfoAsync(emailAddDomainRequest).Result,
            AssertEmailDomainResponse);
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

        SetUpGetRequest(EMAIL_DOMAIN.Replace("{domainName}", expectedDomainName), expectedResponse, 200);

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
            AssertEmailDomainResponse);
        AssertResponseWithHttpInfo(emailApi.GetDomainDetailsWithHttpInfoAsync(expectedDomainName).Result,
            AssertEmailDomainResponse);
    }

    [TestMethod]
    public void ShouldDeleteExistingDomain()
    {
        var givenDomainName = "domainName";

        SetUpDeleteRequest(EMAIL_DOMAIN.Replace("{domainName}", givenDomainName), 204);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(emailApi.DeleteDomainWithHttpInfo(givenDomainName), HttpStatusCode.NoContent);
        AssertNoBodyResponseWithHttpInfo(emailApi.DeleteDomainWithHttpInfoAsync(givenDomainName).Result,
            HttpStatusCode.NoContent);
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

        SetUpPutRequest(EMAIL_DOMAIN_TRACKING.Replace("{domainName}", expectedDomainName), givenRequest,
            expectedResponse, 200);

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
            AssertEmailDomainResponse);
        AssertResponseWithHttpInfo(
            emailApi.UpdateTrackingEventsWithHttpInfoAsync(expectedDomainName, emailTrackingEventRequest).Result,
            AssertEmailDomainResponse);
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

        SetUpPutRequest(EMAIL_DOMAIN_RETURN_PATH.Replace("{domainName}", expectedDomainName), givenRequest,
            expectedResponse, 200);

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
            AssertEmailDomainResponse);
        AssertResponseWithHttpInfo(
            emailApi.UpdateReturnPathWithHttpInfoAsync(expectedDomainName, emailReturnPathAddressRequest).Result,
            AssertEmailDomainResponse);
    }

    [TestMethod]
    public void ShouldVerifyDomain()
    {
        var givenDomainName = "domainName";

        SetUpNoRequestBodyNoResponseBodyPostRequest(EMAIL_DOMAIN_VERIFY.Replace("{domainName}", givenDomainName), 202);

        var emailApi = new EmailApi(configuration);

        AssertNoBodyResponseWithHttpInfo(emailApi.VerifyDomainWithHttpInfo(givenDomainName), HttpStatusCode.Accepted);
        AssertNoBodyResponseWithHttpInfo(emailApi.VerifyDomainWithHttpInfoAsync(givenDomainName).Result,
            HttpStatusCode.Accepted);
    }

    [TestMethod]
    public void ShouldListAllDedicatedIpsForProvidedAccountId()
    {
        var expectedIpAddress = "11.11.11.1";
        var expectedDedicated = true;
        var expectedAssignedDomainCount = 1;
        var expectedStatus = "ASSIGNABLE";

        var expectedResponse = $@"
            {{
                ""result"": [
                    {{
                        ""ipAddress"": ""{expectedIpAddress}"",
                        ""dedicated"": {expectedDedicated.ToString().ToLower()},
                        ""assignedDomainCount"": {expectedAssignedDomainCount},
                        ""status"": ""{expectedStatus}""
                    }}
                ]
            }}";

        SetUpGetRequest(EMAIL_IPS, expectedResponse, 200);

        var emailApi = new EmailApi(configuration);

        void AssertEmailDomainIpResponse(EmailDomainIpResponse emailDomainIpResponse)
        {
            Assert.IsNotNull(emailDomainIpResponse);
            Assert.IsNotNull(emailDomainIpResponse.Result[0]);
            Assert.AreEqual(expectedIpAddress, emailDomainIpResponse.Result[0].IpAddress);
            Assert.AreEqual(expectedDedicated, emailDomainIpResponse.Result[0].Dedicated);
            Assert.AreEqual(expectedAssignedDomainCount, emailDomainIpResponse.Result[0].AssignedDomainCount);
            Assert.AreEqual(expectedStatus, emailDomainIpResponse.Result[0].Status);
        }

        AssertResponse(emailApi.GetAllIps(), AssertEmailDomainIpResponse);
        AssertResponse(emailApi.GetAllIpsAsync().Result, AssertEmailDomainIpResponse);

        AssertResponseWithHttpInfo(emailApi.GetAllIpsWithHttpInfo(), AssertEmailDomainIpResponse);
        AssertResponseWithHttpInfo(emailApi.GetAllIpsWithHttpInfoAsync().Result, AssertEmailDomainIpResponse);
    }

    [TestMethod]
    public void ShouldListAllDedicatedIpsForDomainAndForProvidedAccountId()
    {
        var expectedIpAddress = "11.11.11.1";
        var expectedDedicated = true;
        var expectedAssignedDomainCount = 1;
        var expectedStatus = "ASSIGNABLE";

        var expectedDomainName = "domainName";

        var expectedResponse = $@"
            {{
                ""result"": [
                    {{
                        ""ipAddress"": ""{expectedIpAddress}"",
                        ""dedicated"": {expectedDedicated.ToString().ToLower()},
                        ""assignedDomainCount"": {expectedAssignedDomainCount},
                        ""status"": ""{expectedStatus}""
                    }}
                ]
            }}";

        var queryParameters = new Dictionary<string, string>
        {
            { "domainName", expectedDomainName }
        };

        SetUpGetRequest(EMAIL_DOMAIN_IPS, queryParameters, expectedResponse, 200);

        var emailApi = new EmailApi(configuration);

        void AssertEmailDomainIpResponse(EmailDomainIpResponse emailDomainIpResponse)
        {
            Assert.IsNotNull(emailDomainIpResponse);
            Assert.IsNotNull(emailDomainIpResponse.Result[0]);
            Assert.AreEqual(expectedIpAddress, emailDomainIpResponse.Result[0].IpAddress);
            Assert.AreEqual(expectedDedicated, emailDomainIpResponse.Result[0].Dedicated);
            Assert.AreEqual(expectedAssignedDomainCount, emailDomainIpResponse.Result[0].AssignedDomainCount);
            Assert.AreEqual(expectedStatus, emailDomainIpResponse.Result[0].Status);
        }

        AssertResponse(emailApi.GetAllDomainIps(expectedDomainName), AssertEmailDomainIpResponse);
        AssertResponse(emailApi.GetAllDomainIpsAsync(expectedDomainName).Result, AssertEmailDomainIpResponse);

        AssertResponseWithHttpInfo(emailApi.GetAllDomainIpsWithHttpInfo(expectedDomainName),
            AssertEmailDomainIpResponse);
        AssertResponseWithHttpInfo(emailApi.GetAllDomainIpsWithHttpInfoAsync(expectedDomainName).Result,
            AssertEmailDomainIpResponse);
    }

    [TestMethod]
    public void ShouldAssignDedicatedIpAddressToProvidedDomainForTheAccountId()
    {
        var givenDomainName = "domain.com";
        var givenIpAddress = "11.11.11.11";

        var expectedResult = "OK";

        var givenRequest = $@"
            {{
                ""domainName"": ""{givenDomainName}"",
                ""ipAddress"": ""{givenIpAddress}""
            }}";

        var expectedResponse = $@"
            {{
                ""result"": ""{expectedResult}""
            }}";

        SetUpPostRequest(EMAIL_DOMAIN_IPS, givenRequest, expectedResponse, 200);

        var emailApi = new EmailApi(configuration);

        var emailDomainIpRequest = new EmailDomainIpRequest(
            givenDomainName,
            givenIpAddress
        );

        void AssertEmailSimpleApiResponse(EmailSimpleApiResponse emailSimpleApiResponse)
        {
            Assert.IsNotNull(emailSimpleApiResponse);
            Assert.AreEqual(expectedResult, emailSimpleApiResponse.Result);
        }

        AssertResponse(emailApi.AssignIpToDomain(emailDomainIpRequest), AssertEmailSimpleApiResponse);
        AssertResponse(emailApi.AssignIpToDomainAsync(emailDomainIpRequest).Result, AssertEmailSimpleApiResponse);

        AssertResponseWithHttpInfo(emailApi.AssignIpToDomainWithHttpInfo(emailDomainIpRequest),
            AssertEmailSimpleApiResponse);
        AssertResponseWithHttpInfo(emailApi.AssignIpToDomainWithHttpInfoAsync(emailDomainIpRequest).Result,
            AssertEmailSimpleApiResponse);
    }

    [TestMethod]
    public void ShouldRemoveDedicatedIpAddressFromTheProvidedDomain()
    {
        var givenDomainName = "domain.com";
        var givenIpAddress = "11.11.11.11";

        var expectedResult = "OK";

        var expectedResponse = $@"
            {{
                ""result"": ""{expectedResult}""
            }}";

        var givenQueryParameters = new Dictionary<string, string>
        {
            { "domainName", givenDomainName },
            { "ipAddress", givenIpAddress }
        };

        SetUpDeleteRequestWithResponseBody(EMAIL_DOMAIN_IPS, givenQueryParameters, expectedResponse, 200);

        var emailApi = new EmailApi(configuration);

        void AssertEmailSimpleApiResponse(EmailSimpleApiResponse emailSimpleApiResponse)
        {
            Assert.IsNotNull(emailSimpleApiResponse);
            Assert.AreEqual(expectedResult, emailSimpleApiResponse.Result);
        }

        AssertResponse(emailApi.RemoveIpFromDomain(givenDomainName, givenIpAddress), AssertEmailSimpleApiResponse);
        AssertResponse(emailApi.RemoveIpFromDomainAsync(givenDomainName, givenIpAddress).Result,
            AssertEmailSimpleApiResponse);

        AssertResponseWithHttpInfo(emailApi.RemoveIpFromDomainWithHttpInfo(givenDomainName, givenIpAddress),
            AssertEmailSimpleApiResponse);
        AssertResponseWithHttpInfo(emailApi.RemoveIpFromDomainWithHttpInfoAsync(givenDomainName, givenIpAddress).Result,
            AssertEmailSimpleApiResponse);
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

        var givenTo = "john.smith@somedomain.com";
        var givenMessageCount = 1;
        var givenMessageId = "somexternalMessageId";
        var givenGroupId = 1;
        var givenGroupName = "PENDING";
        var givenId = 7;
        var givenName = "PENDING_ENROUTE";
        var givenDescription = "Message sent to next instance";
        var givenFrom = "jane.smith@somecompany.com";
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

        SetUpGetRequest(EMAIL_LOGS_ENDPOINT, expectedJson, expectedHttpCode);

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