using ef_test2.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ef_test2.Models;
using System.Collections.Generic;

namespace ef_test2
{
    internal class Program
    {
        public VetDbContext context;

        public List<int> grades = new List<int>() { 34, 12, 56, 11, 33, 87, 58, 91, 100 };

        public Program()
        {
            context = new VetDbContext();
        }


        public void PassingGrades()
        {
            var passing = grades.Where(g => g > 60);

            foreach(var p in passing)
            {
                Console.WriteLine(p);
            }
        }


        public void ViewPets()
        {
            var pets = context.Pets.Include(pet => pet.Owner).ToList();

            foreach (var pet in pets)
            {
                Console.WriteLine(pet.Name + " owner: " + pet.Owner.Name);
            }
        }

        public void ViewOwner(int id)
        {
            var owners = context.Owners.Where(o => o.Id == id).SelectMany(o => o.Pets).ToList();

            foreach(var owner in owners)
            {
                Console.WriteLine(owner.Name);
            }
        }

        public void AddOwner()
        {
            Console.Write("Give name: ");
            string name = Console.ReadLine();

            Owner owner = new Owner();
            owner.Name = name;
            context.Owners.Add(owner);
            context.SaveChanges();
        }

        static void Main(string[] args)
        {
            Program app = new Program();

            // app.ViewPets();

            // app.ViewOwner(2);

            // app.AddOwner();

            app.PassingGrades();
        }
    }
}
