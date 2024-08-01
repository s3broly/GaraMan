namespace GaraMan.Models
{
    public class SearchViewModel
    {
        public string SearchTerm { get; set; }
        public List<Dichvu385> DichvuResults { get; set; }
        public List<Phutung385> PhutungResults { get; set; }
    }
}
