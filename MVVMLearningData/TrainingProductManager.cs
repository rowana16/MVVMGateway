using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLearningData
{
    public class TrainingProductManager
    {
        public List<TrainingProduct> Get()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();
            ret = CreateMockData();

            // TODO: Add you Data Access Method here
            return ret;

        }
        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Extending Bootstrap with CSS, javaScript and jQuery",
                IntroductionDate = Convert.ToDateTime("10/1/2016"),
                Url = "",
                Price = Convert.ToDecimal(29)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 2,
                ProductName = "C# for Everything",
                IntroductionDate = Convert.ToDateTime("9/1/2016"),
                Url = "",
                Price = Convert.ToDecimal(29)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 3,
                ProductName = "Lamp Stack Ahoy",
                IntroductionDate = Convert.ToDateTime("6/1/2016"),
                Url = "",
                Price = Convert.ToDecimal(29)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 4,
                ProductName = "Mean Stack is for Losers",
                IntroductionDate = Convert.ToDateTime("3/1/2016"),
                Url = "",
                Price = Convert.ToDecimal(29)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 5,
                ProductName = "Cold Fusion is THE FUTURE",
                IntroductionDate = Convert.ToDateTime("10/1/2010"),
                Url = "",
                Price = Convert.ToDecimal(29)
            });

            return ret;
        }
    }
}
