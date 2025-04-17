using Discord.WebSocket;
using Discord;
using DiscordRecordSearcher.Models;
using DiscordRecordSearcher.Services;

namespace DiscordRecordSearcher
{
    public class DiscordRecordSearcher
    {
        private readonly DiscordSocketClient _client;
        private readonly string _botToken;

        public DiscordRecordSearcher(string botToken)
        {
            _botToken = botToken;
            _client = new DiscordSocketClient();
        }

        public async Task<List<MessageMatch>> SearchMessagesAsync(ulong channelId, string searchQuery)
        {
            var tcs = new TaskCompletionSource<bool>();

            _client.Ready += () =>
            {
                tcs.SetResult(true);
                return Task.CompletedTask;
            };

            await _client.LoginAsync(TokenType.Bot, _botToken);
            await _client.StartAsync();

            await tcs.Task;

            var searcher = new DiscordMessageSearcher(_client);
            var matches = await searcher.SearchMessagesAsync(channelId, searchQuery);

            await _client.LogoutAsync();
            await _client.StopAsync();

            return matches;
        }
    }
}
