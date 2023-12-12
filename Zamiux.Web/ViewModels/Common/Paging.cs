namespace Zamiux.Web.ViewModels.Common
{

    public class BasePaging 
    {
        #region Ctor
        public BasePaging()
        {
            Page = 1;
            Take = 5;
            HowManyPagesShowAfterAndBefore = 5;
        }
        #endregion
        public int Page { get; set; }

        // tedad koll items
        public int AllEntitiesCount { get; set; }

        // tedad koll safahat
        public int PagesCount { get; set; }

        // tedad items ke mikhaei dar har page begiri
        public int Take { get; set; }

        // tedad items ke mikhaei neshoon nade o bikhail shi
        public int Skip { get; set; }

        // che tedad page-number dar har pagination neshoon bede
        public int HowManyPagesShowAfterAndBefore { get; set; }

        // Shomare Start Page in page
        public int StartPage { get; set; }

        // Shomare End Page in page
        public int EndPage { get; set; }

        //func
        public BasePaging GetPagingProperties()
        {
            return this;
        }
    }

    public class Paging<T>: BasePaging
    {
        // list items ke bayaad Generic bashad
        public List<T> ListEntities { get; set; } = new List<T>(); 


        // method set paging
        public void SetPagging(IQueryable<T> query)
        {
            if (Page < 1)
            {
                Page = 1;
            }

            if (Take < 1)
            {
                Take = 10;
            }

            Skip = (Page - 1) * Take;
            AllEntitiesCount = query.Count();
            PagesCount = (int)Math.Ceiling(AllEntitiesCount / (decimal)Take);

            if(Page > PagesCount)
            {
                Page = PagesCount;
            }
            
            StartPage = Page - HowManyPagesShowAfterAndBefore >= 1 ? Page - HowManyPagesShowAfterAndBefore : 1;
            EndPage = Page + HowManyPagesShowAfterAndBefore <= PagesCount ? Page +- HowManyPagesShowAfterAndBefore : PagesCount;

            ListEntities = query.Skip(Skip).Take(Take).ToList();
        }
    }
}
