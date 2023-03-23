using BookLib.Contracts;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookLib.Services
{
	public class OpenLibraryService
	{
        public OpenLibraryService()
        {
            
        }

        public async Task<OpenLibraryBookDetails> GetLibraryBookDetailsAsync(string isbn)
        {
            var result = new OpenLibraryBookDetails();
            var url = $@"https://openlibrary.org/api/volumes/brief/isbn/{isbn}.json";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(content);

                result.Title = data?.SelectToken("$..*.data.title")?.ToObject<string>();
                result.NumberOfpages = data?.SelectToken("$..*.data.number_of_pages")?.ToObject<int>();
                result.PublishDate = data?.SelectToken("$..*.data.publish_date")?.ToObject<string>();

                result.Places = data?.SelectTokens("$..*.data.subject_places[*]")
                                ?.Select(r => new { ResultList = r.ToObject<Subject>() })
								?.Select(r => r.ResultList)?.ToList();

				result.People = data?.SelectTokens("$..*.data.subject_people[*]")
				                ?.Select(r => new { ResultList = r.ToObject<Subject>() })
				                ?.Select(r => r.ResultList)?.ToList();

				result.Times = data?.SelectTokens("$..*.data.subject_times[*]")
				                ?.Select(r => new { ResultList = r.ToObject<Subject>() })
				                ?.Select(r => r.ResultList)?.ToList();

                result.Links = data?.SelectTokens("$..*.data.links[*]")
				                ?.Select(r => new { ResultList = r.ToObject<Link>() })
				                ?.Select(r => r.ResultList)?.ToList();

                result.CoverUrl = data?.SelectToken("$..*.data.cover.large")?.ToObject<string>();
                result.InfoURL = data?.SelectToken("$..*.details.info_url")?.ToObject<string>();
			}

            return result;
        }
    }
}
