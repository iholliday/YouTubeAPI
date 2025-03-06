using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Set up API key
        string apiKey = Environment.GetEnvironmentVariable("YOUTUBE_API_KEY");

        // Create a YouTube service object
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = apiKey,
            ApplicationName = "YouTubeDataAPIExample"
        });

        // Request details of a video by ID
        var videoRequest = youtubeService.Videos.List("snippet,contentDetails,statistics");
        videoRequest.Id = "YOUR_VIDEO_ID";
        var videoResponse = videoRequest.Execute();

        // Print video details
        foreach (var video in videoResponse.Items)
        {
            Console.WriteLine($"Title: {video.Snippet.Title}");
            Console.WriteLine($"Description: {video.Snippet.Description}");
            Console.WriteLine($"Published At: {video.Snippet.PublishedAt}");
            Console.WriteLine($"View Count: {video.Statistics.ViewCount}");
            Console.WriteLine($"Like Count: {video.Statistics.LikeCount}");
            Console.WriteLine($"Dislike Count: {video.Statistics.DislikeCount}");
            Console.WriteLine($"Comment Count: {video.Statistics.CommentCount}");
        }
    }
}