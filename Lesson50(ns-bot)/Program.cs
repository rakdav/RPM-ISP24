using Microsoft.VisualBasic;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Runtime.InteropServices.JavaScript.JSType;

//var bot = new TelegramBotClient("7991441868:AAFpXgfQHpJ8zis0u2s0GOr7R9Sd4tmN9wE", cancellationToken: cts.Token);
var token = "7991441868:AAFpXgfQHpJ8zis0u2s0GOr7R9Sd4tmN9wE";
using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient(token, cancellationToken: cts.Token);
var me = await bot.GetMe();
await bot.DeleteWebhook();
await bot.DropPendingUpdates();
bot.OnError += OnError;
bot.OnMessage += OnMessage;
bot.OnUpdate += OnUpdate;

Console.WriteLine($"@{me.Username} is running... Press Escape to terminate");
while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
cts.Cancel(); // stop the bot
async Task OnError(Exception exception, HandleErrorSource source)
{
    Console.WriteLine(exception);
    await Task.Delay(2000, cts.Token);
}
async Task OnMessage(Message msg, UpdateType type)
{
    if (msg.Text is not { } text)
    {
        Console.WriteLine($"Received a message of type {msg.Type}");
    }
    else if (text.StartsWith("/"))
    {
        var space = text.IndexOf(' ');
        if (space < 0) space = text.Length;
        var command = text[..space].ToLower();
        if (command.LastIndexOf('@') is > 0 and int at)
            if (command[(at + 1)..].Equals(me.Username, StringComparison.OrdinalIgnoreCase))
                command = command[..at];
            else return;
        await OnCommand(command, text[space..].TrimStart(), msg);
    }
    else await OnTextMessage(msg);
}
async Task OnTextMessage(Message msg) 
{
    Console.WriteLine($"Received command:{msg.Text} in {msg.Chat}");
    await OnCommand("/start", "", msg);
}
async Task OnCommand(string command, string args, Message msg)
{
    Console.WriteLine($"Received command:{command} in {args}");
    switch (command)
    {
        case "/start":
            await bot.SendMessage(msg.Chat, """
                <b><u>Bot menu</u></b>:
                /photo [url]    - send a photo <i>(optionally from an <a href="https://picsum.photos/310/200.jpg">url</a>)</i>
                /inline_buttons - send inline buttons
                /keyboard       - send keyboard buttons
                /remove         - remove keyboard buttons
                /poll           - send a poll
                /reaction       - send a reaction
                """, parseMode: ParseMode.Html, linkPreviewOptions: true,
                replyMarkup: new ReplyKeyboardRemove());
            break;
        case "/photo":
            if (args.StartsWith("http"))
                await bot.SendPhoto(msg.Chat,args,caption:"Source:"+args);
            else
            {
                await bot.SendChatAction(msg.Chat,ChatAction.UploadPhoto);
                await Task.Delay(2000);
                await using var filestream = new FileStream("bot.gif", FileMode.Open,
                    FileAccess.Read);
                await bot.SendPhoto(msg.Chat, filestream, caption: "Read https://telegrambots.github.io/book/");
            }
            break;
        case "/inline_buttons":
            await bot.SendMessage(msg.Chat, "Inline buttons:", replyMarkup: new InlineKeyboardButton[][] {
                ["1.1", "1.2", "1.3"],
                [("WithCallbackData", "CallbackData"), ("WithUrl", "https://github.com/TelegramBots/Telegram.Bot")]
            });
            break;
        case "/keyboard":
            await bot.SendMessage(msg.Chat, "Keyboard buttons:", replyMarkup: new[] { "MENU", "INFO", "LANGUAGE" });
            break;
        case "/remove":
            await bot.SendMessage(msg.Chat, "Removing keyboard", replyMarkup: new ReplyKeyboardRemove());
            break;
        case "/poll":
            await bot.SendPoll(msg.Chat, "Question", ["Option 0", "Option 1", "Option 2"], isAnonymous: false, allowsMultipleAnswers: true);
            break;
        case "/reaction":
            await bot.SetMessageReaction(msg.Chat, msg.Id, ["❤"], false);
            break;
    }
}
async Task OnUpdate(Update update)
{
    switch (update)
    {
        case { CallbackQuery: { } callbackQuery }: await OnCallbackQuery(callbackQuery); break;
        case { PollAnswer: { } pollAnswer }: await OnPollAnswer(pollAnswer); break;
        default: Console.WriteLine($"Received unhandled update {update.Type}"); break;
    }
    ;
}
async Task OnCallbackQuery(CallbackQuery callbackQuery)
{
    await bot.AnswerCallbackQuery(callbackQuery.Id, $"You selected {callbackQuery.Data}");
    await bot.SendMessage(callbackQuery.Message!.Chat, $"Received callback from inline button {callbackQuery.Data}");
}
async Task OnPollAnswer(PollAnswer pollAnswer)
{
    if (pollAnswer.User != null)
        await bot.SendMessage(pollAnswer.User.Id, $"You voted for option(s) id [{string.Join(',', pollAnswer.OptionIds)}]");
}