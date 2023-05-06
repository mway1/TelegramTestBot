﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private DataService _dateService = new DataService();
        private StudentModelManager _studentModelManager = new StudentModelManager();

        public TelegramBotService(Action<string> onMessage)
        {
            _botClient = new TelegramBotClient(_dateService.token);
            _onMessage = onMessage;
        }

        public void StartBot(string pass)
        {
            if (pass == "12345")
            _botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
        }

        private async void RegisterOfStudent()
        {
            
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message!.Text == "/start")
            {

                await botClient.SendTextMessageAsync(update.Message!.Chat.Id, "Hello, " + update.Message.Chat.Username);
            }
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