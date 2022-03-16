using DataAccessLayer.Models;

namespace PresentationLayer.Views;

public class IndexViewModel
{
    public IndexViewModel(IEnumerable<CitizenModel> citizens, PageViewModel pageViewModel)
    {
        Citizens = citizens;
        PageViewModel = pageViewModel;
    }

    public IEnumerable<CitizenModel> Citizens { get; set; }
    public PageViewModel PageViewModel { get; set; }
}