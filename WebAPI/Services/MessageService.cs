using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Contracts;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class MessageService : IMessageService
    {
        private const string CacheKey = "ApplicationMessages";

        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;

        public MessageService(
            AppDbContext context,
            IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public string GetMessage(string code)
        {
            var messages = GetMessages();
            string message = $"Message not found for code: {code}";
            if (messages != null)
            {
                messages.TryGetValue(code, out message!);
            }
            return message!;
        }

        private Dictionary<string, string> GetMessages()
        {
            // COMMENTING TILL CHACHE INVALIDATION IMPLEMENTATION
            //if (_cache.TryGetValue(
            //    CacheKey,
            //    out Dictionary<string, string>? messages))
            //{
            //    return messages!;
            //}

            Dictionary<string, string> messages = _context.Messages
                        .AsNoTracking()
                        .Where(x => x.Status == true)
                        .ToDictionary(
                            x => x.Code,
                            x => x.Text);

            _cache.Set(
                CacheKey,
                messages,
                TimeSpan.FromHours(1));

            return messages;
        }
    }
}
