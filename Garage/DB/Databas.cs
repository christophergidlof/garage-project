using Garage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage.DB
{
    public class Databas : DbContext
    {

        public Databas() : base("DefaultConnection") { }
        public DbSet<FordonModel> Fordon { get; set; }
        public DbSet<NyhetModel> Nyheter { get; set; }

        public void Add(FordonModel fordon)
        {
            Fordon.Add(fordon);
            this.SaveChanges();
        }

        public void Add(NyhetModel nyhet)
        {
            Nyheter.Add(nyhet);
            this.SaveChanges();
        }

        public void Remove(FordonModel fordon)
        {
            this.Remove(fordon);
        }

        public void Delete(int? id)
        {
            Fordon.Remove(Fordon.Find(id));
            this.SaveChanges();
        }

        public FordonModel Find(FordonModel fordon)
        {
            return Fordon.Find(fordon.Id);
        }

        public FordonModel Find(int? id)
        {
            return Fordon.Find(id);
        }

        public void Edit(FordonModel fordon)
        {
            this.Entry(fordon).State = EntityState.Modified;
            this.SaveChanges();
        }

        public List<FordonModel> List()
        {
            return Fordon.ToList();
        }
    }
}