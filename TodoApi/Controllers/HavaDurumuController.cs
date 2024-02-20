﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HavaDurumuController : ControllerBase
    {
        readonly Random _rnd = new Random();

        readonly string[] _durumlar = { "Açık", "Parçalı Bulutlu", "Çok Bulutlu", "Sisli", "Puslu", "Yağmurlu", "Sağanak Yağışlı", "Kar Yağışlı", "Karla Karışık Yağmur", "Dolu", "Sıcak", "Soğuk", "Rüzgarlı", "Fırtına", "Kasırga" };

        [HttpGet()]
        public List<HavaDto> Get()
        {
            var tahminler = new List<HavaDto>();

            for (int i = 0; i < 5; i++) // 5 günlük hava durumu tahmini
            {
                tahminler.Add(new HavaDto()
                {
                    Tarih = DateOnly.FromDateTime(DateTime.Today.AddDays(i)),
                    Sicaklik = _rnd.Next(-5, 30),
                    Aciklama = _durumlar[_rnd.Next(_durumlar.Length)]
                });

            }
            return tahminler;
        }
    }
}
