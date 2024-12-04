using System.ComponentModel.DataAnnotations;

namespace MVC.models
{
    public class User
    {
        public int id {  get; set; }
        public string name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }

        protected TypeUser typeUser { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime bornDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime dateCreate { get; set; }


        public User(string nameUser, string emailUser, string passwordUser, string phoneNumberUser, DateTime bornDateUser)
        {
            name=nameUser;
            email=emailUser;
            password=passwordUser;
            phoneNumber=phoneNumberUser;
            bornDate = bornDateUser;
            dateCreate = DateTime.Now;
            typeUser = TypeUser.User;


        }

    }



    public enum TypeUser
    {
        User, Admin
    }
}
