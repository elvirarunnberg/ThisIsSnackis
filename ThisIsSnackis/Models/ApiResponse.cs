namespace ThisIsSnackis.Models
{

    public class ApiResponse
    {
        public MyPost[] MyPosts { get; set; }
    }

    public class MyPost
    {
        public int id { get; set; }
        public string title { get; set; }
        public string thePost { get; set; }
        public string authorId { get; set; }
        public DateTime date { get; set; }
    }

}
