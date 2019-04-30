namespace Vizew.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Vizew.WebUI.Models;
    using Vizew.WebUI.Models.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<VizewDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            if (VizewDbContext.schemaName != "dbo")
            {
                ContextKey = "x1234#" + VizewDbContext.schemaName;
            }

            SetSqlGenerator("System.Data.SqlClient", new VizewSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(VizewDbContext context)
        {
            try
            {

                if (!context.Category.Any())
                {
                    context.Category.AddRange(new[] {
                    new Category{
                        Name="Sports",
                        IsActive=true
                    },
                    new Category{
                        Name="Game",
                        IsActive=true
                    },
                    new Category{
                        Name="Business",
                        IsActive=true
                    }
                         });
                }

                //if (VizewDbContext.schemaName != "dbo")
                        GenerateTestData(context);

                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;


                File.AppendAllText(@"F:\error.log", ex.ToString());
            }
        }

        private void GenerateTestData(VizewDbContext context)
        {
            if (!context.News.Any())
            {
                context.News.AddRange(new[] {
                    GenerateTestNews("Reunification of migrant toddlers, parents should be completed Thursday","By Jane","1.jpg",2),
                    GenerateTestNews("Boys 'doing well' after Thai cave rescue","By Santa","2.jpg",1),
                    GenerateTestNews("Meet the 12 boys rescued from cave","By Jane","3.jpg",3),
                    GenerateTestNews("Pogba dedicates France win to Thai cave boys","Con Jame","4.jpg",2),
                    GenerateTestNews("How the world reacted to PM's Brexit crisis","By Jane","5.jpg",1),
                    GenerateTestNews("Meet the 12 boys rescued from cave","By Jane","6.jpg",3),
                    GenerateTestNews("How the world reacted to PM's Brexit crisis","Con Jame","7.jpg",3),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Con Jame","8.jpg",3),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Con Jame","9.jpg",3),
                    GenerateTestNews("Warner Bros. Developing ‘The accountant’ Sequel","Con Jame","10.jpg",3),
                    GenerateTestNews("How the world reacted to PM's Brexit crisis","By Jane","11.jpg",3),
                    GenerateTestNews("Searching for the 'angel' who held me on Westminste Bridge","By Jane","12.jpg",3),
                    GenerateTestNews("Love Island star's boyfriend found dead after her funeral","By Jane","13.jpg",3),
                    GenerateTestNews("Paramedics 'drilled into boat death woman'","By Jane","14.jpg",3),
                    GenerateTestNews("Epileptic boy's cannabis let through border","By Simson","15.jpg",3),
                    GenerateTestNews("Love Island star's boyfriend found dead after her funeral","By Simson","16.jpg",3),
                    GenerateTestNews("Paramedics 'drilled into boat death woman'","By Simson","17.jpg",2),
                    GenerateTestNews("Love Island star's boyfriend found dead after her funeral","By Simson","18.jpg",2),
                    GenerateTestNews("How the world reacted to PM's Brexit crisis","By Simson","19.jpg",2),
                    GenerateTestNews("Meet the 12 boys rescued from cave","By Simson","20.jpg",2),
                    GenerateTestNews("Meet the 12 boys rescued from cave","By Jane","21.jpg",2),
                    GenerateTestNews("Meet the 12 boys rescued from cave","By Jane","22.jpg",2),
                    GenerateTestNews("Meet the 12 boys rescued from cave","By Jane","23.jpg",2),
                    GenerateTestNews("Meet the 12 boys rescued from cave","By Jane","24.jpg",2),
                    GenerateTestNews("Epileptic boy's cannabis let through border","Mr Farley","25.jpg",2),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Mr Farley","26.jpg",1),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Mr Farley","27.jpg",1),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Mr Farley","28.jpg",1),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Mr Farley","29.jpg",1),
                    GenerateTestNews("Searching for the 'angel' who held me on Westminste Bridge","Mr Farley","30.jpg",1),
                    GenerateTestNews("How the world reacted to PM's Brexit crisis","Mr Farley","31.jpg",1),
                    GenerateTestNews("Tory vice-chairs quit over PM's Brexit plan","Mr Farley","32.jpg",1),
                    GenerateTestNews("Searching for the 'angel' who held me on Westminste Bridge","Mr Farley","33.jpg",1),
                    GenerateTestNews("Do This One Simple Action for an Absolutely","By Jane","34.jpg",1),
                    GenerateTestNews("May fights on after Johnson savages Brexit approach","By Jane","35.jpg",1),
                    GenerateTestNews("Searching for the 'angel' who held me on Westminste Bridge","By Jane","36.jpg",1),
                    GenerateTestNews("May fights on after Johnson savages Brexit approach","By Jane","37.jpg",2),
                    GenerateTestNews("Epileptic boy's cannabis let through border","By Jane","38.jpg",3),
                    GenerateTestNews("Searching for the 'angel' who held me on Westminste Bridge","By Jane","39.jpg",3),
                    GenerateTestNews("Do This One Simple Action for an Absolutely","By Jane","40.jpg",3),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Jack Daniels","41.jpg",3),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Jack Daniels","42.jpg",3),
                    GenerateTestNews("Searching for the 'angel' who held me on Westminste Bridge","Jack Daniels","43.jpg",3),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Jack Daniels","44.jpg",3),
                    GenerateTestNews("Searching for the 'angel' who held me on Westminste Bridge","Jack Daniels","45.jpg",2),
                    GenerateTestNews("Meet the 12 boys rescued from cave","Jack Daniels","46.jpg",2),
                    GenerateTestNews("May fights on after Johnson savages Brexit approach","Jack Daniels","47.jpg",2),
                    GenerateTestNews("Epileptic boy's cannabis let through border","Jack Daniels","48.jpg",2),
                    GenerateTestNews("Searching for the 'angel' who held me on Westminste Bridge","Jack Daniels","49.jpg",2)
                });
            }
        }

        News GenerateTestNews(string title,string author,string mediaUrl,int categoryId)
        {
            return new News
            {
                Title = title,
                Author = author,
                MediaUrl = mediaUrl,
                IsPopular = true,
                CategoryId=categoryId,
                Body = @"<p>I love dals. All kinds of them but yellow moong dal is my go-to lentil when I am in need of some easy comfort food. In this recipe I added suva or dill leaves to the classic moong dal recipe for a twist. I like the simplicity of this recipe, just the dal, tomatoes and fresh dill with simple seasoning. This recipe is without any onions and garlic. I love the aroma of fresh dill and I think, in Indian food, we don&rsquo;t really use dill as much as we can. Nine out of ten times, the only green leaves sprinkled on a curry or a dal is fresh coriander and while I love coriander too, dill adds a unique freshness and aroma to the dal. The delicate feathery leaves of dill are also rich in Vitamin A, C and minerals like iron and manganese.</p><p>Dals or lentils are packed with proteins and especially in a vegetarian diet, lentils are the main source of protein. It is amazing how this humble yellow moong dal can be made into so many recipes from a plain dal khichdi to mangodi ki sabzi to the traditional Indian desserts like moong dal halwa.</p><blockquote><p>&ldquo;If you&rsquo;re going to try, go all the way. There is no other feeling like that. You will be alone with the gods.&rdquo;</p>
                         <p>Ollie Schneider - CEO Deercreative</p>
                         </blockquote><p>Dals or lentils are packed with proteins and especially in a vegetarian diet, lentils are the main source of protein. It is amazing how this humble yellow moong dal can be made into so many recipes from a plain dal khichdi to mangodi ki sabzi to the traditional Indian desserts like moong dal halwa. Fresh dill should be added only at the end of cooking, much like fresh coriander leaves.</p>
                         <p>Immediate Dividends</p>
                         <ul><li>Wash the dal in 3-4 changes of water and soak in room temperature water for 10 mins while you finish the rest of preparation.</li><li>Drain and pressure cook with salt, turmeric and water for 2 whistles.</li><li>Remove the cooker from heat and open only after all the steam has escaped on its own.</li><li>While the dal is cooking, heat ghee in a pan. Add hing and cumin seeds.</li><li>When the seeds start to crackle, add ginger, and green chillies. Saut&eacute; for a minute.</li><li>Add tomatoes and a little salt. Mix well. Cook for about 5 mins with occasional stirring.</li></ul>"
            };
        }
    }
}
