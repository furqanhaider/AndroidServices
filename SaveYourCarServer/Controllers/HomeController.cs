﻿using Newtonsoft.Json;
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

    }
}