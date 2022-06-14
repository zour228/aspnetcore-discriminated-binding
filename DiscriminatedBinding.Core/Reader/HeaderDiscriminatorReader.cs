using System.Linq;
using System.Threading.Tasks;
using DiscriminatedBinding.Core.Utility;
using Microsoft.AspNetCore.Http;

namespace DiscriminatedBinding.Core.Reader
{
    public sealed class HeaderDiscriminatorReader : IDiscriminatorReader
    {
        public Task<string?> ReadDiscriminatorAsync(string property, HttpContext context)
        {
            var headers = context.Request.Headers;

            return Task.FromResult(
                headers.TryGetValue(property, out var discriminatorValue)
                    ? discriminatorValue.ToString()
                    : null
            );
        }
    }
}
