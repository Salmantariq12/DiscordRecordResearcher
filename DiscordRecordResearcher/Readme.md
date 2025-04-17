📚 README for Discord Record Searcher

📝 Project Overview
    This project is designed to help you interact with Discord via the Bot API to:
    Search for messages in a Discord channel.
    Store messages as the bot listens in the channel.
    Return search results based on a query.

🚀 Setup Instructions
1️: Create a Discord Bot
    Step 1: Go to the Discord Developer Portal
        Open Discord Developer Portal.
        Log in with your Discord account.
    Step 2: Create a New Application
        Click the "New Application" button.
        Give your application a name (e.g., MyBot).
        After creating, select your application.
    Step 3: Add a Bot to the Application
        In the left sidebar, navigate to the "Bot" tab.
        Click "Add Bot" and confirm by clicking "Yes, do it!".
    Step 4: Get Your Bot Token
        In the Bot tab, you’ll see a Bot Token. Click "Copy" to copy the token to your clipboard.
        Important: Never share your bot token with anyone, as it provides full access to your bot.
2️: Getting the Channel ID
    Step 1: Enable Developer Mode in Discord
        Open Discord and go to User Settings (the gear icon at the bottom left).
        Under App Settings, go to "Advanced".
        Toggle "Developer Mode" on.
    Step 2: Get the Channel ID
        Go to the server and channel you want to get the ID from.
        Right-click the channel name in the channel list.
        Select "Copy ID" to copy the channel ID to your clipboard.
    Step 3: Invite Your Bot to the Server (Optional)
        In the Discord Developer Portal, go to the "OAuth2" tab.
        Under OAuth2 → URL Generator, select "bot" in the scopes section.
        Under Bot Permissions, select "Read Messages", "Read Message History", "Send Messages".
        Copy the generated URL and open it in a browser.
        Follow the steps to invite your bot to the server.

🧑‍💻 How to Use DiscordRecordSearcher
Once you have your bot token and channel ID, you can interact with your bot using the DiscordRecordSearcher class.

var botToken = "YOUR_BOT_TOKEN";  // Replace with your bot token
var service = new DiscordRecordSearcher(botToken);

ulong channelId = 123456789012345678;  // Replace with your channel ID
string query = "search text";    // Replace with the text you want to search for

// Fetch all messages from the channel
var results = await service.GetMessagesAsync(channelId);

// Search messages in the channel for a specific string
var searchResults = await service.SearchMessagesAsync(channelId, query);
