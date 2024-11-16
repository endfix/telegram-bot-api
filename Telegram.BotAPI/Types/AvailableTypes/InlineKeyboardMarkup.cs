using System;
using System.Collections.Generic;
using System.Linq;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class InlineKeyboardMarkup : ReplyMarkup
{
    public List<List<InlineKeyboardButton>> InlineKeyboard { get; set; } = [];

    public void AddRow(InlineKeyboardButton button)
    {
        InlineKeyboard.Add(
        [
            button
        ]);
    }

    public void AddCell(InlineKeyboardButton button)
    {
        if (!InlineKeyboard.Any())
        {
            throw new ArgumentException("Need to add row!");
        }

        InlineKeyboard.Last().Add(button);
    }
}
