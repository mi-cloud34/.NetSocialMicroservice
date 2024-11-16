
namespace Comment.WepAPI.Model
{
    [Dapper.Contrib.Extensions.Table("comment")]
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int UserUd { get; set; }

        public Comments()
        {
            
        }
        public Comments(int id,string comment,int userId) 
        {
            Id = id;
            Comment = comment;
            UserUd = userId;
        }
    }
}
