using System;
using System.IO;
using System.Threading.Tasks;
using VideoLibrary;

namespace HW_18
{
    internal class DownloadVideo
    {
        public class DownloadVideoCommand : ICommand
        {
            private readonly string _videoUrl;
            private readonly string _outputFilePath;

            public DownloadVideoCommand(string videoUrl, string outputFilePath)
            {
                _videoUrl = videoUrl;
                _outputFilePath = outputFilePath;
            }

            public async Task ExecuteAsync()
            {
                try
                {
                    Console.WriteLine("Скачивание началось...");

                    // Создаем клиент YouTube
                    var youtube = YouTube.Default;

                    Console.WriteLine("Получаем видео с URL: " + _videoUrl);
                    var video = await youtube.GetVideoAsync(_videoUrl);

                    Console.WriteLine("Видео получено, скачивание начинается...");

                    // Получаем байты видео
                    var videoBytes = video.GetBytes();

                    Console.WriteLine("Записываем файл в: " + _outputFilePath);
                    // Сохраняем видео в файл
                    await File.WriteAllBytesAsync(_outputFilePath, videoBytes);

                    Console.WriteLine("Видео успешно скачано в файл: " + _outputFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при скачивании видео: " + ex.Message);
                }
            }
        }
    }
}
