using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLearningData
{
    public class TrainingProductViewModel
    {
        public List<TrainingProduct> Products { get; set; }
        public string EventCommand { get; set; }

        public TrainingProductViewModel()
        {
            Products = new List<TrainingProduct>();
            EventCommand = "List";

        }
       
        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                    Get(); // populate the Products property
                    break;

                case "add":
                    Get(); // populate the Products property
                    break;

                case "edit":
                    Get(); // populate the Products property
                    break;



                default:
                    break;
            }
        }


        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get();

        }
    }
}
