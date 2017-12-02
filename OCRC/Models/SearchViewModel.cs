using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCRC.Models
{
    public class SearchViewModel
    {
        
        public List<Search> searches { get; set; }
        public List<Sport> sports { get; set; }
        
       public static SearchViewModel getSearchViewModel()
        {
            SearchViewModel svm = new SearchViewModel();
            svm.searches = Search.getSearchResultsForActive();
            svm.sports = OCRC_API.getAllSports();
            return svm;
        }
    }
}