using System;
using Domain = Peek.Framework.UserService.Domain;

namespace Peek.Models.Output
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfilePhoto { get; set; }
        public bool Followed { get; set; }


        public User(string id, string name, string email, DateTime birthdate, string profilePhoto, bool followed)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthdate;
            ProfilePhoto = profilePhoto;
            Followed = followed;
        }

        public User(Domain.User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            BirthDate = user.BirthDate;
            ProfilePhoto = user.ProfilePhoto;
        }

        public User()
        {
        }
    }
}
