using System.Text.RegularExpressions;
using System;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{

    public interface IImageSelectorService
    {
        Task<string> GetImageUrlAsync(string userId); 
        
    }

    public class ImageSelectorService : IImageSelectorService
    {
        private readonly DataContext _dbContext;
        private readonly ILogger<ImageSelectorService> _logger;

        public ImageSelectorService(DataContext dbContext, ILogger<ImageSelectorService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
               

        public async Task<string> GetImageUrlAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                _logger.LogWarning("User ID is empty or null.");
                // Rule 5: Default if no other conditions are met
                return "https://api.dicebear.com/8.x/pixelart/png?seed=default&size=150";
            }


            // Extract the last digit of the user identifier
            char lastChar = userId[^1];// Last character of the identifier
            string imageUrl = null;

            if (char.IsDigit(lastChar))
            {
                int lastDigit = int.Parse(lastChar.ToString());
                // Rule 1: Last character is [6, 7, 8, 9]
                if (lastDigit >= 6 && lastDigit <= 9)
                {
                    imageUrl = $"https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/{lastDigit}";
                }
                // Rule 2: Last character is [1, 2, 3, 4, 5]
                else if (lastDigit >= 1 && lastDigit <= 5)
                {
                    var image = await _dbContext.Images.FindAsync(lastDigit);
                    imageUrl = image?.Url;
                }
            }

            // Rule 3: Contains a vowel
            if (imageUrl == null && Regex.IsMatch(userId, "[aeiou]", RegexOptions.IgnoreCase))
            {
                imageUrl = "https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150";
            }
            // Rule 4: Contains a non-alphanumeric character
            else if (imageUrl == null && Regex.IsMatch(userId, @"\W"))
            {
                var random = new Random();
                int randomSeed = random.Next(1, 6);
                imageUrl = $"https://api.dicebear.com/8.x/pixel-art/png?seed={randomSeed}&size=150";
            }

            // Rule 5: Default if no other conditions are met
            imageUrl ??= "https://api.dicebear.com/8.x/pixelart/png?seed=default&size=150";

            _logger.LogInformation("Generated image URL: {ImageUrl}", imageUrl);
            return imageUrl;
        }       
    }
}
