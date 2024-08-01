namespace GaraMan.Models
{
    public class Hoadonnhap385
    {
        public string id {  get; set; }
        public float total { get; set; }
        public DateTime date { get; set; }
        public string note {  get; set; }
        public Nhacungcap385 nhacungcap {  get; set; }
        public Nhanvienkho385  nhanvienkho { get; set; }
        public Phutung385[] ListPhutung { get; set;}
    }
}
