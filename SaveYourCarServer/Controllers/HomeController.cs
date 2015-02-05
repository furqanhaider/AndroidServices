using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaveYourCarServer.Models;

namespace SaveYourCarServer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        ScoresDbEntities db = new ScoresDbEntities();

        public string Index()
        {
            return "Online";
        }

        public string getTopFive()
        {
            var q = (from y in db.Scores
                     orderby y.Score1 descending
                     select y).Take(5).ToArray();

            return JsonConvert.SerializeObject(q);
        }

        public string InsertScore(string name, string score)
        {
            //http://localhost:1554/Home/insertScore?name=furqan&score=21
            if(name!=null && score!=null)
            {
                Score sc = new Score();
                sc.Name = name.ToUpper();
                sc.Score1 = Int32.Parse(score);
                db.Scores.Add(sc);
                if(db.SaveChanges() > 0)
                {
                    return "true";
                }
                return "false";                
            }
            else
            {
                return "false";
            }
        }

        public string AboutMe()
        {
            string str = "My name is Furqan Haider Hashmi, I am developer of SaveYourCar, Contant me : furqan_haider@hotmail.com";
            return str;
        }

        public string AboutTahir()
        {
            string str = "My name is Tahir Idrees\n I am student of Punjab University College Of Information Technology\n My College Id is BCSF11A097\n This is a 2D Robo_War Game Developed as Term Project of Mobile Computing\n Email: tahir97@gmail.com";
            return str;
        }

        public string AboutImran()
        {
            string str = "My name is Muhammad Imran, Developing this game but very kutta kam , Contant me : bcsf11a092@pucit.edu.pk.com";
            return str;
        }

    }
}
