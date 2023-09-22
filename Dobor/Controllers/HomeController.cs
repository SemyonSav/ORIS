using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dobor.Interfaces;
using Dobor.Models;
using Dobor.ViewModels;

namespace Dobor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsRepository _newsRepository;
        private readonly ITagRepository _tagRepository;

        public HomeController(ILogger<HomeController> logger, INewsRepository newsRepository, ITagRepository tagRepository)
        {
            _logger = logger;
            _newsRepository = newsRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsRepository.GetAllNews();
            List<NewsViewModel> result = new List<NewsViewModel>();
            var tags = await _tagRepository.GetAllTags();
            List<TagViewModel> tagViewModels = new List<TagViewModel>();

            foreach (var el in news)
            {
                var tag = await _tagRepository.GetTagById((int) el.TagId);
                TagViewModel tagViewModel = new TagViewModel()
                {
                    Id = tag.Id,
                    Color = tag.Color,
                    Name = tag.Name
                };

                var newsViewModel = new NewsViewModel(tagViewModel)
                {
                    Id = el.Id,
                    Category = el.Category,
                    Title = el.Title,
                    Author = el.Author,
                    CreatedDate = el.CreatedDate,
                    Views = el.Views,
                    Description = el.Description,
                    PhotoPath = el.PhotoPath,
                    TagId = el.TagId
                };
                result.Add(newsViewModel);
            }

            foreach (var el in tags)
            {
                var tagViewModel = new TagViewModel()
                {
                    Id = el.Id,
                    Name = el.Name,
                    Color = el.Color
                };
                tagViewModels.Add(tagViewModel);
            }

            ViewData["Tags"] = tagViewModels;

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}