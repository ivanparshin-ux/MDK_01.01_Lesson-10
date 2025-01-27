using System;

public interface IButton
{
    void Render();
}

public interface IRadioButton
{
    void Select();
}

public interface ITextbox
{
    void InputText(string text);
}

public interface ILabel
{
    void DisplayText();
}

public interface IGUIFactory
{
    IButton CreateButton();
    IRadioButton CreateRadioButton();
    ITextbox CreateTextbox();
    ILabel CreateLabel();
}

public class WinButton : IButton
{
    public void Render() => Console.WriteLine("Отрисована кнопка в стиле Windows");
}

public class WinRadioButton : IRadioButton
{
    public void Select() => Console.WriteLine("Выбрана радио-кнопка Windows");
}

public class WinTextbox : ITextbox
{
    public void InputText(string text) => Console.WriteLine($"Windows: Введён текст: {text}");
}

public class WinLabel : ILabel
{
    public void DisplayText() => Console.WriteLine("Метка Windows: Привет, мир!");
}

public class WinFactory : IGUIFactory
{
    public IButton CreateButton() => new WinButton();
    public IRadioButton CreateRadioButton() => new WinRadioButton();
    public ITextbox CreateTextbox() => new WinTextbox();
    public ILabel CreateLabel() => new WinLabel();
}

public class MacButton : IButton
{
    public void Render() => Console.WriteLine("Отрисована кнопка в стиле macOS");
}

public class MacRadioButton : IRadioButton
{
    public void Select() => Console.WriteLine("Выбрана радио-кнопка macOS");
}

public class MacTextbox : ITextbox
{
    public void InputText(string text) => Console.WriteLine($"macOS: Введён текст: {text}");
}

public class MacLabel : ILabel
{
    public void DisplayText() => Console.WriteLine("Метка macOS: Hello, World!");
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public IRadioButton CreateRadioButton() => new MacRadioButton();
    public ITextbox CreateTextbox() => new MacTextbox();
    public ILabel CreateLabel() => new MacLabel();
}

public class Application
{
    private readonly IGUIFactory _factory;

    public Application(IGUIFactory factory)
    {
        _factory = factory;
    }

    public void CreateUI()
    {
        var button = _factory.CreateButton();
        var radio = _factory.CreateRadioButton();
        var textbox = _factory.CreateTextbox();
        var label = _factory.CreateLabel();

        button.Render();
        radio.Select();
        textbox.InputText("Тестовый текст");
        label.DisplayText();
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Запуск на Windows:");
        var winApp = new Application(new WinFactory());
        winApp.CreateUI();

        Console.WriteLine("\nЗапуск на macOS:");
        var macApp = new Application(new MacFactory());
        macApp.CreateUI();
    }
}