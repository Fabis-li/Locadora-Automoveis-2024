﻿using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class InicioController : Controller
    {
        private readonly IRepositorioGrpAutomoveis repositorioGrpAutomoveis;

        public InicioController(IRepositorioGrpAutomoveis repositorioGrpAutomoveis)
        {
            this.repositorioGrpAutomoveis = repositorioGrpAutomoveis;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}