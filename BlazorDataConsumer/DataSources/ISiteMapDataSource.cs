using BlazorDataConsumer.Models;

namespace BlazorDataConsumer.DataSources;

public interface ISiteMapDataSource
{
    IEnumerable<SiteMapEntry> Get();

    event EventHandler DataSourceChanged;
}