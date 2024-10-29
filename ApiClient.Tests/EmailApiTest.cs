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
            int givenMessageCount = 2;
            int expectedStatusId = 1;
            int expectedStatusGroupId = 1;
            string givenMessageId = "MSG-1234";
            string givenMessageId2 = "e7zzb1v9yirml2se9zo4";
            string expectedBulkId = "BULK-1234";
            string expectedStatusName = "PENDING";
            string expectedText = "Rich HTML message body.";
            string expectedHtml = "<h1>Html body</h1><p>Rich HTML message body.</p>";


            string expectedResponse = $@"
            {{
                ""messages"": [
                {{
                    ""to"": ""{expectedTo}"",
                    ""messageCount"": {givenMessageCount},
                    ""messageId"": ""{givenMessageId}"",
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
                    ""messageId"": ""{givenMessageId2}"",
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
                messageId: givenMessageId,
                templateId: null,
                attachment: null,
                inlineImage: null,
                html: expectedHtml,
                replyTo: expectedReplyTo,
                defaultPlaceholders: null,
                preserveRecipients: null,
                trackingUrl: null,
                trackClicks: null,
                trackOpens: null,
                track: null,
                callbackData: null,
                intermediateReport: null,
                notifyUrl: null,
                notifyContentType: null,
                sendAt: null
            );

            Assert.AreEqual(response.Messages.Count, givenMessageCount);
            Assert.AreEqual(response.Messages[0].MessageId, givenMessageId);
            Assert.AreEqual(response.Messages[0].To, expectedTo);
            Assert.AreEqual(response.Messages[0].Status.Id, expectedStatusId);
            Assert.AreEqual(response.Messages[0].Status.Name, expectedStatusName);
            Assert.AreEqual(response.Messages[0].Status.GroupId, expectedStatusGroupId);
            Assert.AreEqual(response.Messages[0].Status.Description, expectedStatusDescription);
            Assert.AreEqual(response.Messages[0].Status.GroupId, expectedStatusGroupId);
            Assert.AreEqual(response.Messages[1].MessageId, givenMessageId2);
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
            int givenMessageCount = 1;
            int expectedStatusId = 1;
            int expectedStatusGroupId = 1;
            string givenMessageId = "MSG-1234";
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
                    ""messageCount"": {givenMessageCount},
                    ""messageId"": ""{givenMessageId}"",
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
                cc: null,
                bcc: null,
                text: expectedText,
                bulkId: expectedBulkId,
                messageId: givenMessageId,
                templateId: null,
                attachment: attachmentList,
                inlineImage: null,
                html: expectedHtml,
                replyTo: expectedReplyTo,
                defaultPlaceholders: null,
                preserveRecipients: null,
                trackingUrl: null,
                trackClicks: null,
                trackOpens: null,
                track: null,
                callbackData: null,
                intermediateReport: null,
                notifyUrl: null,
                notifyContentType: null,
                sendAt: null
            );

            Assert.AreEqual(response.Messages.Count, givenMessageCount);
            Assert.AreEqual(response.Messages[0].MessageId, givenMessageId);
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
            string givenTo = "john.smith@somedomain.com";
            int givenMessageCount = 1;
            string givenMessageId = "MSG-1234";
            string givenBulkId = "BULK-1234";
            DateTimeOffset givenSentAt = new DateTimeOffset(2021, 9, 2, 9, 57, 56, TimeSpan.FromHours(0));
            DateTimeOffset givenDoneAt = new DateTimeOffset(2021, 9, 2, 9, 58, 33, TimeSpan.FromHours(0));
            string givenCurrency = "EUR";
            decimal givenPricePerMessage = 0.0M;
            string givenStatusName = "DELIVERED_TO_HANDSET";
            int givenStatusId = 5;
            string givenStatusDescription = "Message delivered to handset";
            int givenStatusGroupId = 3;
            string givenStatusGroupName = "DELIVERED";
            string givenErrorName = "NO_ERROR";
            int givenErrorId = 5;
            string givenErrorDescription = "No Error";
            int givenErrorGroupId = 0;
            string givenErrorGroupName = "OK";
            bool givenErrorPermanent = false;
            string givenChannel = "EMAIL";

            string expectedResponse = $@"
            {{
                ""results"": [
                    {{
                        ""bulkId"": ""{givenBulkId}"",
                        ""messageId"": ""{givenMessageId}"",
                        ""to"": ""{givenTo}"",
                        ""sentAt"": ""{givenSentAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                        ""doneAt"": ""{givenDoneAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                        ""messageCount"": {givenMessageCount},
                        ""price"": {{
                            ""pricePerMessage"": {givenPricePerMessage.ToString("N", CultureInfo.InvariantCulture)},
                            ""currency"": ""{givenCurrency}""
                        }},
                        ""status"": {{
                            ""groupId"": {givenStatusGroupId},
                            ""groupName"": ""{givenStatusGroupName}"",
                            ""id"": {givenStatusId},
                            ""name"": ""{givenStatusName}"",
                            ""description"": ""{givenStatusDescription}""
                        }},
                        ""error"": {{
                            ""groupId"": {givenErrorGroupId},
                            ""groupName"": ""{givenErrorGroupName}"",
                            ""id"": {givenErrorId},
                            ""name"": ""{givenErrorName}"",
                            ""description"": ""{givenErrorDescription}"",
                            ""permanent"": {givenErrorPermanent.ToString().ToLower()}
                        }},
                        ""channel"": ""{givenChannel}""
                    }}
                ]
            }}";

            SetUpGetRequest(EMAIL_LOGS_ENDPOINT, expectedResponse, 200);

            var sendEmailApi = new EmailApi(configuration);

            EmailReportsResult response = sendEmailApi.GetEmailDeliveryReports(bulkId: givenBulkId, messageId: givenMessageId, limit: 2);

            Assert.AreEqual(response.Results.Count, 1);
            Assert.AreEqual(response.Results[0].BulkId, givenBulkId);
            Assert.AreEqual(response.Results[0].MessageId, givenMessageId);

            Assert.AreEqual(response.Results[0].SentAt, givenSentAt);
            Assert.AreEqual(response.Results[0].DoneAt, givenDoneAt);
            Assert.AreEqual(response.Results[0].MessageCount, givenMessageCount);

            Assert.AreEqual(response.Results[0].Status.Description, givenStatusDescription);
            Assert.AreEqual(response.Results[0].Status.GroupId, givenStatusGroupId);
            Assert.AreEqual(response.Results[0].Status.GroupName, givenStatusGroupName);
            Assert.AreEqual(response.Results[0].Status.Id, givenStatusId);
            Assert.AreEqual(response.Results[0].Status.Name, givenStatusName);

            Assert.AreEqual(response.Results[0].Price.PricePerMessage, givenPricePerMessage);

            Assert.AreEqual(response.Results[0].Error.Description, givenErrorDescription);
            Assert.AreEqual(response.Results[0].Error.GroupId, givenErrorGroupId);
            Assert.AreEqual(response.Results[0].Error.GroupName, givenErrorGroupName);
            Assert.AreEqual(response.Results[0].Error.Id, givenErrorId);
            Assert.AreEqual(response.Results[0].Error.Name, givenErrorName);
            Assert.AreEqual(response.Results[0].Error.Permanent, givenErrorPermanent);
        }

        [TestMethod]
        public void ShouldGetEmailLogsTest()
        {
            string givenFrom = "Jane Doe <jane.doe@somecompany.com";
            string givenTo = "john.smith@somedomain.com";
            string givenText = "Mail body text";
            int givenMessageCount = 1;
            string givenMessageId = "MSG-1234";
            string givenBulkId = "BULK-1234";
            DateTimeOffset givenSentAt = new DateTimeOffset(2021, 9, 2, 9, 57, 56, TimeSpan.FromHours(0));
            DateTimeOffset givenDoneAt = new DateTimeOffset(2021, 9, 2, 9, 57, 56, TimeSpan.FromHours(0));
            string givenCurrency = "EUR";
            decimal givenPricePerMessage = 0.0m;
            string givenStatusName = "DELIVERED_TO_HANDSET";
            int givenStatusId = 5;
            string givenStatusDescription = "Message delivered to handset";
            int givenStatusGroupId = 3;
            string givenStatusGroupName = "DELIVERED";
            string givenChannel = "EMAIL";

            string expectedResponse = $@"
            {{
                ""results"": [
                {{
                    ""messageId"": ""{givenMessageId}"",
                    ""to"": ""{givenTo}"",
                    ""from"": ""{givenFrom}"",
                    ""text"": ""{givenText}"",
                    ""sentAt"": ""{givenSentAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                    ""doneAt"": ""{givenDoneAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                    ""messageCount"": {givenMessageCount},
                    ""price"": {{
                        ""pricePerMessage"": {givenPricePerMessage.ToString("N", CultureInfo.InvariantCulture)},
                        ""currency"": ""{givenCurrency}""
                    }},
                    ""status"": {{
                        ""groupId"": {givenStatusGroupId},
                        ""groupName"": ""{givenStatusGroupName}"",
                        ""id"": {givenStatusId},
                        ""name"": ""{givenStatusName}"",
                        ""description"": ""{givenStatusDescription}""
                    }},
                    ""channel"": ""{givenChannel}"",
                    ""bulkId"": ""{givenBulkId}""
                }}
                ]
            }}";

            SetUpGetRequest(EMAIL_REPORTS_ENDPOINT, expectedResponse, 200);

            var sendEmailApi = new EmailApi(configuration);

            EmailLogsResponse response = sendEmailApi.GetEmailLogs(
                from: null,
                to: null,
                bulkId: givenBulkId,
                messageId: givenMessageId,
                generalStatus: null,
                sentSince: null,
                limit: 2
            );

            Assert.AreEqual(response.Results.Count, 1);

            Assert.AreEqual(response.Results[0].From, givenFrom);
            Assert.AreEqual(response.Results[0].BulkId, givenBulkId);
            Assert.AreEqual(response.Results[0].MessageId, givenMessageId);
            Assert.AreEqual(response.Results[0].SentAt, givenSentAt);
            Assert.AreEqual(response.Results[0].DoneAt, givenDoneAt);
            Assert.AreEqual(response.Results[0].Text, givenText);
            Assert.AreEqual(response.Results[0].To, givenTo);
            Assert.AreEqual(response.Results[0].MessageCount, givenMessageCount);

            Assert.AreEqual(response.Results[0].Status.Description, givenStatusDescription);
            Assert.AreEqual(response.Results[0].Status.GroupId, givenStatusGroupId);
            Assert.AreEqual(response.Results[0].Status.GroupName, givenStatusGroupName);
            Assert.AreEqual(response.Results[0].Status.Id, givenStatusId);
            Assert.AreEqual(response.Results[0].Status.Name, givenStatusName);

            Assert.AreEqual(response.Results[0].Price.PricePerMessage, givenPricePerMessage);
        }

        [TestMethod]
        public void ShouldGetScheduledEmailsTest()
        {
            string givenExternalBulkId = "BULK-1234";
            string givenBulkId = "1234593932111";
            DateTimeOffset givenSentAt = new DateTimeOffset(2021, 9, 2, 9, 56, 53, TimeSpan.FromHours(0));

            string expectedResponse = $@"
            {{
                ""externalBulkId"": ""{givenExternalBulkId}"",
                ""bulks"": [
                    {{
                        ""bulkId"": ""{givenBulkId}"",
                        ""sendAt"": ""{givenSentAt.ToUniversalTime().ToString(DATE_FORMAT)}""
                    }}
                ]
            }}";

            SetUpGetRequest(EMAIL_BULKS_ENDPOINT, expectedResponse, 200);

            var scheduledEmailApi = new EmailApi(configuration);

            EmailBulkScheduleResponse response = scheduledEmailApi.GetScheduledEmails(givenBulkId);

            Assert.AreEqual(response.Bulks.Count, 1);
            Assert.AreEqual(response.ExternalBulkId, givenExternalBulkId);

            Assert.AreEqual(response.Bulks[0].BulkId, givenBulkId);
            Assert.AreEqual(response.Bulks[0].SendAt, givenSentAt);
        }

        [TestMethod]
        public void ShouldRescheduleEmailsTest()
        {
            string givenBulkId = "1234593932111";
            DateTimeOffset givenSentAt = new DateTimeOffset(2023, 5, 16, 11, 55, 51, TimeSpan.FromHours(0));

            string givenRequest = $@"
            {{
                ""sendAt"": ""{givenSentAt.ToUniversalTime().ToString(DATE_FORMAT)}""
            }}";

            string expectedResponse = $@"
            {{
                ""bulkId"": ""{givenBulkId}"",
                ""sendAt"": ""{givenSentAt.ToUniversalTime().ToString(DATE_FORMAT)}""
            }}";

            SetUpPutRequest(EMAIL_BULKS_ENDPOINT, givenRequest, expectedResponse, 200);

            var scheduledEmailApi = new EmailApi(configuration);
            EmailBulkRescheduleRequest rescheduleRequest = new EmailBulkRescheduleRequest(givenSentAt);

            EmailBulkRescheduleResponse response = scheduledEmailApi.RescheduleEmails(givenBulkId, rescheduleRequest);

            Assert.AreEqual(response.BulkId, givenBulkId);
            Assert.AreEqual(response.SendAt, givenSentAt);
        }

        [TestMethod]
        public void ShouldGetScheduledEmailStatusTest()
        {
            string givenExternalBulkId = "BULK-1234";
            string givenBulkId = "1234593932111";
            string givenBulkId2 = "1234594942111";

            //StatusEnum givenStatus = StatusEnum.Finished;
            EmailBulkStatus givenStatus = EmailBulkStatus.Finished;
            //StatusEnum givenStatus2 = StatusEnum.Pending;
            EmailBulkStatus givenStatus2 = EmailBulkStatus.Pending;

            string expectedResponse = $@"
            {{
                ""externalBulkId"": ""{givenExternalBulkId}"",
                ""bulks"": [
                {{
                    ""bulkId"": ""{givenBulkId}"",
                    ""status"": ""{givenStatus}""
                }},
                {{
                    ""bulkId"": ""{givenBulkId2}"",
                    ""status"": ""{givenStatus2}""
                }}
                ]
            }}";

            SetUpGetRequest(EMAIL_BULKS_STATUS_ENDPOINT, expectedResponse, 200);

            var scheduledEmailApi = new EmailApi(configuration);

            EmailBulkStatusResponse response = scheduledEmailApi.GetScheduledEmailStatuses(givenBulkId);

            Assert.AreEqual(response.Bulks.Count, 2);
            Assert.AreEqual(response.ExternalBulkId, givenExternalBulkId);
            Assert.AreEqual(response.Bulks[0].BulkId, givenBulkId);
            Assert.AreEqual(response.Bulks[0].Status, givenStatus);
            Assert.AreEqual(response.Bulks[1].BulkId, givenBulkId2);
            Assert.AreEqual(response.Bulks[1].Status, givenStatus2);
        }

        [TestMethod]
        public void ShouldUpdateEmailStatusTest()
        {
            string givenBulkId = "1234593932111";
            //EmailBulkUpdateStatusRequest.StatusEnum givenStatus = EmailBulkUpdateStatusRequest.StatusEnum.Paused;
            EmailBulkStatus givenStatus = EmailBulkStatus.Paused;

            string givenRequest = $@"
            {{
                ""status"": ""{givenStatus}"",
            }}";

            string expectedResponse = $@"
            {{
                ""bulkId"": ""{givenBulkId}"",
                ""status"": ""{givenStatus}""
            }}";

            SetUpPutRequest(EMAIL_BULKS_STATUS_ENDPOINT, givenRequest, expectedResponse, 200);

            var scheduledEmailApi = new EmailApi(configuration);

            EmailBulkUpdateStatusRequest updateStatusRequest = new EmailBulkUpdateStatusRequest(givenStatus);

            EmailBulkUpdateStatusResponse response = scheduledEmailApi.UpdateScheduledEmailStatuses(givenBulkId, updateStatusRequest);

            Assert.AreEqual(response.BulkId, givenBulkId);
            Assert.AreEqual(response.Status, givenStatus);
        }

        [TestMethod]
        public void ValidateEmailAddressesTest()
        {
            string givenTo = "john.smith@somedomain.com";
            string expectedValidMailbox = "true";
            bool expectedValidSyntax = true;
            bool expectedCatchAll = false;
            string expectedDidYouMean = "true";
            bool expectedDisposable = false;
            bool expectedRoleBased = true;

            string expectedRequest = $@"
            {{
                ""to"": ""{givenTo}"",
            }}";

            string expectedResponse = $@"
            {{
                ""to"": ""{givenTo}"",
                ""validMailbox"": {expectedValidMailbox},
                ""validSyntax"": {expectedValidSyntax.ToString().ToLower()},
                ""catchAll"": {expectedCatchAll.ToString().ToLower()},
                ""didYouMean"": {expectedDidYouMean},
                ""disposable"": {expectedDisposable.ToString().ToLower()},
                ""roleBased"": {expectedRoleBased.ToString().ToLower()}
            }}";

            SetUpPostRequest(EMAIL_VALIDATE_ADDRESSES_ENDPOINT, expectedRequest, expectedResponse, 200);

            var emailValidationApi = new EmailApi(configuration);

            EmailValidationRequest validationRequest = new EmailValidationRequest(givenTo);

            EmailValidationResponse response = emailValidationApi.ValidateEmailAddresses(validationRequest);

            Assert.AreEqual(response.To, givenTo);
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
            int givenPage = 0;
            int givenSize = 0;
            int givenTotalPages = 0;
            int givenTotalResults = 0;
            int givenDomainId = 1;
            string givenDomainName = "example.com";
            bool givenActive = false;
            bool givenClicks = true;
            bool givenOpens = true;
            bool givenUnsubscribe = true;
            string givenRecordType = "string";
            string givenName = "string";
            string givenExpectedValue = "string";
            bool givenVerified = true;
            bool givenBlocked = false;
            DateTimeOffset givenCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string givenReturnPathAddress = "returnpath@example.com";

            string givenResponse = $@"
            {{
                ""paging"": {{
                    ""page"": {givenPage},
                    ""size"": {givenSize},
                    ""totalPages"": {givenTotalPages},
                    ""totalResults"": {givenTotalResults}
                }},
                ""results"": [
                    {{
                         ""domainId"": {givenDomainId},
                         ""domainName"": ""{givenDomainName}"",
                         ""active"": {givenActive.ToString().ToLower()},
                         ""tracking"": {{
                            ""clicks"": {givenClicks.ToString().ToLower()},
                            ""opens"": {givenOpens.ToString().ToLower()},
                            ""unsubscribe"": {givenUnsubscribe.ToString().ToLower()}
                         }},
                         ""dnsRecords"": [
                            {{
                                ""recordType"": ""{givenRecordType}"",
                                ""name"": ""{givenName}"",
                                ""expectedValue"": ""{givenExpectedValue}"",
                                ""verified"": {givenVerified.ToString().ToLower()}
                            }}
                         ],
                         ""blocked"": {givenBlocked.ToString().ToLower()},
                         ""createdAt"": ""{givenCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                         ""returnPathAddress"": ""{givenReturnPathAddress}""
                    }}
                ]
            }}";

            var expectedQueryParameters = new Dictionary<string, string> {
                { "size", givenSize.ToString() },
                { "page", givenPage.ToString() }
             };

            SetUpGetRequest(EMAIL_DOMAINS, expectedQueryParameters, givenResponse, 200);

            var emailApi = new EmailApi(configuration);

            void AssertEmailAllDomainsResponse(EmailAllDomainsResponse emailAllDomainsResponse)
            {
                Assert.IsNotNull(emailAllDomainsResponse.Paging);
                Assert.AreEqual(emailAllDomainsResponse.Paging.Page, givenPage);
                Assert.AreEqual(emailAllDomainsResponse.Paging.Size, givenSize);
                Assert.AreEqual(emailAllDomainsResponse.Paging.TotalPages, givenTotalPages);
                Assert.AreEqual(emailAllDomainsResponse.Paging.TotalResults, givenTotalResults);

                Assert.IsNotNull(emailAllDomainsResponse.Results);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DomainId, givenDomainId);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DomainName, givenDomainName);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Active, givenActive);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Tracking.Clicks, givenClicks);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Tracking.Opens, givenOpens);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Tracking.Unsubscribe, givenUnsubscribe);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DnsRecords[0].RecordType, givenRecordType);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DnsRecords[0].Name, givenName);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DnsRecords[0].ExpectedValue, givenExpectedValue);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].DnsRecords[0].Verified, givenVerified);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].Blocked, givenBlocked);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].CreatedAt, givenCreatedAt);
                Assert.AreEqual(emailAllDomainsResponse.Results[0].ReturnPathAddress, givenReturnPathAddress);
            }

            AssertResponse(emailApi.GetAllDomains(givenSize, givenPage), AssertEmailAllDomainsResponse);
            AssertResponse(emailApi.GetAllDomainsAsync(givenSize, givenPage).Result, AssertEmailAllDomainsResponse);

            AssertResponseWithHttpInfo(emailApi.GetAllDomainsWithHttpInfo(givenSize, givenPage), AssertEmailAllDomainsResponse);
            AssertResponseWithHttpInfo(emailApi.GetAllDomainsWithHttpInfoAsync(givenSize, givenPage).Result, AssertEmailAllDomainsResponse);
        }

        [TestMethod]
        public void ShouldAddNewDomain()
        {
            string expectedDomainName = "example.com";
            int expectedDkimKeyLength = 1024;
            long expectedTargetedDailyTraffic = 1000;
            string expectedApplicationId = "string";
            string expectedEntityId = "string";
            string expectedReturnPathAddress = "string";

            int givenDomainId = 1;
            string givenDomainName = "example.com";
            bool givenActive = false;
            bool givenClicks = true;
            bool givenOpens = true;
            bool givenUnsubscribe = true;
            string givenRecordType = "string";
            string givenName = "string";
            string givenExpectedValue = "string";
            bool givenVerified = true;
            bool givenBlocked = false;
            DateTimeOffset givenCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string givenReturnPathAddress = "returnpath@example.com";

            string expectedRequest = $@"
            {{
                ""domainName"": ""{expectedDomainName}"",
                ""dkimKeyLength"": {expectedDkimKeyLength},
                ""targetedDailyTraffic"": {expectedTargetedDailyTraffic},
                ""applicationId"": ""{expectedApplicationId}"",
                ""entityId"": ""{expectedEntityId}"",
                ""returnPathAddress"": ""{expectedReturnPathAddress}""
            }}";

            string givenResponse = $@"
            {{
                ""domainId"": {givenDomainId},
                ""domainName"": ""{givenDomainName}"",
                ""active"": {givenActive.ToString().ToLower()},
                ""tracking"": {{
                    ""clicks"": {givenClicks.ToString().ToLower()},
                    ""opens"": {givenOpens.ToString().ToLower()},
                    ""unsubscribe"": {givenUnsubscribe.ToString().ToLower()}
                }},
                ""dnsRecords"": [
                    {{
                        ""recordType"": ""{givenRecordType}"",
                        ""name"": ""{givenName}"",
                        ""expectedValue"": ""{givenExpectedValue}"",
                        ""verified"": {givenVerified.ToString().ToLower()}
                    }}
                ],
                ""blocked"": {givenBlocked.ToString().ToLower()},
                ""createdAt"": ""{givenCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                ""returnPathAddress"": ""{givenReturnPathAddress}""
            }}";

            SetUpPostRequest(EMAIL_DOMAINS, expectedRequest, givenResponse, 200);

            var emailApi = new EmailApi(configuration);

            var emailAddDomainRequest = new EmailAddDomainRequest(
                    domainName: expectedDomainName,
                    dkimKeyLength: DkimKeyLengthEnum.NUMBER1024,
                    targetedDailyTraffic: expectedTargetedDailyTraffic,
                    applicationId: expectedApplicationId,
                    entityId: expectedEntityId,
                    returnPathAddress: expectedReturnPathAddress
                );

            void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
            {
                Assert.IsNotNull(emailDomainResponse);
                Assert.AreEqual(emailDomainResponse.DomainId, givenDomainId);
                Assert.AreEqual(emailDomainResponse.DomainName, givenDomainName);
                Assert.AreEqual(emailDomainResponse.Active, givenActive);
                Assert.AreEqual(emailDomainResponse.Tracking.Clicks, givenClicks);
                Assert.AreEqual(emailDomainResponse.Tracking.Opens, givenOpens);
                Assert.AreEqual(emailDomainResponse.Tracking.Unsubscribe, givenUnsubscribe);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].RecordType, givenRecordType);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Name, givenName);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].ExpectedValue, givenExpectedValue);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Verified, givenVerified);
                Assert.AreEqual(emailDomainResponse.Blocked, givenBlocked);
                Assert.AreEqual(emailDomainResponse.CreatedAt, givenCreatedAt);
                Assert.AreEqual(emailDomainResponse.ReturnPathAddress, givenReturnPathAddress);
            }

            AssertResponse(emailApi.AddDomain(emailAddDomainRequest), AssertEmailDomainResponse);
            AssertResponse(emailApi.AddDomainAsync(emailAddDomainRequest).Result, AssertEmailDomainResponse);

            AssertResponseWithHttpInfo(emailApi.AddDomainWithHttpInfo(emailAddDomainRequest), AssertEmailDomainResponse);
            AssertResponseWithHttpInfo(emailApi.AddDomainWithHttpInfoAsync(emailAddDomainRequest).Result, AssertEmailDomainResponse);
        }

        [TestMethod]
        public void ShouldGetDomainDetails()
        {
            int givenDomainId = 1;
            string givenDomainName = "example.com";
            bool givenActive = false;
            bool givenClicks = true;
            bool givenOpens = true;
            bool givenUnsubscribe = true;
            string givenRecordType = "string";
            string givenName = "string";
            string givenExpectedValue = "string";
            bool givenVerified = true;
            bool givenBlocked = false;
            DateTimeOffset givenCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string givenReturnPathAddress = "returnpath@example.com";

            string givenResponse = $@"
            {{
                ""domainId"": {givenDomainId},
                ""domainName"": ""{givenDomainName}"",
                ""active"": {givenActive.ToString().ToLower()},
                ""tracking"": {{
                    ""clicks"": {givenClicks.ToString().ToLower()},
                    ""opens"": {givenOpens.ToString().ToLower()},
                    ""unsubscribe"": {givenUnsubscribe.ToString().ToLower()}
                }},
                ""dnsRecords"": [
                    {{
                        ""recordType"": ""{givenRecordType}"",
                        ""name"": ""{givenName}"",
                        ""expectedValue"": ""{givenExpectedValue}"",
                        ""verified"": {givenVerified.ToString().ToLower()}
                    }}
                ],
                ""blocked"": {givenBlocked.ToString().ToLower()},
                ""createdAt"": ""{givenCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                ""returnPathAddress"": ""{givenReturnPathAddress}""
            }}";

            SetUpGetRequest(EMAIL_DOMAIN.Replace("{domainName}", givenDomainName), givenResponse, 200);

            var emailApi = new EmailApi(configuration);

            void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
            {
                Assert.IsNotNull(emailDomainResponse);
                Assert.AreEqual(emailDomainResponse.DomainId, givenDomainId);
                Assert.AreEqual(emailDomainResponse.DomainName, givenDomainName);
                Assert.AreEqual(emailDomainResponse.Active, givenActive);
                Assert.AreEqual(emailDomainResponse.Tracking.Clicks, givenClicks);
                Assert.AreEqual(emailDomainResponse.Tracking.Opens, givenOpens);
                Assert.AreEqual(emailDomainResponse.Tracking.Unsubscribe, givenUnsubscribe);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].RecordType, givenRecordType);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Name, givenName);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].ExpectedValue, givenExpectedValue);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Verified, givenVerified);
                Assert.AreEqual(emailDomainResponse.Blocked, givenBlocked);
                Assert.AreEqual(emailDomainResponse.CreatedAt, givenCreatedAt);
                Assert.AreEqual(emailDomainResponse.ReturnPathAddress, givenReturnPathAddress);
            }

            AssertResponse(emailApi.GetDomainDetails(givenDomainName), AssertEmailDomainResponse);
            AssertResponse(emailApi.GetDomainDetailsAsync(givenDomainName).Result, AssertEmailDomainResponse);

            AssertResponseWithHttpInfo(emailApi.GetDomainDetailsWithHttpInfo(givenDomainName), AssertEmailDomainResponse);
            AssertResponseWithHttpInfo(emailApi.GetDomainDetailsWithHttpInfoAsync(givenDomainName).Result, AssertEmailDomainResponse);
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
            int givenDomainId = 1;
            string givenDomainName = "example.com";
            bool givenActive = false;
            bool givenClicks = true;
            bool givenOpens = true;
            bool givenUnsubscribe = true;
            string givenRecordType = "string";
            string givenName = "string";
            string givenExpectedValue = "string";
            bool givenVerified = true;
            bool givenBlocked = false;
            DateTimeOffset givenCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string givenReturnPathAddress = "returnpath@example.com";

            string expectedRequest = $@"
            {{
                ""open"": {givenOpens.ToString().ToLower()},
                ""clicks"": {givenClicks.ToString().ToLower()},
                ""unsubscribe"": {givenUnsubscribe.ToString().ToLower()}
            }}";

            string givenResponse = $@"
            {{
                ""domainId"": {givenDomainId},
                ""domainName"": ""{givenDomainName}"",
                ""active"": {givenActive.ToString().ToLower()},
                ""tracking"": {{
                    ""clicks"": {givenClicks.ToString().ToLower()},
                    ""opens"": {givenOpens.ToString().ToLower()},
                    ""unsubscribe"": {givenUnsubscribe.ToString().ToLower()}
                }},
                ""dnsRecords"": [
                    {{
                        ""recordType"": ""{givenRecordType}"",
                        ""name"": ""{givenName}"",
                        ""expectedValue"": ""{givenExpectedValue}"",
                        ""verified"": {givenVerified.ToString().ToLower()}
                    }}
                ],
                ""blocked"": {givenBlocked.ToString().ToLower()},
                ""createdAt"": ""{givenCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                ""returnPathAddress"": ""{givenReturnPathAddress}""
            }}";

            SetUpPutRequest(EMAIL_DOMAIN_TRACKING.Replace("{domainName}", givenDomainName), expectedRequest, givenResponse, 200);

            var emailApi = new EmailApi(configuration);

            var emailTrackingEventRequest = new EmailTrackingEventRequest(
                    open: givenOpens,
                    clicks: givenClicks,
                    unsubscribe: givenUnsubscribe
                );

            void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
            {
                Assert.IsNotNull(emailDomainResponse);
                Assert.AreEqual(emailDomainResponse.DomainId, givenDomainId);
                Assert.AreEqual(emailDomainResponse.DomainName, givenDomainName);
                Assert.AreEqual(emailDomainResponse.Active, givenActive);
                Assert.AreEqual(emailDomainResponse.Tracking.Clicks, givenClicks);
                Assert.AreEqual(emailDomainResponse.Tracking.Opens, givenOpens);
                Assert.AreEqual(emailDomainResponse.Tracking.Unsubscribe, givenUnsubscribe);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].RecordType, givenRecordType);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Name, givenName);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].ExpectedValue, givenExpectedValue);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Verified, givenVerified);
                Assert.AreEqual(emailDomainResponse.Blocked, givenBlocked);
                Assert.AreEqual(emailDomainResponse.CreatedAt, givenCreatedAt);
                Assert.AreEqual(emailDomainResponse.ReturnPathAddress, givenReturnPathAddress);
            }

            AssertResponse(emailApi.UpdateTrackingEvents(givenDomainName, emailTrackingEventRequest), AssertEmailDomainResponse);
            AssertResponse(emailApi.UpdateTrackingEventsAsync(givenDomainName, emailTrackingEventRequest).Result, AssertEmailDomainResponse);

            AssertResponseWithHttpInfo(emailApi.UpdateTrackingEventsWithHttpInfo(givenDomainName, emailTrackingEventRequest), AssertEmailDomainResponse);
            AssertResponseWithHttpInfo(emailApi.UpdateTrackingEventsWithHttpInfoAsync(givenDomainName, emailTrackingEventRequest).Result, AssertEmailDomainResponse);
        }

        [TestMethod]
        public void ShouldUpdateReturnPath()
        {
            int givenDomainId = 1;
            string givenDomainName = "example.com";
            bool givenActive = false;
            bool givenClicks = true;
            bool givenOpens = true;
            bool givenUnsubscribe = true;
            string givenRecordType = "string";
            string givenName = "string";
            string givenExpectedValue = "string";
            bool givenVerified = true;
            bool givenBlocked = false;
            DateTimeOffset givenCreatedAt = new DateTimeOffset(2021, 1, 2, 1, 0, 0, 123, TimeSpan.FromHours(0));
            string givenReturnPathAddress = "returnpath@example.com";

            string expectedRequest = $@"
            {{
                ""returnPathAddress"": ""{givenReturnPathAddress}"",
            }}";

            string givenResponse = $@"
            {{
                ""domainId"": {givenDomainId},
                ""domainName"": ""{givenDomainName}"",
                ""active"": {givenActive.ToString().ToLower()},
                ""tracking"": {{
                    ""clicks"": {givenClicks.ToString().ToLower()},
                    ""opens"": {givenOpens.ToString().ToLower()},
                    ""unsubscribe"": {givenUnsubscribe.ToString().ToLower()}
                }},
                ""dnsRecords"": [
                    {{
                        ""recordType"": ""{givenRecordType}"",
                        ""name"": ""{givenName}"",
                        ""expectedValue"": ""{givenExpectedValue}"",
                        ""verified"": {givenVerified.ToString().ToLower()}
                    }}
                ],
                ""blocked"": {givenBlocked.ToString().ToLower()},
                ""createdAt"": ""{givenCreatedAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                ""returnPathAddress"": ""{givenReturnPathAddress}""
            }}";

            SetUpPutRequest(EMAIL_DOMAIN_RETURN_PATH.Replace("{domainName}", givenDomainName), expectedRequest, givenResponse, 200);

            var emailApi = new EmailApi(configuration);

            var emailReturnPathAddressRequest = new EmailReturnPathAddressRequest(
                    returnPathAddress: givenReturnPathAddress
                );

            void AssertEmailDomainResponse(EmailDomainResponse emailDomainResponse)
            {
                Assert.IsNotNull(emailDomainResponse);
                Assert.AreEqual(emailDomainResponse.DomainId, givenDomainId);
                Assert.AreEqual(emailDomainResponse.DomainName, givenDomainName);
                Assert.AreEqual(emailDomainResponse.Active, givenActive);
                Assert.AreEqual(emailDomainResponse.Tracking.Clicks, givenClicks);
                Assert.AreEqual(emailDomainResponse.Tracking.Opens, givenOpens);
                Assert.AreEqual(emailDomainResponse.Tracking.Unsubscribe, givenUnsubscribe);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].RecordType, givenRecordType);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Name, givenName);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].ExpectedValue, givenExpectedValue);
                Assert.AreEqual(emailDomainResponse.DnsRecords[0].Verified, givenVerified);
                Assert.AreEqual(emailDomainResponse.Blocked, givenBlocked);
                Assert.AreEqual(emailDomainResponse.CreatedAt, givenCreatedAt);
                Assert.AreEqual(emailDomainResponse.ReturnPathAddress, givenReturnPathAddress);
            }

            AssertResponse(emailApi.UpdateReturnPath(givenDomainName, emailReturnPathAddressRequest), AssertEmailDomainResponse);
            AssertResponse(emailApi.UpdateReturnPathAsync(givenDomainName, emailReturnPathAddressRequest).Result, AssertEmailDomainResponse);

            AssertResponseWithHttpInfo(emailApi.UpdateReturnPathWithHttpInfo(givenDomainName, emailReturnPathAddressRequest), AssertEmailDomainResponse);
            AssertResponseWithHttpInfo(emailApi.UpdateReturnPathWithHttpInfoAsync(givenDomainName, emailReturnPathAddressRequest).Result, AssertEmailDomainResponse);
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
            string givenIpAddress = "11.11.11.1";
            bool givenDedicated = true;
            int givenAssignedDomainCount = 1;
            string givenStatus = "ASSIGNABLE";

            string givenResponse = $@"
            {{
                ""result"": [
                    {{
                        ""ipAddress"": ""{givenIpAddress}"",
                        ""dedicated"": {givenDedicated.ToString().ToLower()},
                        ""assignedDomainCount"": {givenAssignedDomainCount},
                        ""status"": ""{givenStatus}""
                    }}
                ]
            }}";

            SetUpGetRequest(EMAIL_IPS, givenResponse, 200);

            var emailApi = new EmailApi(configuration);

            void AssertEmailDomainIpResponse(EmailDomainIpResponse emailDomainIpResponse)
            {
                Assert.IsNotNull(emailDomainIpResponse);
                Assert.IsNotNull(emailDomainIpResponse.Result[0]);
                Assert.AreEqual(emailDomainIpResponse.Result[0].IpAddress, givenIpAddress);
                Assert.AreEqual(emailDomainIpResponse.Result[0].Dedicated, givenDedicated);
                Assert.AreEqual(emailDomainIpResponse.Result[0].AssignedDomainCount, givenAssignedDomainCount);
                Assert.AreEqual(emailDomainIpResponse.Result[0].Status, givenStatus);
            }

            AssertResponse(emailApi.GetAllIps(), AssertEmailDomainIpResponse);
            AssertResponse(emailApi.GetAllIpsAsync().Result, AssertEmailDomainIpResponse);

            AssertResponseWithHttpInfo(emailApi.GetAllIpsWithHttpInfo(), AssertEmailDomainIpResponse);
            AssertResponseWithHttpInfo(emailApi.GetAllIpsWithHttpInfoAsync().Result, AssertEmailDomainIpResponse);
        }

        [TestMethod]
        public void ShouldListAllDedicatedIpsForDomainAndForProvidedAccountId()
        {
            string givenIpAddress = "11.11.11.1";
            bool givenDedicated = true;
            int givenAssignedDomainCount = 1;
            string givenStatus = "ASSIGNABLE";

            string givenDomainName = "domainName";

            string givenResponse = $@"
            {{
                ""result"": [
                    {{
                        ""ipAddress"": ""{givenIpAddress}"",
                        ""dedicated"": {givenDedicated.ToString().ToLower()},
                        ""assignedDomainCount"": {givenAssignedDomainCount},
                        ""status"": ""{givenStatus}""
                    }}
                ]
            }}";

            var queryParameters = new Dictionary<string, string>()
            {
                { "domainName", givenDomainName }
            };

            SetUpGetRequest(EMAIL_DOMAIN_IPS, queryParameters, givenResponse, 200);

            var emailApi = new EmailApi(configuration);

            void AssertEmailDomainIpResponse(EmailDomainIpResponse emailDomainIpResponse)
            {
                Assert.IsNotNull(emailDomainIpResponse);
                Assert.IsNotNull(emailDomainIpResponse.Result[0]);
                Assert.AreEqual(emailDomainIpResponse.Result[0].IpAddress, givenIpAddress);
                Assert.AreEqual(emailDomainIpResponse.Result[0].Dedicated, givenDedicated);
                Assert.AreEqual(emailDomainIpResponse.Result[0].AssignedDomainCount, givenAssignedDomainCount);
                Assert.AreEqual(emailDomainIpResponse.Result[0].Status, givenStatus);
            }

            AssertResponse(emailApi.GetAllDomainIps(givenDomainName), AssertEmailDomainIpResponse);
            AssertResponse(emailApi.GetAllDomainIpsAsync(givenDomainName).Result, AssertEmailDomainIpResponse);

            AssertResponseWithHttpInfo(emailApi.GetAllDomainIpsWithHttpInfo(givenDomainName), AssertEmailDomainIpResponse);
            AssertResponseWithHttpInfo(emailApi.GetAllDomainIpsWithHttpInfoAsync(givenDomainName).Result, AssertEmailDomainIpResponse);
        }

        [TestMethod]
        public void ShouldAssignDedicatedIpAddressToProvidedDomainForTheAccountId()
        {
            string givenDomainName = "domain.com";
            string givenIpAddress = "11.11.11.11";

            string givenResult = "OK";

            string expectedRequest = $@"
            {{
                ""domainName"": ""{givenDomainName}"",
                ""ipAddress"": ""{givenIpAddress}""
            }}";

            string givenResponse = $@"
            {{
                ""result"": ""{givenResult}""
            }}";

            SetUpPostRequest(EMAIL_DOMAIN_IPS, expectedRequest, givenResponse, 200);

            var emailApi = new EmailApi(configuration);

            var emailDomainIpRequest = new EmailDomainIpRequest(
                    domainName: givenDomainName,
                    ipAddress: givenIpAddress
                );

            void AssertEmailSimpleApiResponse(EmailSimpleApiResponse emailSimpleApiResponse)
            { 
                Assert.IsNotNull(emailSimpleApiResponse);
                Assert.AreEqual(emailSimpleApiResponse.Result, givenResult);
            }

            AssertResponse(emailApi.AssignIpToDomain(emailDomainIpRequest), AssertEmailSimpleApiResponse);
            AssertResponse(emailApi.AssignIpToDomainAsync(emailDomainIpRequest).Result, AssertEmailSimpleApiResponse);

            AssertResponseWithHttpInfo(emailApi.AssignIpToDomainWithHttpInfo(emailDomainIpRequest), AssertEmailSimpleApiResponse);
            AssertResponseWithHttpInfo(emailApi.AssignIpToDomainWithHttpInfoAsync(emailDomainIpRequest).Result, AssertEmailSimpleApiResponse);
        }

        [TestMethod]
        public void ShouldRemoveDedicatedIpAddressFromTheProvidedDomain()
        {
            string givenResult = "OK";

            string givenDomainName = "domain.com";
            string givenIpAddress = "11.11.11.11";

            string givenResponse = $@"
            {{
                ""result"": ""{givenResult}""
            }}";

            var expectedQueryParameters = new Dictionary<string, string> { 
                { "domainName", givenDomainName },
                { "ipAddress", givenIpAddress }
             };

            SetUpDeleteRequestWithResponseBody(EMAIL_DOMAIN_IPS, expectedQueryParameters, givenResponse, 200);

            var emailApi = new EmailApi(configuration);

            void AssertEmailSimpleApiResponse(EmailSimpleApiResponse emailSimpleApiResponse)
            {
                Assert.IsNotNull(emailSimpleApiResponse);
                Assert.AreEqual(emailSimpleApiResponse.Result, givenResult);
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
            // ARRANGE
            int httpCode = ErrorResponses[errorResponseIndex].Item1;
            string messageId = ErrorResponses[errorResponseIndex].Item2;
            string errorPhrase = ErrorResponses[errorResponseIndex].Item3;
            string errorText = ErrorResponses[errorResponseIndex].Item4;

            string to = "john.smith@somedomain.com";
            string from = "jane.smith@somecompany.com";
            string subject = "Mail subject text";
            string mailText = "Mail text";

            string responseJson = $@"
            {{
                ""requestError"": {{
                    ""serviceException"": {{
                    ""messageId"": ""{messageId}"",
                    ""text"": ""{errorText}""
                    }}
                }}
            }}";

            string expectedRequest = $@"
            {{
              ""messages"": [
                {{
                  ""to"": ""{to}"",
                  ""messageCount"": 1,
                  ""messageId"": ""somexternalMessageId0"",
                  ""status"": {{
                    ""groupId"": 1,
                    ""groupName"": ""PENDING"",
                    ""id"": 7,
                    ""name"": ""PENDING_ENROUTE"",
                    ""description"": ""Message sent to next instance""
                  }}
                }}
              ]
            }}";

            Dictionary<string, string> responseHeaders = new Dictionary<string, string>()
            {
                { "Server", "SMS,API" },
                { "X-Request-ID", "1608758729810312842" },
                { "Content-Type", "application/json; charset=utf-8" }
            };

            Multimap<string, string> parts = new Multimap<string, string>
            {
                { "from", from },
                { "to", to },
                { "subject", subject },
                { "text", mailText},
            };

            SetUpMultipartFormRequest(EMAIL_SEND_FULLY_FEATURED_ENDPOINT, parts, responseJson, httpCode);

            var emailApi = new EmailApi(this.configuration);

            var toList = new List<String>();
            toList.Add(to);

            try
            {
                // ACT
                var result = emailApi.SendEmail(from: from, to: toList, subject: subject, text: mailText);
            }
            catch (ApiException ex)
            {
                // ASSERT
                Assert.AreEqual(httpCode, ex.ErrorCode);
                Assert.AreEqual(responseJson, ex.ErrorContent);
                Assert.IsInstanceOfType(ex, typeof(ApiException));
                Assert.IsTrue(ex.Message.Contains(errorPhrase));
                Assert.IsTrue(ex.ErrorContent.ToString().Contains(messageId));
                Assert.IsTrue(ex.ErrorContent.ToString().Contains(errorText));
                Assert.IsTrue(responseHeaders.All(h => ex.Headers.ContainsKey(h.Key) && ex.Headers[h.Key].First().Equals(h.Value)));
            }
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void GetEmailDeliveryReportsResponseTest(int errorResponseIndex)
        {
            // ARRANGE
            int httpCode = DeliveryReportErrorResponses[errorResponseIndex].Item1;
            string messageId = DeliveryReportErrorResponses[errorResponseIndex].Item2;
            string errorPhrase = DeliveryReportErrorResponses[errorResponseIndex].Item3;
            string errorText = DeliveryReportErrorResponses[errorResponseIndex].Item4;

            string responseJson = $@"
            {{
                ""requestError"": {{
                    ""serviceException"": {{
                        ""messageId"": ""{messageId}"",
                        ""text"": ""{errorPhrase}"",
                        ""validationErrors"": ""{errorText}""
                    }}
                }}
            }}";

            Dictionary<string, string> responseHeaders = new Dictionary<string, string>()
            {
                { "Server", "SMS,API" },
                { "X-Request-ID", "1608758729810312842" },
                { "Content-Type", "application/json; charset=utf-8" }
            };

            SetUpGetRequest(EMAIL_LOGS_ENDPOINT, responseJson, httpCode);

            var emailApi = new EmailApi(this.configuration);

            try
            {
                // ACT
                var result = emailApi.GetEmailDeliveryReports(messageId: "MSG-TEST-123", bulkId: "BULK-1234", limit: 2);
            }
            catch (ApiException ex)
            {
                // ASSERT
                Assert.AreEqual(httpCode, ex.ErrorCode);
                Assert.AreEqual(responseJson, ex.ErrorContent);
                Assert.IsInstanceOfType(ex, typeof(ApiException));
                Assert.IsTrue(ex.Message.Contains(errorPhrase));
                Assert.IsTrue(ex.ErrorContent.ToString().Contains(messageId));
                Assert.IsTrue(ex.ErrorContent.ToString().Contains(errorText));
                Assert.IsTrue(responseHeaders.All(h => ex.Headers.ContainsKey(h.Key) && ex.Headers[h.Key].First().Equals(h.Value)));
            }
        }
    }
}
