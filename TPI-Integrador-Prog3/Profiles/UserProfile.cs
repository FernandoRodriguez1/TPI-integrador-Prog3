using AutoMapper;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()//Realizamos esto así, ya que Usuario es una clase abstracta y no es posible mappear una clase abastracta.
        {
            CreateMap<UserDto, Client>();//Mappeo de usuario a Client
            CreateMap<UserDto, Admin>();//Mappeo de usuario a Admin

        }
    }
}