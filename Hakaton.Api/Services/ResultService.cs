using HakatonApi.DataBase;
using HakatonApi.DataBase.Repositories;
using HakatonApi.Models.ResultDtos;
using HakatonApi.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Services
{
    public class ResultService
    {
        private readonly IUnitOfWork context;

        public ResultService(IUnitOfWork context)
        {
            this.context = context;
        }


    }
}
