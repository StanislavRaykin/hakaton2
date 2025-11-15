using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace hakaton2.Controllers
{
    // Simple MVC controller to serve the blog listing and single-post views.
    // It uses an in-memory sample list — replace with a DB or service later.
    public class BlogController : Controller
    {
        private static readonly List<BlogPost> _posts = new()
        {
            new BlogPost
            {
                Title = "Как да подготвяте пластмасата за рециклиране",
                Excerpt = "Няколко лесни стъпки, които гарантират, че вашите пластмасови опаковки ще бъдат правилно рециклирани.",
                Slug = "podgotovka-plastmasa",
                Published = DateTime.UtcNow.AddDays(-7),
                ImageUrl = "/images/blog/plastic.jpg",
                Category = "Съвети",
                ContentHtml = "<p>Примерно съдържание за подготовка на пластмасата...</p>"
            },
            new BlogPost
            {
                Title = "Историята на една успешна общностна кампания",
                Excerpt = "Как квартална инициатива събра хората и увеличи събирането на рециклируеми материали с 40%.",
                Slug = "obshtnost-kampania",
                Published = DateTime.UtcNow.AddDays(-21),
                ImageUrl = "/images/blog/community.jpg",
                Category = "Кампании",
                ContentHtml = "<p>Примерно съдържание за общностна кампания...</p>"
            },
            new BlogPost
            {
                Title = "5 начина да повишите своите EcoPoints",
                Excerpt = "Практични съвети за събиране на повече точки и отключване на награди.",
                Slug = "5-nachina-ecopoints",
                Published = DateTime.UtcNow.AddDays(-30),
                ImageUrl = "/images/blog/tips.jpg",
                Category = "Съвети",
                ContentHtml = "<p>Примерно съдържание с 5 съвета...</p>"
            }
        };

        // GET: /Blog or /Blog?category=...&q=...
        public IActionResult Index(string category = null, string q = null)
        {
            var results = _posts.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                results = results.Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(q))
            {
                results = results.Where(p =>
                    (p.Title?.Contains(q, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.Excerpt?.Contains(q, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.ContentHtml?.Contains(q, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            // The Blog view expects an IEnumerable<dynamic> — pass the typed list.
            return View("Blog", results.ToList());
        }

        // GET: /Blog/Post/{slug}  or /Blog/Post?slug=...
        public IActionResult Post(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug)) return RedirectToAction(nameof(Index));

            var post = _posts.FirstOrDefault(p => string.Equals(p.Slug, slug, StringComparison.OrdinalIgnoreCase));
            if (post == null) return NotFound();

            // Return a view named "Post" (create Views/Blog/Post.cshtml) or adapt as needed.
            return View("Post", post);
        }

        // Simple create form (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Simple create handler (POST) — in-memory only for demo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogPost model)
        {
            if (!ModelState.IsValid) return View(model);

            model.Published = DateTime.UtcNow;
            if (string.IsNullOrWhiteSpace(model.Slug))
            {
                model.Slug = GenerateSlug(model.Title);
            }

            _posts.Insert(0, model);
            return RedirectToAction(nameof(Index));
        }

        private static string GenerateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return Guid.NewGuid().ToString("n");
            var parts = title.ToLowerInvariant()
                             .Replace("ъ", "a").Replace("ь", "")
                             .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-')
                             .Aggregate(new System.Text.StringBuilder(), (sb, c) =>
                             {
                                 sb.Append(c);
                                 return sb;
                             })
                             .ToString()
                             .Split(new[] { ' ', '/', '\\', '?', '&' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join("-", parts);
        }

        // Simple DTO / model used by this controller (move to Models folder if you prefer)
        public class BlogPost
        {
            public string Title { get; set; } = "";
            public string Excerpt { get; set; } = "";
            public string Slug { get; set; } = "";
            public DateTime Published { get; set; } = DateTime.UtcNow;
            public string ImageUrl { get; set; } = "/images/blog/default.jpg";
            public string Category { get; set; } = "Общо";
            public string ContentHtml { get; set; } = "";
        }
    }
}