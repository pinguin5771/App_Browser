using System.Text.Json;

namespace BrowserLinkManager;

public enum LinkStatus
{
    Allowed,
    Blocked,
    TemporaryAllowed
}

public class LinkInfo
{
    public string Url { get; set; } = string.Empty;

    public LinkStatus Status { get; set; }

    public bool IsFavorite { get; set; }

    public DateTime? AllowedUntil { get; set; }

    public bool IsAllowed()
    {
        return Status switch
        {
            LinkStatus.Allowed => true,

            LinkStatus.Blocked => false,

            LinkStatus.TemporaryAllowed =>
                AllowedUntil.HasValue &&
                AllowedUntil.Value > DateTime.Now,

            _ => false
        };
    }
}

public class LinkManager
{
    private List<LinkInfo> links = new();

    private readonly string filePath;

    public LinkManager(string filePath)
    {
        this.filePath = filePath;
        LoadFromFile();
    }

    public List<LinkInfo> GetAll()
    {
        return links.ToList();
    }

    public void Add(
        string url,
        LinkStatus status = LinkStatus.Allowed)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uri)
            || (uri.Scheme != Uri.UriSchemeHttp &&
                uri.Scheme != Uri.UriSchemeHttps))
        {
            throw new ArgumentException("Invalid URL");
        }

        string normalizedUrl = uri.AbsoluteUri;

        if (links.Any(x => x.Url.Equals(
            normalizedUrl, StringComparison.OrdinalIgnoreCase)))
            return;

        links.Add(new LinkInfo
        {
            Url = normalizedUrl,
            Status = status
        });

        SaveToFile();
    }


    public void Remove(string url)
    {
        links.RemoveAll(x =>
            x.Url.Equals(url, StringComparison.OrdinalIgnoreCase));

        SaveToFile();
    }

    public void Clear()
    {
        links.Clear();
        SaveToFile();
    }

    public void SetStatus(string url, LinkStatus status)
    {
        var link = Find(url);

        if (link == null)
            return;

        link.Status = status;

        link.AllowedUntil = null;

        SaveToFile();
    }

    public void AllowTemporarily(string url, TimeSpan duration)
    {
        if (duration <= TimeSpan.Zero)
            throw new ArgumentException("Duration must be positive");

        var link = Find(url);

        if (link == null)
            return;

        link.Status = LinkStatus.TemporaryAllowed;
        link.AllowedUntil = DateTime.Now.Add(duration);

        SaveToFile();
    }

    public void SetFavorite(string url, bool isFavorite)
    {
        var link = Find(url);

        if (link == null)
            return;

        link.IsFavorite = isFavorite;

        SaveToFile();
    }

    public bool IsAllowed(string url)
    {
        var link = Find(url);

        return link == null || link.IsAllowed();
    }

    private LinkInfo? Find(string url)
    {
        return links.FirstOrDefault(x =>
            x.Url.Equals(url, StringComparison.OrdinalIgnoreCase));
    }

    public void SaveToFile()
    {
        string? directory = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        string json = JsonSerializer.Serialize(
            links,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(filePath, json);
    }

    public void LoadFromFile()
    {
        if (!File.Exists(filePath))
        {
            links = new List<LinkInfo>();
            return;
        }

        try
        {
            string json = File.ReadAllText(filePath);

            links = JsonSerializer.Deserialize<List<LinkInfo>>(json)
                    ?? new List<LinkInfo>();
        }
        catch (JsonException)
        {
            links = new List<LinkInfo>();
        }
    }
}