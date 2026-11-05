using System;
using System.Collections.Generic;
using System.Text;

namespace App_Browser;

internal class HistoryItem
{
    public string Url { get; set; } = string.Empty;
    public string FriendlyName { get; set; } = string.Empty;
    public string AccessTime { get; set; } = string.Empty;

    public DateTime GetAccessTime()
    {
        if (!string.IsNullOrEmpty(AccessTime) && DateTime.TryParse(AccessTime, out DateTime result))
        {
            return result;
        }

        return DateTime.Now;
    }

    public override string ToString() => FriendlyName;
}

internal class HistoryBag
{
    private List<HistoryItem> historyItems = new();

    public void Add(string url, string friendlyName, string accessTime)
    {
        Add(new HistoryItem() 
        { 
            Url = url, 
            FriendlyName = friendlyName, 
            AccessTime = accessTime
        });
    }

    public void Add(HistoryItem item)
    {
        // List
        historyItems.Add(item);
    }

    public void Remove(HistoryItem item)
    {
        // List
        historyItems.Remove(item);
    }

    public void Clear()
    {
        historyItems.Clear();
    }
}