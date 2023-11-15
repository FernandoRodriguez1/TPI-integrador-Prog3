using AutoMapper;
using System.Runtime.InteropServices;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
namespace TPI_Integrador_Prog3.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewDto, Review>();
            CreateMap<Review, ReviewDto>();
        }
         
    }
}
