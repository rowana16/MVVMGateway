 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLearningData
{
    public class TrainingProductManager
    {

       

        //==================================================================================================================================================
        //Properties and Constructor

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        //==================================================================================================================================================
        // Validate Method

        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();

            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                if(entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be all lower case.")); // Add any Errors to Validation Errors
                }
            }
            return (ValidationErrors.Count == 0);
        }

        //==================================================================================================================================================
        // Get Method (TrainingProduct)

        public List<TrainingProduct> Get(TrainingProduct searchResult)
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();
            // TODO: Add you Data Access Method here


            ret = CreateMockData();
            if (!string.IsNullOrEmpty(searchResult.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(searchResult.ProductName, StringComparison.CurrentCultureIgnoreCase));
            }

            return ret;

        }

        //==================================================================================================================================================
        // Get Method (Int)

        public TrainingProduct Get (int productId)
        {
            List<TrainingProduct> list = new List<TrainingProduct>();
            TrainingProduct ret = new TrainingProduct();

            //TODO: Call your data Access Method Here
            list = CreateMockData();

            ret = list.Find(p => p.ProductId == productId);
            return ret;
        }

        //==================================================================================================================================================
        // Update Method (TrainingProduct)

        public bool Update(TrainingProduct entity)
        {
            bool ret = false;
            ret = Validate(entity);
            if (ret)
            {
                //TODO: Create Update Code Here
            }

            return ret;
        }

        //==================================================================================================================================================
        // Insert Method

        public bool Insert(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);
            if (ret)
            {
                //TODO: Create INSERT code here
            }

            return ret;

        }

        //==================================================================================================================================================
        // Delete Method

        public bool Delete(TrainingProduct entity)
        {
            //TODO: Create Delete Code

            return true;
        }

        //==================================================================================================================================================
        // Seeded Data - CreateMockData()


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
