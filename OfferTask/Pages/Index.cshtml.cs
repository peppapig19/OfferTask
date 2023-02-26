using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfferTask.Data;
using OfferTask.Models;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace OfferTask.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Offer? Offer { get; set; }

		readonly ApplicationDbContext _context;

		public IndexModel(ApplicationDbContext context)
		{
			_context = context;
		}

        public void OnGet()
        {
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			List<Offer> offers = new();
			XmlDocument xDoc = new();
			xDoc.Load("http://partner.market.yandex.ru/pages/help/YML.xml");

			XmlElement? xRoot = xDoc.DocumentElement;
			if (xRoot == null) return;

			XmlNodeList? xNodes = xRoot.SelectNodes("shop/offers/offer");
			if (xNodes == null) return;

			foreach (XmlNode node in xNodes)
			{
				Offer offer = new();
				offer.Id = Convert.ToInt32(node.Attributes?["id"]?.InnerText);
				offer.IsAvailable = Convert.ToBoolean(node.Attributes?["available"]?.InnerText);
				offer.Url = node["url"]?.InnerText;
				offer.Picture = node["picture"]?.InnerText;
				offer.Artist = node["artist"]?.InnerText;
				offer.Title = node["title"]?.InnerText;
				offer.Year = Convert.ToInt32(node["year"]?.InnerText);
				offer.Description = node["description"]?.InnerText;

				offers.Add(offer);
			}

			TempData["Offers"] = JsonSerializer.Serialize(offers);
		}

		public IActionResult OnPost()
        {
			string? data = (string?)TempData.Peek("Offers");
			if (data == null) return NotFound();

			List<Offer> offers = JsonSerializer.Deserialize<List<Offer>>(data) ?? new();
			Offer = offers.FirstOrDefault(x => x.Id == 12344);
			if (Offer == null) return NotFound();

			if (_context.Offers.Find(Offer.Id) == null)
			{
				_context.Offers.Add(Offer);
				_context.SaveChanges();
			}
			else ModelState.AddModelError(string.Empty, "Record already exists.");

			return Page();
		}
    }
}