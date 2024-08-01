namespace GaraMan.Models
{
    public class Hoadon385
    {
        public string id { get; set; }
        public float total { get; set; }
        public DateTime date { get; set; }
        public string note { get; set; }
        public Khachhang385 kh { get; set; }
        public Nhanvienbanhang385 nvbh { get; set; }
        public Dichvuyeucau385 dichvuyeucau { get; set; }
        public Phutungyeucau385 phutungyeucau { get; set; }
    }
}
