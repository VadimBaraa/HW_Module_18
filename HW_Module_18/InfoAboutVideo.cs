using System;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoLibrary;  // Подключаем библиотеку

namespace HW_18
{
    internal class InfoAboutVideo
    {
        public class GetVideoInfoCommand : ICommand
        {
            private readonly YouTube _youtubeClient;
            private readonly string _videoUrl;

            public GetVideoInfoCommand(YouTube youtubeClient, string videoUrl)
            {
                _youtubeClient = youtubeClient;
                _videoUrl = videoUrl;
            }

            public async Task ExecuteAsync()
            {
                try
                {
                    // Получаем видео с YouTube
                    var video = await _youtubeClient.GetVideoAsync(_videoUrl);  // Используем библиотеку VideoLibrary
                    Console.WriteLine("Название видео: " + video.Title);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при получении информации о видео: " + ex.Message);
                }
            }
        }
    }
}
