using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class CreatePlayerCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public string Country { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdGame { get; set; }

        public CreatePlayerCommand(string email, string name, string picture, string nickName, string avatar,
         string country, Guid idUser, Guid idGame)
        {
            Email = email;
            Name = name;
            Picture = picture;
            NickName = nickName;
            Avatar = avatar;
            Country = country;
            IdUser = idUser;
            IdGame = IdGame;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .IsEmail(Email, "Email", Messages.V_IsNotEmail.ToFormat("Email"))

            .HasMinLen(Name, 3, "Name", Messages.V_HasMinLen.ToFormat("Name", "3"))
            .HasMinLen(NickName, 3, "NickName", Messages.V_HasMinLen.ToFormat("NickName", "3"))

            .HasMaxLen(NickName, 100, "NickName", Messages.V_HasMaxLen.ToFormat("NickName", "100"))
            .HasMaxLen(Name, 256, "Name", Messages.V_HasMaxLen.ToFormat(NickName, "256"))

            .HasLen(Country, 2, "Country", Messages.V_HasLen.ToFormat("Country", "2"))

            .IsNotNullOrEmpty(Avatar, "Avatar", Messages.V_IsNotNullOrEmpty.ToFormat("Avatar"))
            .IsNotNullOrEmpty(Picture, "Picture", Messages.V_IsNotNullOrEmpty.ToFormat("Picture"))
            .IsNotNull(IdUser, "IdUser", Messages.V_IsNotNull.ToFormat("IdUser"))
            .IsNotNull(IdGame, "IdGame", Messages.V_IsNotNull.ToFormat("IdGame"))
            );
        }
    }
}