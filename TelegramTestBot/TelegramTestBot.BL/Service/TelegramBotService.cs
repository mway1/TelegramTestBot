using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramTestBot.BL.Service
{
    public class TelegramBotSettings : TelegramBotClient
    {
        protected readonly string token = "6237629540:AAErGQgxalLVu5W9RKenTd9UYGpx4tnqVNE";
        protected readonly TelegramBotClient _botClient;
        protected Action<string> _onMessage;

        public TelegramBotSettings(string token, Action<string> onMessage) : base(token)
        {
            _botClient = new TelegramBotClient(token);
            _onMessage = onMessage;
        }

        public void StartBot()
        {
            _botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(update.Message!.Chat.Id, "Hello," + update.Message.Chat.Username);
        }

        private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        // protected override async void OnMessage(Message message)
        //{
        //if (message.Type == MessageType.Text)
        //{
        //if (message.Text == "/start")
        //{
        //await _botClient.SendTextMessageAsync(message.Chat.Id, "Hello," + message.Chat.Username);
        //}
        //}
        //}
    }
}
