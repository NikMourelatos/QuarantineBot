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

        // Retrieve client and CommandService instance via ctor
        public CommandHandler(DiscordSocketClient client)//, CommandService service)
        {
           
            _client = client;

            _service = new CommandService();

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

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (message.HasCharPrefix('^', ref argPos)) {
                // var result = await _service.ExecuteAsync(context,argPos,_service);

                //if ((!result.IsSuccess) && (result.Error != CommandError.UnknownCommand))
                //{
                   await context.Channel.SendMessageAsync("Trey is dumb");
                //}
            }
                
                //return;

            
            await message.Channel.SendMessageAsync("Trey is Dumb");

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            //await _commands.ExecuteAsync(
              //  context: context,
                //argPos: argPos,
                //services: null);
        }
    }
}
