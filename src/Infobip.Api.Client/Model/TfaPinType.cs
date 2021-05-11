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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     Defines TfaPinType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TfaPinType
    {
        /// <summary>
        ///     Enum Numeric for value: NUMERIC
        /// </summary>
        [EnumMember(Value = "NUMERIC")] Numeric = 1,

        /// <summary>
        ///     Enum Alpha for value: ALPHA
        /// </summary>
        [EnumMember(Value = "ALPHA")] Alpha = 2,

        /// <summary>
        ///     Enum Hex for value: HEX
        /// </summary>
        [EnumMember(Value = "HEX")] Hex = 3,

        /// <summary>
        ///     Enum Alphanumeric for value: ALPHANUMERIC
        /// </summary>
        [EnumMember(Value = "ALPHANUMERIC")] Alphanumeric = 4
    }
}