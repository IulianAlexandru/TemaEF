using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenariu2
{
    class Program
    {
        static void AddIntoDatabase()
        {
            using (var context = new TemaEFEntities())
            {
                try
                {

                    var poet = new Poet { FirstName = "John", LastName = "Milton", MiddleName = "Name", PoetId = 1 };
                    var poem = new Poem { Title = "Para", PoetId = 1, PoemId = 1, MeterId = 1 };
                    var meter = new Meter { MeterName = "Iambic", MeterId = 1 };
                    poem.Meter = meter;
                    poem.Poet = poet;
                    context.Poems.Add(poem);
                    //poem = new Poem { Title = "Paradise Regained" };
                    //poem.Meter = meter;
                    //poem.Poet = poet;
                    //context.Poems.Add(poem);
                    //poet = new Poet { FirstName = "Lewis", LastName = "Carroll" };
                    //poem = new Poem { Title = "The Hunting of the Shark" };
                    //meter = new Meter { MeterName = "Anapestic Tetrameter" };
                    //poem.Meter = meter;
                    //poem.Poet = poet;
                    //context.Poems.Add(poem);
                    //poet = new Poet { FirstName = "Lord", LastName = "Byron" };
                    //poem = new Poem { Title = "Don Juan" };
                    //poem.Meter = meter;
                    //poem.Poet = poet;
                    //context.Poems.Add(poem);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    Console.WriteLine(dbEx);
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
        }
        static void ListContent()
        {
            using (var context = new TemaEFEntities())
            {
                var poets = context.Poets;
                foreach (var poet in poets)
                {
                    Console.WriteLine("{0} {1}", poet.FirstName, poet.LastName);
                    foreach (var poem in poet.Poems)
                    {
                        Console.WriteLine("\t{0} ({1})", poem.Title, poem.Meter.MeterName);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            AddIntoDatabase();
            ListContent();
        }
    }
}
