using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Microservice.Value.Web.Api.DataAnnotations
{
    /// <summary>
    /// The class provides to check media type for supporting.
    /// </summary>
    public class FileNameAttribute : ValidationAttribute
    {
        private static IDictionary<string, IList<string>> SUPPORTED_EXTENSIONS_AND_MIME_TYPES => new Dictionary<string, IList<string>>()
        {
            { ".avi", new List<string>() { "video/avi", "video/msvideo", "video/x-msvideo" } },
            { ".mp4", new List<string>() { "video/mp4" } },
            { ".wmv", new List<string>() { "video/x-ms-wmv" } },
            { ".jpg", new List<string>() { "image/jpeg" } },
            { ".jpeg", new List<string>() { "image/jpeg" } },
            { ".png", new List<string>() { "image/png" } }
        };

        private readonly IList<string> _mediaExtensions = SUPPORTED_EXTENSIONS_AND_MIME_TYPES.Keys.ToList();

        /// <summary>
        /// Determines whether the specified value is valid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// true if the specified value is valid; otherwise, false.
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value == null
                || _mediaExtensions.Any(mExt => value.ToString().EndsWith(mExt, true, CultureInfo.InvariantCulture)))
            {
                return true;
            }

            return false;
        }
    }
}
