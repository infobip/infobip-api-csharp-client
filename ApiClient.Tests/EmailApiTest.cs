using Infobip.Api.Client;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using static Infobip.Api.Client.Model.EmailAddDomainRequest;

namespace ApiClient.Tests
{
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
            Tuple.Create(500, "GENERAL_ERROR", "Internal Server Error", "Something went wrong. Please contact support."),
        };

        internal static readonly Tuple<int, string, string, string>[] DeliveryReportErrorResponses =
        {
            Tuple.Create(400, "BAD_REQUEST", "Bad Request", "request.message.content.media.file.url: [is not a valid url]"),
            Tuple.Create(500, "BAD_REQUEST", "Internal Server Error", "request.message.content.media.file.url: [is not a valid url]"),
        };

        [TestMethod]
        public void ShouldSendEmailTest()
        {
            string expectedFrom = "Jane Doe <jane.doe@somecompany.com";
            string expectedTo = "john.smith@somedomain.com";
            string expectedTo2 = "Jane Doe <jane.doe@somecompany.com";
            string expectedCc = "alice.someone@somedomain.com";
            string expectedCc2 = "bob.someone@somedomain.com";
            string expectedBcc = "carol.someone@somedomain.com";
            string expectedBcc2 = "charlie.someone@somedomain.com";
            string expectedReplyTo = "all.replies@somedomain.com";
            string expectedSubject = "Mail subject text";
            string expectedStatusDescription = "Message sent to next instance";
            int expectedMessageCount = 2;
            int expectedStatusId = 1;
            int expectedStatusGroupId = 1;
            string expectedMessageId = "MSG-1234";
            string expectedMessageId2 = "e7zzb1v9yirml2se9zo4";
            string expectedBulkId = "BULK-1234";
            string expectedStatusName = "PENDING";
            string expectedText = "Rich HTML message body.";
            string expectedHtml = "<h1>Html body</h1><p>Rich HTML message body.</p>";


            string expectedResponse = $@"
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

            Multimap<string, string> parts = new Multimap<string, string>
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

            Assert.AreEqual(response.Messages.Count, expectedMessageCount);
            Assert.AreEqual(response.Messages[0].MessageId, expectedMessageId);
            Assert.AreEqual(response.Messages[0].To, expectedTo);
            Assert.AreEqual(response.Messages[0].Status.Id, expectedStatusId);
            Assert.AreEqual(response.Messages[0].Status.Name, expectedStatusName);
            Assert.AreEqual(response.Messages[0].Status.GroupId, expectedStatusGroupId);
            Assert.AreEqual(response.Messages[0].Status.Description, expectedStatusDescription);
            Assert.AreEqual(response.Messages[0].Status.GroupId, expectedStatusGroupId);
            Assert.AreEqual(response.Messages[1].MessageId, expectedMessageId2);
            Assert.AreEqual(response.Messages[1].To, expectedTo2);
            Assert.AreEqual(response.Messages[1].Status.Id, expectedStatusId);
            Assert.AreEqual(response.Messages[1].Status.Name, expectedStatusName);
            Assert.AreEqual(response.Messages[1].Status.GroupId, expectedStatusGroupId);
            Assert.AreEqual(response.Messages[1].Status.Description, expectedStatusDescription);
            Assert.AreEqual(response.Messages[1].Status.GroupId, expectedStatusGroupId);
        }

        [TestMethod]
        public void ShouldSendEmailWithAttachmentTest()
        {
            string expectedFrom = "Jane Doe <jane.doe@somecompany.com";
            string expectedTo = "john.smith@somedomain.com";
            string expectedReplyTo = "all.replies@somedomain.com";
            string expectedSubject = "Mail subject text";
            string expectedStatusDescription = "Message sent to next instance";
            int expectedMessageCount = 1;
            int expectedStatusId = 1;
            int expectedStatusGroupId = 1;
            string expectedMessageId = "MSG-1234";
            string expectedBulkId = "BULK-1234";
            string expectedStatusName = "PENDING";
            string expectedText = "Rich HTML message body.";
            string expectedHtml = "<h1>Html body</h1><p>Rich HTML message body.</p>";
            string expectedAttachmentText = "This is a test file";
            string expectedAttachmentText2 = "This is another test file";

            string expectedResponse = $@"
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
            var attachmentStream = new Infobip.Api.Client.Client.FileParameter(memoryStream);

            var memoryStream2 = new MemoryStream(Encoding.UTF8.GetBytes(expectedAttachmentText2));
            var attachmentStream2 = new Infobip.Api.Client.Client.FileParameter(memoryStream2);

            Multimap<string, string> parts = new Multimap<string, string>
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

            var attachmentList = new List<Infobip.Api.Client.Client.FileParameter>
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

            Assert.AreEqual(response.Messages.Count, expectedMessageCount);
            Assert.AreEqual(response.Messages[0].MessageId, expectedMessageId);
            Assert.AreEqual(response.Messages[0].To, expectedTo);
            Assert.AreEqual(response.Messages[0].Status.Id, expectedStatusId);
            Assert.AreEqual(response.Messages[0].Status.Name, expectedStatusName);
            Assert.AreEqual(response.Messages[0].Status.GroupId, expectedStatusGroupId);
            Assert.AreEqual(response.Messages[0].Status.Description, expectedStatusDescription);
            Assert.AreEqual(response.Messages[0].Status.GroupId, expectedStatusGroupId);
        }

        [TestMethod]
        public void ShouldGetEmailDeliveryReportsTest()
        {
            string expectedTo = "john.smith@somedomain.com";
            int expectedMessageCount = 1;
            string expectedMessageId = "MSG-1234";
            string expectedBulkId = "BULK-1234";
            DateTimeOffset expectedSentAt = new DateTimeOffset(2021, 9, 2, 9, 57, 56, TimeSpan.FromHours(0));
            DateTimeOffset expectedDoneAt = new DateTimeOffset(2021, 9, 2, 9, 58, 33, TimeSpan.FromHours(0));
            string expectedCurrency = "EUR";
            decimal expectedPricePerMessage = 0.0M;
            string expectedStatusName = "DELIVERED_TO_HANDSET";
            int expectedStatusId = 5;
            string expectedStatusDescription = "Message delivered to handset";
            int expectedStatusGroupId = 3;
            string expectedStatusGroupName = "DELIVERED";
            string expectedErrorName = "NO_ERROR";
            int expectedErrorId = 5;
            string expectedErrorDescription = "No Error";
            int expectedErrorGroupId = 0;
            string expectedErrorGroupName = "OK";
            bool expectedErrorPermanent = false;
            string expectedChannel = "EMAIL";

            string expectedResponse = $@"
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

            EmailReportsResult response = sendEmailApi.GetEmailDeliveryReports(bulkId: expectedBulkId, messageId: expectedMessageId, limit: 2);

            Assert.AreEqual(response.Results.Count, 1);
            Assert.AreEqual(response.Results[0].BulkId, expectedBulkId);
            Assert.AreEqual(response.Results[0].MessageId, expectedMessageId);

            Assert.AreEqual(response.Results[0].SentAt, expectedSentAt);
            Assert.AreEqual(response.Results[0].DoneAt, expectedDoneAt);
            Assert.AreEqual(response.Results[0].MessageCount, expectedMessageCount);

            Assert.AreEqual(response.Results[0].Status.Description, expectedStatusDescription);
            Assert.AreEqual(response.Results[0].Status.GroupId, expectedStatusGroupId);
            Assert.AreEqual(response.Results[0].Status.GroupName, expectedStatusGroupName);
            Assert.AreEqual(response.Results[0].Status.Id, expectedStatusId);
            Assert.AreEqual(response.Results[0].Status.Name, expectedStatusName);

            Assert.AreEqual(response.Results[0].Price.PricePerMessage, expectedPricePerMessage);

            Assert.AreEqual(response.Results[0].Error.Description, expectedErrorDescription);
            Assert.AreEqual(response.Results[0].Error.GroupId, expectedErrorGroupId);
            Assert.AreEqual(response.Results[0].Error.GroupName, expectedErrorGroupName);
            Assert.AreEqual(response.Results[0].Error.Id, expectedErrorId);
            Assert.AreEqual(response.Results[0].Error.Name, expectedErrorName);
            Assert.AreEqual(response.Results[0].Error.Permanent, expectedErrorPermanent);
        }

        [TestMethod]
        public void ShouldGetEmailLogsTest()
        {
            string expectedFrom = "Jane Doe <jane.doe@somecompany.com";
            string expectedTo = "john.smith@somedomain.com";
            string expectedText = "Mail body text";
            int expectedMessageCount = 1;
            string expectedMessageId = "MSG-1234";
            string expectedBulkId = "BULK-1234";
            DateTimeOffset expectedSentAt = new DateTimeOffset(2021, 9, 2, 9, 57, 56, TimeSpan.FromHours(0));
            DateTimeOffset expectedDoneAt = new DateTimeOffset(2021, 9, 2, 9, 57, 56, TimeSpan.FromHours(0));
            string expectedCurrency = "EUR";
            decimal expectedPricePerMessage = 0.0m;
            string expectedStatusName = "DELIVERED_TO_HANDSET";
            int expectedStatusId = 5;
            string expectedStatusDescription = "Message delivered to handset";
            int expectedStatusGroupId = 3;
            string expectedStatusGroupName = "DELIVERED";
            string expectedChannel = "EMAIL";

            string expectedResponse = $@"
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

            EmailLogsResponse response = sendEmailApi.GetEmailLogs(
                bulkId: expectedBulkId,
                messageId: expectedMessageId,
                limit: 2
            );

            Assert.AreEqual(response.Results.Count, 1);

            Assert.AreEqual(response.Results[0].From, expectedFrom);
            Assert.AreEqual(response.Results[0].BulkId, expectedBulkId);
            Assert.AreEqual(response.Results[0].MessageId, expectedMessageId);
            Assert.AreEqual(response.Results[0].SentAt, expectedSentAt);
            Assert.AreEqual(response.Results[0].DoneAt, expectedDoneAt);
            Assert.AreEqual(response.Results[0].Text, expectedText);
            Assert.AreEqual(response.Results[0].To, expectedTo);
            Assert.AreEqual(response.Results[0].MessageCount, expectedMessageCount);

            Assert.AreEqual(response.Results[0].Status.Description, expectedStatusDescription);
            Assert.AreEqual(response.Results[0].Status.GroupId, expectedStatusGroupId);
            Assert.AreEqual(response.Results[0].Status.GroupName, expectedStatusGroupName);
            Assert.AreEqual(response.Results[0].Status.Id, expectedStatusId);
            Assert.AreEqual(response.Results[0].Status.Name, expectedStatusName);

            Assert.AreEqual(response.Results[0].Price.PricePerMessage, expectedPricePerMessage);
        }

        [TestMethod]
        public void ShouldGetScheduledEmailsTest()
        {
            string expectedExternalBulkId = "BULK-1234";
            string expectedBulkId = "1234593932111";
            DateTimeOffset expectedSentAt = new DateTimeOffset(2021, 9, 2, 9, 56, 53, TimeSpan.FromHours(0));

            string expectedResponse = $@"
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

            EmailBulkScheduleResponse response = scheduledEmailApi.GetScheduledEmails(expectedBulkId);

            Assert.AreEqual(response.Bulks.Count, 1);
            Assert.AreEqual(response.ExternalBulkId, expectedExternalBulkId);

            Assert.AreEqual(response.Bulks[0].BulkId, expectedBulkId);
            Assert.AreEqual(response.Bulks[0].SendAt, expectedSentAt);
        }

        [TestMethod]
        public void ShouldRescheduleEmailsTest()
        {
            string expectedBulkId = "1234593932111";
            DateTimeOffset expectedSentAt = new DateTimeOffset(2023, 5, 16, 11, 55, 51, TimeSpan.FromHours(0));

            string givenRequest = $@"
            {{
                ""sendAt"": ""{expectedSentAt.ToUniversalTime().ToString(DATE_FORMAT)}""
            }}";

            string expectedResponse = $@"
            {{
                ""bulkId"": ""{expectedBulkId}"",
                ""sendAt"": ""{expectedSentAt.ToUniversalTime().ToString(DATE_FORMAT)}""
            }}";

            SetUpPutRequest(EMAIL_BULKS_ENDPOINT, givenRequest, expectedResponse, 200);

            var scheduledEmailApi = new EmailApi(configuration);
            EmailBulkRescheduleRequest rescheduleRequest = new EmailBulkRescheduleRequest(expectedSentAt);

            EmailBulkRescheduleResponse response = scheduledEmailApi.RescheduleEmails(expectedBulkId, rescheduleRequest);

            Assert.AreEqual(response.BulkId, expectedBulkId);
            Assert.AreEqual(response.SendAt, expectedSentAt);
        }

        [TestMethod]
        public void ShouldGetScheduledEmailStatusTest()
        {
            string expectedExternalBulkId = "BULK-1234";
            string expectedBulkId = "1234593932111";
            string expectedBulkId2 = "1234594942111";

            EmailBulkStatus expectedStatus = EmailBulkStatus.Finished;
            EmailBulkStatus expectedStatus2 = EmailBulkStatus.Pending;

            string expectedResponse = $@"
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

            EmailBulkStatusResponse response = scheduledEmailApi.GetScheduledEmailStatuses(expectedBulkId);

            Assert.AreEqual(response.Bulks.Count, 2);
            Assert.AreEqual(response.ExternalBulkId, expectedExternalBulkId);
            Assert.AreEqual(response.Bulks[0].BulkId, expectedBulkId);
            Assert.AreEqual(response.Bulks[0].Status, expectedStatus);
            Assert.AreEqual(response.Bulks[1].BulkId, expectedBulkId2);
            Assert.AreEqual(response.Bulks[1].Status, expectedStatus2);
        }

        [TestMethod]
        public void ShouldUpdateEmailStatusTest()
        {
            string expectedBulkId = "1234593932111";
            EmailBulkStatus expectedStatus = EmailBulkStatus.Paused;

            string givenRequest = $@"
            {{
                ""status"": ""{expectedStatus}"",
            }}";

            string expectedResponse = $@"
            {{
                ""bulkId"": ""{expectedBulkId}"",
                ""status"": ""{expectedStatus}""
            }}";

            SetUpPutRequest(EMAIL_BULKS_STATUS_ENDPOINT, givenRequest, expectedResponse, 200);

            var scheduledEmailApi = new EmailApi(configuration);

            EmailBulkUpdateStatusRequest updateStatusRequest = new EmailBulkUpdateStatusRequest(expectedStatus);

            EmailBulkUpdateStatusResponse response = scheduledEmailApi.UpdateScheduledEmailStatuses(expectedBulkId, updateStatusRequest);

            Assert.AreEqual(response.BulkId, expectedBulkId);
            Assert.AreEqual(response.Status, expectedStatus);
        }

        [TestMethod]
        public void ValidateEmailAddressesTest()
        {
            string expectedTo = "john.smith@somedomain.com";
            string expectedValidMailbox = "true";
            bool expectedValidSyntax = true;
            bool expectedCatchAll = false;
            string expectedDidYouMean = "true";
            bool expectedDisposable = false;
            bool expectedRoleBased = true;

            string givenRequest = $@"
            {{
                ""to"": ""{expectedTo}"",
            }}";

            string expectedResponse = $@"
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

            EmailValidationRequest validationRequest = new EmailValidationRequest(expectedTo);

            EmailValidationResponse response = emailValidationApi.ValidateEmailAddresses(validationRequest);

            Assert.AreEqual(response.To, expectedTo);
            Assert.AreEqual(response.CatchAll, expectedCatchAll);
            Assert.AreEqual(response.DidYouMean, expectedDidYouMean);
            Assert.AreEqual(response.Disposable, expectedDisposable);
            Assert.AreEqual(response.RoleBased, expectedRoleBased);
            Assert.AreEqual(response.ValidMailbox, expectedValidMailbox);
            Assert.AreEqual(response.ValidSyntax, expectedValidSyntax);
        }

        [TestMethod]
        public void ShouldGetAllDomainsForTheAccount()
        {
            int expectedPage = 0;
            int expectedSize = 0;
            int expectedTotalPages = 0;
            int expectedTotalResults = 0;
            int expectedDomainId = 1;
            string expectedDomainName = "example.com";
            bool expectedActive = false;
            bool expectedClicks = true;
            bool expectedOpens = true;
            bool expectedUnsubscribe = true;
            string expectedRecordType = "string";
            string expectedName = "string";
            string expectedExpectedValue = "string";
            bool expectedVerified = true;
            bool expectedBlocked = false;
            DateTimeOffset expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string expectedReturnPathAddress = "returnpath@example.com";

            string expectedResponse = $@"
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

            var expectedQueryParameters = new Dictionary<string, string> {
                { "size", expectedSize.ToString() },
                { "page", expectedPage.ToString() }
             };

            SetUpGetRequest(EMAIL_DOMAINS, expectedQueryParameters, expectedResponse, 200);

            var emailApi = new EmailApi(configuration);

            void AssertEmailAllDomainsResponse(EmailAllDomainsResponse emailAllDomainsResponse)
            {
                Assert.IsNotNull(emailAllDomainsResponse.Paging);
                Assert.AreEqual(emailAllDomainsResponse.Paging.Page, expectedPage);
                Assert.AreEqual(emailAllDomainsResponse.Paging.Size, expectedSize);
                Assert.AreEqual(emailAllDomainsResponse.Paging.TotalPages, expectedTotalPages);
                Assert.AreEqual(emailAllDomainsResponse.Paging.TotalResults, expectedTotalResults);

                Assert.IsNotNull(emailAllDomainsResponse.Results);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DomainId, expectedDomainId);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DomainName, expectedDomainName);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Active, expectedActive);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Tracking.Clicks, expectedClicks);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Tracking.Opens, expectedOpens);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Tracking.Unsubscribe, expectedUnsubscribe);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DnsRecords[0].RecordType, expectedRecordType);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DnsRecords[0].Name, expectedName);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DnsRecords[0].ExpectedValue, expectedExpectedValue);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DnsRecords[0].Verified, expectedVerified);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Blocked, expectedBlocked);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].CreatedAt, expectedCreatedAt);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].ReturnPathAddress, expectedReturnPathAddress);
            }

            AssertResponse(emailApi.GetAllDomains(expectedSize, expectedPage), AssertEmailAllDomainsResponse);
            AssertResponse(emailApi.GetAllDomainsAsync(expectedSize, expectedPage).Result, AssertEmailAllDomainsResponse);

            AssertResponseWithHttpInfo(emailApi.GetAllDomainsWithHttpInfo(expectedSize, expectedPage), AssertEmailAllDomainsResponse);
            AssertResponseWithHttpInfo(emailApi.GetAllDomainsWithHttpInfoAsync(expectedSize, expectedPage).Result, AssertEmailAllDomainsResponse);
        }

        [TestMethod]
        public void ShouldAddNewDomain()
        {
            int givenDkimKeyLength = 1024;
            long givenTargetedDailyTraffic = 1000;
            string givenApplicationId = "string";
            string givenEntityId = "string";

            int expectedDomainId = 1;
            string expectedDomainName = "example.com";
            bool expectedActive = false;
            bool expectedClicks = true;
            bool expectedOpens = true;
            bool expectedUnsubscribe = true;
            string expectedRecordType = "string";
            string expectedName = "string";
            string expectedExpectedValue = "string";
            bool expectedVerified = true;
            bool expectedBlocked = false;
            DateTimeOffset expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string expectedReturnPathAddress = "returnpath@example.com";

            string givenRequest = $@"
            {{
                ""domainName"": ""{expectedDomainName}"",
                ""dkimKeyLength"": {givenDkimKeyLength},
                ""targetedDailyTraffic"": {givenTargetedDailyTraffic},
                ""applicationId"": ""{givenApplicationId}"",
                ""entityId"": ""{givenEntityId}"",
                ""returnPathAddress"": ""{expectedReturnPathAddress}""
            }}";

            string expectedResponse = $@"
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
                    domainName: expectedDomainName,
                    dkimKeyLength: DkimKeyLengthEnum.NUMBER1024,
                    targetedDailyTraffic: givenTargetedDailyTraffic,
                    applicationId: givenApplicationId,
                    entityId: givenEntityId,
                    returnPathAddress: expectedReturnPathAddress
                );

            void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
            {
                Assert.IsNotNull(emailDomainResponse);
                Assert.AreEqual(emailDomainResponse.DomainId, expectedDomainId);
                Assert.AreEqual(emailDomainResponse.DomainName, expectedDomainName);
                Assert.AreEqual(emailDomainResponse.Active, expectedActive);
                Assert.AreEqual(emailDomainResponse.Tracking.Clicks, expectedClicks);
                Assert.AreEqual(emailDomainResponse.Tracking.Opens, expectedOpens);
                Assert.AreEqual(emailDomainResponse.Tracking.Unsubscribe, expectedUnsubscribe);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].RecordType, expectedRecordType);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Name, expectedName);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].ExpectedValue, expectedExpectedValue);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Verified, expectedVerified);
                Assert.AreEqual(emailDomainResponse.Blocked, expectedBlocked);
                Assert.AreEqual(emailDomainResponse.CreatedAt, expectedCreatedAt);
                Assert.AreEqual(emailDomainResponse.ReturnPathAddress, expectedReturnPathAddress);
            }

            AssertResponse(emailApi.AddDomain(emailAddDomainRequest), AssertEmailDomainResponse);
            AssertResponse(emailApi.AddDomainAsync(emailAddDomainRequest).Result, AssertEmailDomainResponse);

            AssertResponseWithHttpInfo(emailApi.AddDomainWithHttpInfo(emailAddDomainRequest), AssertEmailDomainResponse);
            AssertResponseWithHttpInfo(emailApi.AddDomainWithHttpInfoAsync(emailAddDomainRequest).Result, AssertEmailDomainResponse);
        }

        [TestMethod]
        public void ShouldGetDomainDetails()
        {
            int expectedDomainId = 1;
            string expectedDomainName = "example.com";
            bool expectedActive = false;
            bool expectedClicks = true;
            bool expectedOpens = true;
            bool expectedUnsubscribe = true;
            string expectedRecordType = "string";
            string expectedName = "string";
            string expectedExpectedValue = "string";
            bool expectedVerified = true;
            bool expectedBlocked = false;
            DateTimeOffset expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string expectedReturnPathAddress = "returnpath@example.com";

            string expectedResponse = $@"
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
                Assert.AreEqual(emailDomainResponse.DomainId, expectedDomainId);
                Assert.AreEqual(emailDomainResponse.DomainName, expectedDomainName);
                Assert.AreEqual(emailDomainResponse.Active, expectedActive);
                Assert.AreEqual(emailDomainResponse.Tracking.Clicks, expectedClicks);
                Assert.AreEqual(emailDomainResponse.Tracking.Opens, expectedOpens);
                Assert.AreEqual(emailDomainResponse.Tracking.Unsubscribe, expectedUnsubscribe);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].RecordType, expectedRecordType);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Name, expectedName);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].ExpectedValue, expectedExpectedValue);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Verified, expectedVerified);
                Assert.AreEqual(emailDomainResponse.Blocked, expectedBlocked);
                Assert.AreEqual(emailDomainResponse.CreatedAt, expectedCreatedAt);
                Assert.AreEqual(emailDomainResponse.ReturnPathAddress, expectedReturnPathAddress);
            }

            AssertResponse(emailApi.GetDomainDetails(expectedDomainName), AssertEmailDomainResponse);
            AssertResponse(emailApi.GetDomainDetailsAsync(expectedDomainName).Result, AssertEmailDomainResponse);

            AssertResponseWithHttpInfo(emailApi.GetDomainDetailsWithHttpInfo(expectedDomainName), AssertEmailDomainResponse);
            AssertResponseWithHttpInfo(emailApi.GetDomainDetailsWithHttpInfoAsync(expectedDomainName).Result, AssertEmailDomainResponse);
        }

        [TestMethod]
        public void ShouldDeleteExistingDomain()
        {
            string givenDomainName = "domainName";

            SetUpDeleteRequest(EMAIL_DOMAIN.Replace("{domainName}", givenDomainName), 204);

            var emailApi = new EmailApi(configuration);

            AssertNoBodyResponseWithHttpInfo(emailApi.DeleteDomainWithHttpInfo(givenDomainName), HttpStatusCode.NoContent);
            AssertNoBodyResponseWithHttpInfo(emailApi.DeleteDomainWithHttpInfoAsync(givenDomainName).Result, HttpStatusCode.NoContent);
        }

        [TestMethod]
        public void ShouldUpdateTrackingEvents()
        {
            int expectedDomainId = 1;
            string expectedDomainName = "example.com";
            bool expectedActive = false;
            bool expectedClicks = true;
            bool expectedOpens = true;
            bool expectedUnsubscribe = true;
            string expectedRecordType = "string";
            string expectedName = "string";
            string expectedExpectedValue = "string";
            bool expectedVerified = true;
            bool expectedBlocked = false;
            DateTimeOffset expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string expectedReturnPathAddress = "returnpath@example.com";

            string givenRequest = $@"
            {{
                ""open"": {expectedOpens.ToString().ToLower()},
                ""clicks"": {expectedClicks.ToString().ToLower()},
                ""unsubscribe"": {expectedUnsubscribe.ToString().ToLower()}
            }}";

            string expectedResponse = $@"
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

            SetUpPutRequest(EMAIL_DOMAIN_TRACKING.Replace("{domainName}", expectedDomainName), givenRequest, expectedResponse, 200);

            var emailApi = new EmailApi(configuration);

            var emailTrackingEventRequest = new EmailTrackingEventRequest(
                    open: expectedOpens,
                    clicks: expectedClicks,
                    unsubscribe: expectedUnsubscribe
                );

            void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
            {
                Assert.IsNotNull(emailDomainResponse);
                Assert.AreEqual(emailDomainResponse.DomainId, expectedDomainId);
                Assert.AreEqual(emailDomainResponse.DomainName, expectedDomainName);
                Assert.AreEqual(emailDomainResponse.Active, expectedActive);
                Assert.AreEqual(emailDomainResponse.Tracking.Clicks, expectedClicks);
                Assert.AreEqual(emailDomainResponse.Tracking.Opens, expectedOpens);
                Assert.AreEqual(emailDomainResponse.Tracking.Unsubscribe, expectedUnsubscribe);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].RecordType, expectedRecordType);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Name, expectedName);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].ExpectedValue, expectedExpectedValue);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Verified, expectedVerified);
                Assert.AreEqual(emailDomainResponse.Blocked, expectedBlocked);
                Assert.AreEqual(emailDomainResponse.CreatedAt, expectedCreatedAt);
                Assert.AreEqual(emailDomainResponse.ReturnPathAddress, expectedReturnPathAddress);
            }

            AssertResponse(emailApi.UpdateTrackingEvents(expectedDomainName, emailTrackingEventRequest), AssertEmailDomainResponse);
            AssertResponse(emailApi.UpdateTrackingEventsAsync(expectedDomainName, emailTrackingEventRequest).Result, AssertEmailDomainResponse);

            AssertResponseWithHttpInfo(emailApi.UpdateTrackingEventsWithHttpInfo(expectedDomainName, emailTrackingEventRequest), AssertEmailDomainResponse);
            AssertResponseWithHttpInfo(emailApi.UpdateTrackingEventsWithHttpInfoAsync(expectedDomainName, emailTrackingEventRequest).Result, AssertEmailDomainResponse);
        }

        [TestMethod]
        public void ShouldUpdateReturnPath()
        {
            int expectedDomainId = 1;
            string expectedDomainName = "example.com";
            bool expectedActive = false;
            bool expectedClicks = true;
            bool expectedOpens = true;
            bool expectedUnsubscribe = true;
            string expectedRecordType = "string";
            string expectedName = "string";
            string expectedExpectedValue = "string";
            bool expectedVerified = true;
            bool expectedBlocked = false;
            DateTimeOffset expectedCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string expectedReturnPathAddress = "returnpath@example.com";

            string givenRequest = $@"
            {{
                ""returnPathAddress"": ""{expectedReturnPathAddress}"",
            }}";

            string expectedResponse = $@"
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

            SetUpPutRequest(EMAIL_DOMAIN_RETURN_PATH.Replace("{domainName}", expectedDomainName), givenRequest, expectedResponse, 200);

            var emailApi = new EmailApi(configuration);

            var emailReturnPathAddressRequest = new EmailReturnPathAddressRequest(
                    returnPathAddress: expectedReturnPathAddress
                );

            void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
            {
                Assert.IsNotNull(emailDomainResponse);
                Assert.AreEqual(emailDomainResponse.DomainId, expectedDomainId);
                Assert.AreEqual(emailDomainResponse.DomainName, expectedDomainName);
                Assert.AreEqual(emailDomainResponse.Active, expectedActive);
                Assert.AreEqual(emailDomainResponse.Tracking.Clicks, expectedClicks);
                Assert.AreEqual(emailDomainResponse.Tracking.Opens, expectedOpens);
                Assert.AreEqual(emailDomainResponse.Tracking.Unsubscribe, expectedUnsubscribe);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].RecordType, expectedRecordType);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Name, expectedName);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].ExpectedValue, expectedExpectedValue);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Verified, expectedVerified);
                Assert.AreEqual(emailDomainResponse.Blocked, expectedBlocked);
                Assert.AreEqual(emailDomainResponse.CreatedAt, expectedCreatedAt);
                Assert.AreEqual(emailDomainResponse.ReturnPathAddress, expectedReturnPathAddress);
            }

            AssertResponse(emailApi.UpdateReturnPath(expectedDomainName, emailReturnPathAddressRequest), AssertEmailDomainResponse);
            AssertResponse(emailApi.UpdateReturnPathAsync(expectedDomainName, emailReturnPathAddressRequest).Result, AssertEmailDomainResponse);

            AssertResponseWithHttpInfo(emailApi.UpdateReturnPathWithHttpInfo(expectedDomainName, emailReturnPathAddressRequest), AssertEmailDomainResponse);
            AssertResponseWithHttpInfo(emailApi.UpdateReturnPathWithHttpInfoAsync(expectedDomainName, emailReturnPathAddressRequest).Result, AssertEmailDomainResponse);
        }

        [TestMethod]
        public void ShouldVerifyDomain()
        {
            string givenDomainName = "domainName";

            SetUpNoRequestBodyNoResponseBodyPostRequest(EMAIL_DOMAIN_VERIFY.Replace("{domainName}", givenDomainName), 202);

            var emailApi = new EmailApi(configuration);

            AssertNoBodyResponseWithHttpInfo(emailApi.VerifyDomainWithHttpInfo(givenDomainName), HttpStatusCode.Accepted);
            AssertNoBodyResponseWithHttpInfo(emailApi.VerifyDomainWithHttpInfoAsync(givenDomainName).Result, HttpStatusCode.Accepted);
        }

        [TestMethod]
        public void ShouldListAllDedicatedIpsForProvidedAccountId()
        {
            string expectedIpAddress = "11.11.11.1";
            bool expectedDedicated = true;
            int expectedAssignedDomainCount = 1;
            string expectedStatus = "ASSIGNABLE";

            string expectedResponse = $@"
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
                Assert.AreEqual(emailDomainIpResponse.Result[0].IpAddress, expectedIpAddress);
                Assert.AreEqual(emailDomainIpResponse.Result[0].Dedicated, expectedDedicated);
                Assert.AreEqual(emailDomainIpResponse.Result[0].AssignedDomainCount, expectedAssignedDomainCount);
                Assert.AreEqual(emailDomainIpResponse.Result[0].Status, expectedStatus);
            }

            AssertResponse(emailApi.GetAllIps(), AssertEmailDomainIpResponse);
            AssertResponse(emailApi.GetAllIpsAsync().Result, AssertEmailDomainIpResponse);

            AssertResponseWithHttpInfo(emailApi.GetAllIpsWithHttpInfo(), AssertEmailDomainIpResponse);
            AssertResponseWithHttpInfo(emailApi.GetAllIpsWithHttpInfoAsync().Result, AssertEmailDomainIpResponse);
        }

        [TestMethod]
        public void ShouldListAllDedicatedIpsForDomainAndForProvidedAccountId()
        {
            string expectedIpAddress = "11.11.11.1";
            bool expectedDedicated = true;
            int expectedAssignedDomainCount = 1;
            string expectedStatus = "ASSIGNABLE";

            string expectedDomainName = "domainName";

            string expectedResponse = $@"
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

            var queryParameters = new Dictionary<string, string>()
            {
                { "domainName", expectedDomainName }
            };

            SetUpGetRequest(EMAIL_DOMAIN_IPS, queryParameters, expectedResponse, 200);

            var emailApi = new EmailApi(configuration);

            void AssertEmailDomainIpResponse(EmailDomainIpResponse emailDomainIpResponse)
            {
                Assert.IsNotNull(emailDomainIpResponse);
                Assert.IsNotNull(emailDomainIpResponse.Result[0]);
                Assert.AreEqual(emailDomainIpResponse.Result[0].IpAddress, expectedIpAddress);
                Assert.AreEqual(emailDomainIpResponse.Result[0].Dedicated, expectedDedicated);
                Assert.AreEqual(emailDomainIpResponse.Result[0].AssignedDomainCount, expectedAssignedDomainCount);
                Assert.AreEqual(emailDomainIpResponse.Result[0].Status, expectedStatus);
            }

            AssertResponse(emailApi.GetAllDomainIps(expectedDomainName), AssertEmailDomainIpResponse);
            AssertResponse(emailApi.GetAllDomainIpsAsync(expectedDomainName).Result, AssertEmailDomainIpResponse);

            AssertResponseWithHttpInfo(emailApi.GetAllDomainIpsWithHttpInfo(expectedDomainName), AssertEmailDomainIpResponse);
            AssertResponseWithHttpInfo(emailApi.GetAllDomainIpsWithHttpInfoAsync(expectedDomainName).Result, AssertEmailDomainIpResponse);
        }

        [TestMethod]
        public void ShouldAssignDedicatedIpAddressToProvidedDomainForTheAccountId()
        {
            string givenDomainName = "domain.com";
            string givenIpAddress = "11.11.11.11";

            string expectedResult = "OK";

            string givenRequest = $@"
            {{
                ""domainName"": ""{givenDomainName}"",
                ""ipAddress"": ""{givenIpAddress}""
            }}";

            string expectedResponse = $@"
            {{
                ""result"": ""{expectedResult}""
            }}";

            SetUpPostRequest(EMAIL_DOMAIN_IPS, givenRequest, expectedResponse, 200);

            var emailApi = new EmailApi(configuration);

            var emailDomainIpRequest = new EmailDomainIpRequest(
                    domainName: givenDomainName,
                    ipAddress: givenIpAddress
                );

            void AssertEmailSimpleApiResponse(EmailSimpleApiResponse emailSimpleApiResponse)
            { 
                Assert.IsNotNull(emailSimpleApiResponse);
                Assert.AreEqual(emailSimpleApiResponse.Result, expectedResult);
            }

            AssertResponse(emailApi.AssignIpToDomain(emailDomainIpRequest), AssertEmailSimpleApiResponse);
            AssertResponse(emailApi.AssignIpToDomainAsync(emailDomainIpRequest).Result, AssertEmailSimpleApiResponse);

            AssertResponseWithHttpInfo(emailApi.AssignIpToDomainWithHttpInfo(emailDomainIpRequest), AssertEmailSimpleApiResponse);
            AssertResponseWithHttpInfo(emailApi.AssignIpToDomainWithHttpInfoAsync(emailDomainIpRequest).Result, AssertEmailSimpleApiResponse);
        }

        [TestMethod]
        public void ShouldRemoveDedicatedIpAddressFromTheProvidedDomain()
        {

            string givenDomainName = "domain.com";
            string givenIpAddress = "11.11.11.11";

            string expectedResult = "OK";

            string expectedResponse = $@"
            {{
                ""result"": ""{expectedResult}""
            }}";

            var givenQueryParameters = new Dictionary<string, string> { 
                { "domainName", givenDomainName },
                { "ipAddress", givenIpAddress }
             };

            SetUpDeleteRequestWithResponseBody(EMAIL_DOMAIN_IPS, givenQueryParameters, expectedResponse, 200);

            var emailApi = new EmailApi(configuration);

            void AssertEmailSimpleApiResponse(EmailSimpleApiResponse emailSimpleApiResponse)
            {
                Assert.IsNotNull(emailSimpleApiResponse);
                Assert.AreEqual(emailSimpleApiResponse.Result, expectedResult);
            }

            AssertResponse(emailApi.RemoveIpFromDomain(givenDomainName, givenIpAddress), AssertEmailSimpleApiResponse);
            AssertResponse(emailApi.RemoveIpFromDomainAsync(givenDomainName, givenIpAddress).Result, AssertEmailSimpleApiResponse);

            AssertResponseWithHttpInfo(emailApi.RemoveIpFromDomainWithHttpInfo(givenDomainName, givenIpAddress), AssertEmailSimpleApiResponse);
            AssertResponseWithHttpInfo(emailApi.RemoveIpFromDomainWithHttpInfoAsync(givenDomainName, givenIpAddress).Result, AssertEmailSimpleApiResponse);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void SendEmailErrorResponseTest(int errorResponseIndex)
        {
            int expectedHttpCode = ErrorResponses[errorResponseIndex].Item1;
            string expectedMessageId = ErrorResponses[errorResponseIndex].Item2;
            string expectedErrorText = ErrorResponses[errorResponseIndex].Item4;
            string expectedErrorPhrase = ErrorResponses[errorResponseIndex].Item3;

            string givenTo = "john.smith@somedomain.com";
            int givenMessageCount = 1;
            string givenMessageId = "somexternalMessageId";
            int givenGroupId = 1;
            string givenGroupName = "PENDING";
            int givenId = 7;
            string givenName = "PENDING_ENROUTE";
            string givenDescription = "Message sent to next instance";
            string givenFrom = "jane.smith@somecompany.com";
            string givenSubject = "Mail subject text";
            string givenMailText = "Mail text";

            string givenRequest = $@"
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

            string expectedJson = $@"
            {{
                ""requestError"": {{
                    ""serviceException"": {{
                        ""messageId"": ""{expectedMessageId}"",
                        ""text"": ""{expectedErrorText}""
                    }}
                }}
            }}";

            Dictionary<string, string> responseHeaders = new Dictionary<string, string>()
            {
                { "Server", "SMS,API" },
                { "X-Request-ID", "1608758729810312842" },
                { "Content-Type", "application/json; charset=utf-8" }
            };

            Multimap<string, string> givenParts = new Multimap<string, string>
            {
                { "from", givenFrom },
                { "to", givenTo },
                { "subject", givenSubject },
                { "text", givenMailText},
            };

            SetUpMultipartFormRequest(EMAIL_SEND_FULLY_FEATURED_ENDPOINT, givenParts, expectedJson, expectedHttpCode);

            var emailApi = new EmailApi(this.configuration);

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
                Assert.IsTrue(responseHeaders.All(h => ex.Headers.ContainsKey(h.Key) && ex.Headers[h.Key].First().Equals(h.Value)));
            }
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void GetEmailDeliveryReportsResponseTest(int errorResponseIndex)
        {
            int expectedHttpCode = DeliveryReportErrorResponses[errorResponseIndex].Item1;
            string expectedMessageId = DeliveryReportErrorResponses[errorResponseIndex].Item2;
            string expectedErrorPhrase = DeliveryReportErrorResponses[errorResponseIndex].Item3;
            string expectedErrorText = DeliveryReportErrorResponses[errorResponseIndex].Item4;

            string givenMessageId = "MSG-TEST-123";
            string givenBulkId = "BULK-1234";
            int givenLimit = 2;

            string expectedJson = $@"
            {{
                ""requestError"": {{
                    ""serviceException"": {{
                        ""messageId"": ""{expectedMessageId}"",
                        ""text"": ""{expectedErrorPhrase}"",
                        ""validationErrors"": ""{expectedErrorText}""
                    }}
                }}
            }}";

            Dictionary<string, string> responseHeaders = new Dictionary<string, string>()
            {
                { "Server", SERVER_HEADER_VALUE_COMMA },
                { "X-Request-ID", X_REQUEST_ID_HEADER_VALUE },
                { "Content-Type", CONTENT_TYPE_HEADER_VALUE }
            };

            SetUpGetRequest(EMAIL_LOGS_ENDPOINT, expectedJson, expectedHttpCode);

            var emailApi = new EmailApi(this.configuration);

            try
            {
                var result = emailApi.GetEmailDeliveryReports(messageId: givenMessageId, bulkId: givenBulkId, limit: givenLimit);
            }
            catch (ApiException ex)
            {
                Assert.AreEqual(expectedHttpCode, ex.ErrorCode);
                Assert.AreEqual(expectedJson, ex.ErrorContent);
                Assert.IsInstanceOfType(ex, typeof(ApiException));
                Assert.IsTrue(ex.Message.Contains(expectedErrorPhrase));
                Assert.IsTrue(ex.ErrorContent.ToString()?.Contains(expectedMessageId) == true);
                Assert.IsTrue(ex.ErrorContent.ToString()?.Contains(expectedErrorText) == true);
                Assert.IsTrue(responseHeaders.All(h => ex.Headers.ContainsKey(h.Key) && ex.Headers[h.Key].First().Equals(h.Value)));
            }
        }
    }
}
