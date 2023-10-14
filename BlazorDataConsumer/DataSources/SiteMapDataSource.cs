using BlazorDataConsumer.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorDataConsumer.DataSources;

public class SiteMapDataSource : ComponentBase, ISiteMapDataSource
{

    [CascadingParameter]
    private ISiteMapConsumer? Parent { get; set; }

    private List<SiteMapEntry> _entries = new()
    {
 
        new SiteMapEntry("Entry 1", "/DummyPage/1"),
        new SiteMapEntry("Entry 2", "/DummyPage/2"),
        new SiteMapEntry("Entry 3", "/DummyPage/3"),
        new SiteMapEntry("Entry 4", "/DummyPage/4"),
        new SiteMapEntry("Entry 5", "/DummyPage/5"),
    };

    public IEnumerable<SiteMapEntry> Get()
        => _entries;

    public event EventHandler? DataSourceChanged;

    protected override void OnInitialized()
    {
        if (Parent is null)
            throw new ArgumentNullException(nameof(Parent), "SiteMapDataSource must exist within a SiteMapConsumer");

        base.OnInitialized();

        Parent.SetDataSource(this);
    }

    // raise event if data changes
    internal void RaiseDataSourceChanged()
        => DataSourceChanged?.Invoke(this, EventArgs.Empty);
}