using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using TelegramTestBot.BL.Models;
using TelegramTestBot.BL.Managers;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramTestBot.BL.Service
{
    public class TelegramBotService
    {
        protected readonly TelegramBotClient _botClient;
        protected Action<string> _onMessage;
        private Data _date = new Data();

        public TelegramBotService(Action<string> onMessage)
        {
            _botClient = new TelegramBotClient(_date!.GetHashedToken(0));
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
