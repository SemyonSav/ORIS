using System.Diagnostics;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using Dobor.Interfaces;
using Dobor.Models;
using Dobor.ViewModels;
using Dobor.Repository;

namespace Dobor.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly ITagRepository _tagRepository;
        private readonly INewsRepository _newsRepository;

        public ShopController(ILogger<ShopController> logger, IProductRepository productRepository, IReviewRepository reviewRepository, ITagRepository tagRepository, INewsRepository newsRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _tagRepository = tagRepository;
            _newsRepository = newsRepository;
        }

        [HttpGet]
        [Route("Shop")]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllProducts();
            var tags = await _tagRepository.GetAllTags();
            var news = await _newsRepository.GetAllNews();
            List<NewsViewModel> newsViewModels = new List<NewsViewModel>();
            List<ProductViewModel> result = new List<ProductViewModel>();
            List<TagViewModel> tagViewModels = new List<TagViewModel>();

            foreach (var el in news)
            {
                var tag = await _tagRepository.GetTagById((int)el.TagId);
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
                newsViewModels.Add(newsViewModel);
            }

            foreach (var el in products)
            {
                var productViewModel = new ProductViewModel()
                {
                    Id = el.Id,
                    Category = el.Category,
                    Name = el.Name,
                    Description = el.Description,
                    OldPrice = el.OldPrice,
                    Price = el.Price,
                    PhotoPath = el.PhotoPath,
                    ShortDesc = el.ShortDesc
                };
                result.Add(productViewModel);
            }

            foreach (var tag in tags)
            {
                var tagViewModel = new TagViewModel()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Color = tag.Color
                };
                tagViewModels.Add(tagViewModel);
            }

            ViewData["Tags"] = tagViewModels;
            ViewData["News"] = newsViewModels;

            return View(result);
        }

        [Route("Shop/{productId}")]
        public async Task<IActionResult> Product(string productId)
        {
            var product = await _productRepository.GetProductById(int.Parse(productId));
            var reviews = await _reviewRepository.GetAllReviews();
            List<ReviewViewModel> reviewResult = new List<ReviewViewModel>();
            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                Category = product.Category,
                Name = product.Name,
                Description = product.Description,
                OldPrice = product.OldPrice,
                Price = product.Price,
                PhotoPath = product.PhotoPath,
                ShortDesc = product.ShortDesc
            };

            ViewData["Product"] = productViewModel;

            foreach (var el in reviews)
            {
                var reviewViewModel = new ReviewViewModel()
                {
                    Id = el.Id,
                    ProductId = el.ProductId,
                    AuthorName = el.AuthorName,
                    Content = el.Content,
                    Date = el.Date
                };

                if (reviewViewModel.ProductId == product.Id) reviewResult.Add(reviewViewModel);
            }

            return View(reviewResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}