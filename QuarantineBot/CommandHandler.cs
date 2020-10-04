using System;
using System.Reflection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace QuarantineBot
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _service;
        public TicTacToeManager _ticTacToeManager;

        // Retrieve client and CommandService instance via ctor
        public CommandHandler(DiscordSocketClient client)//, CommandService service)
        {

            _client = client;

            _service = new CommandService();

            _ticTacToeManager = new TicTacToeManager();

            //_service.AddModuleAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;

        }


        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Don't process the command if it was a system message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(_client, message);


            if (message.Author.Id == _client.CurrentUser.Id || message.Author.IsBot) return;

            if (!(message.HasCharPrefix('^', ref argPos) ||
            message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
            message.Author.IsBot)
                return;
            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            //if (message.HasCharPrefix('^', ref argPos)) {
            Console.WriteLine(message.Content);
                // var result = await _service.ExecuteAsync(context,argPos,_service);
            if (message.Content == "^Asuna")
            {
                await context.Channel.SendFileAsync("asuna.jpeg", "ASUNA KUNNN");
            }
            else if(message.Content == "^Ping")
            {
                await context.Channel.SendMessageAsync("Pong");
            }
            else if(message.Content == "^Yumeko") {
                await context.Channel.SendFileAsync("yumeko.jpg");
            }
            else if (message.Content.StartsWith("^ttt"))
            {
                string output = _ticTacToeManager.handleInput(message);
                await context.Channel.SendMessageAsync(output);
            }

            else
            {

                    //if ((!result.IsSuccess) && (result.Error != CommandError.UnknownCommand))
                    //{

                await context.Channel.SendMessageAsync("Trey is dumb");
                    //}

            }
            //}



            //await message.Channel.SendMessageAsync("Trey is Dumb");


            //await _commands.ExecuteAsync(
              //  context: context,
                //argPos: argPos,
                //services: null);
        }
    }
}
