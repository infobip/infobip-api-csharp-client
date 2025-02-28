/*
 * Infobip Client API Libraries OpenAPI Specification
 * OpenAPI specification containing public endpoints supported in client API libraries.
 *
 * Contact: support@infobip.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     List of phones, emails and other information how a person can be contacted.
    /// </summary>
    [DataContract(Name = "FlowPersonContacts")]
    [JsonObject]
    public class FlowPersonContacts : IEquatable<FlowPersonContacts>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FlowPersonContacts" /> class.
        /// </summary>
        /// <param name="phone">A list of person&#39;s phone numbers. Max 100 numbers per person..</param>
        /// <param name="email">A list of person&#39;s email addresses. Max 100 emails per person..</param>
        /// <param name="push">List of person&#39;s push registrations..</param>
        /// <param name="facebook">A list of person&#39;s Messenger destinations..</param>
        /// <param name="line">A list of person&#39;s Line destinations..</param>
        /// <param name="viberBots">A list of person&#39;s Viber Bots destinations..</param>
        /// <param name="liveChat">A list of person&#39;s Live Chat destinations..</param>
        /// <param name="instagram">A list of person&#39;s Instagram destinations..</param>
        /// <param name="telegram">A list of person&#39;s Telegram destinations..</param>
        /// <param name="appleBusinessChat">A list of person&#39;s Apple Business Chat destinations..</param>
        /// <param name="webpush">A list of person&#39;s web push destinations..</param>
        /// <param name="instagramDm">A list of person&#39;s Instagram DM destinations..</param>
        /// <param name="kakaoSangdam">A list of person&#39;s Kakao Sangdam destinations..</param>
        public FlowPersonContacts(List<FlowPhoneContact> phone = default, List<FlowEmailContact> email = default,
            List<FlowPushContact> push = default, List<FlowCommonOttContact> facebook = default,
            List<FlowCommonOttContact> line = default, List<FlowCommonOttContact> viberBots = default,
            List<FlowCommonOttContact> liveChat = default, List<FlowCommonOttContact> instagram = default,
            List<FlowCommonOttContact> telegram = default, List<FlowCommonOttContact> appleBusinessChat = default,
            List<FlowCommonPushContact> webpush = default, List<FlowCommonOttContact> instagramDm = default,
            List<FlowCommonOttContact> kakaoSangdam = default)
        {
            Phone = phone;
            Email = email;
            Push = push;
            Facebook = facebook;
            Line = line;
            ViberBots = viberBots;
            LiveChat = liveChat;
            Instagram = instagram;
            Telegram = telegram;
            AppleBusinessChat = appleBusinessChat;
            Webpush = webpush;
            InstagramDm = instagramDm;
            KakaoSangdam = kakaoSangdam;
        }

        /// <summary>
        ///     A list of person&#39;s phone numbers. Max 100 numbers per person.
        /// </summary>
        /// <value>A list of person&#39;s phone numbers. Max 100 numbers per person.</value>
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public List<FlowPhoneContact> Phone { get; set; }

        /// <summary>
        ///     A list of person&#39;s email addresses. Max 100 emails per person.
        /// </summary>
        /// <value>A list of person&#39;s email addresses. Max 100 emails per person.</value>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public List<FlowEmailContact> Email { get; set; }

        /// <summary>
        ///     List of person&#39;s push registrations.
        /// </summary>
        /// <value>List of person&#39;s push registrations.</value>
        [DataMember(Name = "push", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "push", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("push")]
        public List<FlowPushContact> Push { get; set; }

        /// <summary>
        ///     A list of person&#39;s Messenger destinations.
        /// </summary>
        /// <value>A list of person&#39;s Messenger destinations.</value>
        [DataMember(Name = "facebook", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "facebook", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("facebook")]
        public List<FlowCommonOttContact> Facebook { get; set; }

        /// <summary>
        ///     A list of person&#39;s Line destinations.
        /// </summary>
        /// <value>A list of person&#39;s Line destinations.</value>
        [DataMember(Name = "line", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "line", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("line")]
        public List<FlowCommonOttContact> Line { get; set; }

        /// <summary>
        ///     A list of person&#39;s Viber Bots destinations.
        /// </summary>
        /// <value>A list of person&#39;s Viber Bots destinations.</value>
        [DataMember(Name = "viberBots", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "viberBots", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("viberBots")]
        public List<FlowCommonOttContact> ViberBots { get; set; }

        /// <summary>
        ///     A list of person&#39;s Live Chat destinations.
        /// </summary>
        /// <value>A list of person&#39;s Live Chat destinations.</value>
        [DataMember(Name = "liveChat", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "liveChat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("liveChat")]
        public List<FlowCommonOttContact> LiveChat { get; set; }

        /// <summary>
        ///     A list of person&#39;s Instagram destinations.
        /// </summary>
        /// <value>A list of person&#39;s Instagram destinations.</value>
        [DataMember(Name = "instagram", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "instagram", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("instagram")]
        public List<FlowCommonOttContact> Instagram { get; set; }

        /// <summary>
        ///     A list of person&#39;s Telegram destinations.
        /// </summary>
        /// <value>A list of person&#39;s Telegram destinations.</value>
        [DataMember(Name = "telegram", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "telegram", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("telegram")]
        public List<FlowCommonOttContact> Telegram { get; set; }

        /// <summary>
        ///     A list of person&#39;s Apple Business Chat destinations.
        /// </summary>
        /// <value>A list of person&#39;s Apple Business Chat destinations.</value>
        [DataMember(Name = "appleBusinessChat", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "appleBusinessChat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("appleBusinessChat")]
        public List<FlowCommonOttContact> AppleBusinessChat { get; set; }

        /// <summary>
        ///     A list of person&#39;s web push destinations.
        /// </summary>
        /// <value>A list of person&#39;s web push destinations.</value>
        [DataMember(Name = "webpush", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "webpush", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("webpush")]
        public List<FlowCommonPushContact> Webpush { get; set; }

        /// <summary>
        ///     A list of person&#39;s Instagram DM destinations.
        /// </summary>
        /// <value>A list of person&#39;s Instagram DM destinations.</value>
        [DataMember(Name = "instagramDm", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "instagramDm", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("instagramDm")]
        public List<FlowCommonOttContact> InstagramDm { get; set; }

        /// <summary>
        ///     A list of person&#39;s Kakao Sangdam destinations.
        /// </summary>
        /// <value>A list of person&#39;s Kakao Sangdam destinations.</value>
        [DataMember(Name = "kakaoSangdam", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "kakaoSangdam", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("kakaoSangdam")]
        public List<FlowCommonOttContact> KakaoSangdam { get; set; }

        /// <summary>
        ///     Returns true if FlowPersonContacts instances are equal
        /// </summary>
        /// <param name="input">Instance of FlowPersonContacts to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FlowPersonContacts input)
        {
            if (input == null)
                return false;

            return
                (
                    Phone == input.Phone ||
                    (Phone != null &&
                     input.Phone != null &&
                     Phone.SequenceEqual(input.Phone))
                ) &&
                (
                    Email == input.Email ||
                    (Email != null &&
                     input.Email != null &&
                     Email.SequenceEqual(input.Email))
                ) &&
                (
                    Push == input.Push ||
                    (Push != null &&
                     input.Push != null &&
                     Push.SequenceEqual(input.Push))
                ) &&
                (
                    Facebook == input.Facebook ||
                    (Facebook != null &&
                     input.Facebook != null &&
                     Facebook.SequenceEqual(input.Facebook))
                ) &&
                (
                    Line == input.Line ||
                    (Line != null &&
                     input.Line != null &&
                     Line.SequenceEqual(input.Line))
                ) &&
                (
                    ViberBots == input.ViberBots ||
                    (ViberBots != null &&
                     input.ViberBots != null &&
                     ViberBots.SequenceEqual(input.ViberBots))
                ) &&
                (
                    LiveChat == input.LiveChat ||
                    (LiveChat != null &&
                     input.LiveChat != null &&
                     LiveChat.SequenceEqual(input.LiveChat))
                ) &&
                (
                    Instagram == input.Instagram ||
                    (Instagram != null &&
                     input.Instagram != null &&
                     Instagram.SequenceEqual(input.Instagram))
                ) &&
                (
                    Telegram == input.Telegram ||
                    (Telegram != null &&
                     input.Telegram != null &&
                     Telegram.SequenceEqual(input.Telegram))
                ) &&
                (
                    AppleBusinessChat == input.AppleBusinessChat ||
                    (AppleBusinessChat != null &&
                     input.AppleBusinessChat != null &&
                     AppleBusinessChat.SequenceEqual(input.AppleBusinessChat))
                ) &&
                (
                    Webpush == input.Webpush ||
                    (Webpush != null &&
                     input.Webpush != null &&
                     Webpush.SequenceEqual(input.Webpush))
                ) &&
                (
                    InstagramDm == input.InstagramDm ||
                    (InstagramDm != null &&
                     input.InstagramDm != null &&
                     InstagramDm.SequenceEqual(input.InstagramDm))
                ) &&
                (
                    KakaoSangdam == input.KakaoSangdam ||
                    (KakaoSangdam != null &&
                     input.KakaoSangdam != null &&
                     KakaoSangdam.SequenceEqual(input.KakaoSangdam))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FlowPersonContacts {\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Push: ").Append(Push).Append("\n");
            sb.Append("  Facebook: ").Append(Facebook).Append("\n");
            sb.Append("  Line: ").Append(Line).Append("\n");
            sb.Append("  ViberBots: ").Append(ViberBots).Append("\n");
            sb.Append("  LiveChat: ").Append(LiveChat).Append("\n");
            sb.Append("  Instagram: ").Append(Instagram).Append("\n");
            sb.Append("  Telegram: ").Append(Telegram).Append("\n");
            sb.Append("  AppleBusinessChat: ").Append(AppleBusinessChat).Append("\n");
            sb.Append("  Webpush: ").Append(Webpush).Append("\n");
            sb.Append("  InstagramDm: ").Append(InstagramDm).Append("\n");
            sb.Append("  KakaoSangdam: ").Append(KakaoSangdam).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as FlowPersonContacts);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (Phone != null)
                    hashCode = hashCode * 59 + Phone.GetHashCode();
                if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                if (Push != null)
                    hashCode = hashCode * 59 + Push.GetHashCode();
                if (Facebook != null)
                    hashCode = hashCode * 59 + Facebook.GetHashCode();
                if (Line != null)
                    hashCode = hashCode * 59 + Line.GetHashCode();
                if (ViberBots != null)
                    hashCode = hashCode * 59 + ViberBots.GetHashCode();
                if (LiveChat != null)
                    hashCode = hashCode * 59 + LiveChat.GetHashCode();
                if (Instagram != null)
                    hashCode = hashCode * 59 + Instagram.GetHashCode();
                if (Telegram != null)
                    hashCode = hashCode * 59 + Telegram.GetHashCode();
                if (AppleBusinessChat != null)
                    hashCode = hashCode * 59 + AppleBusinessChat.GetHashCode();
                if (Webpush != null)
                    hashCode = hashCode * 59 + Webpush.GetHashCode();
                if (InstagramDm != null)
                    hashCode = hashCode * 59 + InstagramDm.GetHashCode();
                if (KakaoSangdam != null)
                    hashCode = hashCode * 59 + KakaoSangdam.GetHashCode();
                return hashCode;
            }
        }
    }
}