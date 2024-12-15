using System;
using System.Threading.Tasks;
using VideoLibrary;  
using static HW_18.InfoAboutVideo;
using static HW_18.DownloadVideo;
using HW_18;

// Интерфейс команды
public interface ICommand
{
    Task ExecuteAsync();
}

// Инвокер для выполнения команд
public class CommandInvoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public async Task ExecuteCommandAsync()
    {
        if (_command != null)
        {
            try
            {
                await _command.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении команды: " + ex.Message);
            }
        }
    }
}

// Главный класс программы
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Введите ссылку на YouTube-видео:");
        string videoUrl = Console.ReadLine();

        // Проверка ссылки
        if (string.IsNullOrWhiteSpace(videoUrl))
        {
            Console.WriteLine("Ссылка на видео не может быть пустой.");
            return;
        }

        // Запрос на скачивание видео
        Console.WriteLine("Введите путь для сохранения видео (например, video.mp4):");
        string outputPath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(outputPath))
        {
            Console.WriteLine("Путь сохранения не может быть пустым.");
            return;
        }

        var downloadCommand = new DownloadVideo.DownloadVideoCommand(videoUrl, outputPath);

        // Выполнение команды для скачивания видео
        var invoker = new CommandInvoker();
        invoker.SetCommand(downloadCommand);
        await invoker.ExecuteCommandAsync();

        Console.WriteLine("Работа завершена.");
    }
}

