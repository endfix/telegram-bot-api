using System;
using System.Collections.Generic;
using System.Linq;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class ReplyKeyboardMarkup : ReplyMarkup
{
    public List<List<KeyboardButton>> Keyboard { get; set; } = [];

    public bool IsPersistent { get; set; }

    public bool ResizeKeyboard { get; set; }

    public bool OneTimeKeyboard { get; set; }

    public string InputFieldPlaceholder { get; set; } = string.Empty;

    public bool Selective { get; set; }

    public void AddRow(KeyboardButton button)
    {
        Keyboard.Add(
        [
            button
        ]);
    }

    public void AddCell(KeyboardButton button)
    {
        if (!Keyboard.Any())
        {
            throw new Exception("Need to add row!");
        }

        Keyboard.Last().Add(button);
    }
}
