using Discord.WebSocket;
using Discord;
using DiscordRecordSearcher.Models;

namespace DiscordRecordSearcher.Services
{
    public class DiscordMessageSearcher
    {
        private readonly DiscordSocketClient _client;

        public DiscordMessageSearcher(DiscordSocketClient client)
        {
            _client = client;
        }

        public async Task<List<MessageMatch>> SearchMessagesAsync(ulong channelId, string searchQuery)
        {
            var matches = new List<MessageMatch>();

            var channel = _client.GetChannel(channelId) as IMessageChannel;
            if (channel == null)
            {
                throw new ArgumentException("Channel not found or is not a text channel.");
            }

            var messages = await channel.GetMessagesAsync(limit: 100).FlattenAsync();

            foreach (var message in messages)
            {
                if (message.Content.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    matches.Add(new MessageMatch
                    {
                        Content = message.Content,
                        Date = message.Timestamp.DateTime,
                        User = message.Author.Username
                    });
                }
            }

            return matches;
        }
    }
}
