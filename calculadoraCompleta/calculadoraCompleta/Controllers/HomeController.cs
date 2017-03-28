using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace calculadoraCompleta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //inicializar valores
            ViewBag.Visor = "0";

            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string visor){

            switch (bt)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    //determinar se no visor só existe um 0
                    if (visor.Equals("0")) visor = bt;
                    else visor += bt;
                    break;

                case ",":
                    if (!visor.Contains(",")) visor += bt;
                    break;

                case "+/-":
                    // esta hipotese
                    //visor = Convert.ToDouble(visor) * -1 + "";
                    // ou
                    if (visor.StartsWith("-")) visor = visor.Replace("-", "");
                    else if (!visor.Equals("0")) visor = "-" + visor;
                    break;

                case "C":
                    visor = "0";
                    Session["PrimeiroOperador"] = true;
                    break;

                case "+":
                case "-":
                case "x":
                case ":":
                    if ((bool)Session["PrimeiroOperador"]){ 
                        //guardar valor do visor
                        Session["operando"] = visor;

                        //limpar o visor
                        visor = "0";

                        //guardar o operador
                        Session["operador"] = bt;

                        //marcar como tendo utilizado o operador
                        Session["PrimeiroOperador"] = false;
                    }
                    else{
                        //se nao é a primeira vez que se clica num Operador
                        //vou utilizar os valores anteriores

                        switch ((string)Session["Operador"])
                        {
                            case "":
                                break;
                            //recuperar codigo da 1.º calculadora
                        }

                        //guardar os novos valores..
                    }
                    break;
            }

            //entregar os valores à view
            ViewBag.Visor = visor;
       

            return View();
        }
    }
}