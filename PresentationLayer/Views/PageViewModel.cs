namespace PresentationLayer.Views;

public class PageViewModel
{
    
    public PageViewModel(int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int) Math.Ceiling(count / (double) pageSize);
    }
    
    public int PageNumber { get; private set; }
    public int TotalPages { get; private set; }

}