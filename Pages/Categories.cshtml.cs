using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyRazorApp.Pages
{
    public class Categories : PageModel
    {
        public List<Category> CategoriesList { get; set; } = new List<Category>();
        private readonly ILogger<Categories> _logger;

        public Categories(ILogger<Categories> logger)
        {
            _logger = logger;
        }

        public void OnGet(int skip = 0, int take = 25)
        {
            var temp = new List<Category>();
            for(var i = 0; i <= 100; i++) {
                temp.Add(new Category(i, $"Categoria {i}", i * 18.95M));
            }

            CategoriesList = temp
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }

    public record Category(int Id, string Title, decimal Price);
}