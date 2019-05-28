﻿using RH_Front.Models;
using RH_Front.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace RH_Front.Controllers
{
    public class HomeController : Controller
    {
        List<DadosOperacional> ListaDeDadosOperacionais = DadosServices.GetDadosOperacional();
        List<DadosTatico> ListaDeDadosTaticos = DadosServices.GetDadosTatico();
        List<DadosEstrategico> ListaDeDadosEstrategicos = DadosServices.GetDadosEstrategico();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Operacional()
        {
            ViewBag.Message = "Relatório Operacional de Recursos Humanos";

            return View(ListaDeDadosOperacionais);
        }

        public ActionResult Tatico()
        {
            ViewBag.Message = "Relatório Tático de Recursos Humanos";

            return View(ListaDeDadosTaticos);
        }

        public ActionResult Estrategico()
        {
            ViewBag.Message = "Relatório Estratégico de Recursos Humanos";

            return View(ListaDeDadosEstrategicos);
        }

        public ActionResult API()
        {
            ViewBag.Message = "Aqui seguem os dados da API de recursos humanos.";

            return View();
        }

        public ActionResult ChartTatico()
        {
            var myChart = new Chart(width: 400, height: 260)
                .AddTitle("Gráfico Tático")
                .AddSeries(
                    name: "Employee",
                    xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" },
                    yValues: new[] { "2", "6", "4", "5", "3" })
                .Write();
            return null;

    //        Usando data base para fazer o gráfico
    //        @{
    //            var db = Database.Open("SmallBakery");
    //            var data = db.Query("SELECT Name, Price FROM Product");
    //            var myChart = new Chart(width: 600, height: 400)
    //                .AddTitle("Product Sales")
    //                .DataBindTable(dataSource: data, xField: "Name")
    //                .Write();
    //        }
            
        }

        public ActionResult ChartEstrategico()
        {
            var myChart = new Chart(width: 400, height: 260)
                .AddTitle("Gráfico Estratégico")
                .AddSeries(
                    name: "Employee",
                    xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" },
                    yValues: new[] { "2", "6", "4", "5", "3" })
                .Write();
            return null;

            //        Usando data base para fazer o gráfico
            //        @{
            //            var db = Database.Open("SmallBakery");
            //            var data = db.Query("SELECT Name, Price FROM Product");
            //            var myChart = new Chart(width: 600, height: 400)
            //                .AddTitle("Product Sales")
            //                .DataBindTable(dataSource: data, xField: "Name")
            //                .Write();
            //        }

        }
    }
}