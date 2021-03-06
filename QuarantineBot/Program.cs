﻿using System;
using System.Configuration;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using Discord;

namespace QuarantineBot
{
    class Program
    {
        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();


        private DiscordSocketClient _client;
        private CommandHandler _handler;
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            

            _client.Log += Log;

            var token = //"NzYwMj//kwNTY1ND//EzMjczNj//Mw.X3J5xA.i0//gwtP5UGxFbGbZQ4m6E4Uib-ic";//"NzYwMjkwNTY1NDEzMjczNjMw.X3J5xA.JiwJsWNC1e10n3X_jC-1HthBQCk";

            // var token = File.ReadAllText("token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();


            _handler = new CommandHandler(_client);

            await Task.Delay(-1);
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
