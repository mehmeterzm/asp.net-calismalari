namespace MeetingApp.Models
{
    public static class Repository
    {
        public static List<UserInfo> _users = new();
        static Repository(){
            _users.Add(new UserInfo() { Id=1, Name = "Ali", Email= "abc@gmail.com", Phone="3233333333",WillAttend=true});
            _users.Add(new UserInfo() { Id=2,Name = "Ahmet", Email= "svc@gmail.com", Phone="23443242343",WillAttend=true});
            _users.Add(new UserInfo() { Id=3,Name = "Veli", Email= "kvs@gmail.com", Phone="6765756756763",WillAttend=true});
        }
        public static List<UserInfo> Users {
            get{
                return _users;
            }
        }
        public static void createUser(UserInfo user)
        {
            user.Id = Users.Count +1;
            _users.Add(user);
        }
        public static UserInfo? GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

    }
}
