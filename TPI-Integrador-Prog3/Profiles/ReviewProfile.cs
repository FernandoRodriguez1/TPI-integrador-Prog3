using AutoMapper;
using System.Runtime.InteropServices;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
namespace TPI_Integrador_Prog3.Profiles
{
    public class ReviewProfile : Profile  //Hereda de Profile, para poder funcionar como un perfil y poder mappear los objetos.
    {
        public ReviewProfile()
        {
            CreateMap<ReviewDto, Review>(); //Permitimos que el auto mappear rellene las celdas en la base de datos de DTO a Objeto
            CreateMap<Review, ReviewDto>(); //También de Objeto a DTO.
        }

    }
}