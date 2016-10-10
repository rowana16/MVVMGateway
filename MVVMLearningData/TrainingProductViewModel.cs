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
        public TrainingProduct SearchResult { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public TrainingProduct Entity { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }

        // constructor
        public TrainingProductViewModel()
        {
            Products = new List<TrainingProduct>();
            SearchResult = new TrainingProduct();
            Entity = new TrainingProduct();
            //visibility
            Init();


        }
       

        //==================================================================================================================
        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                    Get(); // populate the Products property
                    break;

                case "search":
                    Get(); // populate the Products property
                    break;

                case "reset":
                    ResetSearch(); // reset the search result
                    Get();
                    break;


                case "add":
                    //visibility
                    Add();
                    break;

                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;



                case "cancel":
                    ListMode();
                    Get(); 
                    break;


                default:
                    break;
            }
        }
        //==================================================================================================================
        private void ResetSearch()
        {
            SearchResult = new TrainingProduct();
        }

        //==================================================================================================================
        //List Mode
        private void ListMode()
        {
            IsValid = true;
            Mode = "List";

            IsSearchAreaVisible = true;
            IsListAreaVisible = true;
            IsDetailAreaVisible = false;

            
        }
        //==================================================================================================================
        //Save

        private void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            if (Mode == "Add")
            {
                mgr.Insert(Entity);

            }
            else
            {
                mgr.Update(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;

            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }
        }

        //==================================================================================================================
        //Add Method

        private void Add()
        {
            IsValid = true;
            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            AddMode();
        }

        //==================================================================================================================
        //Edit Method

        private void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            EditMode();
        }

        //==================================================================================================================
        //Delete Method

        private void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);

            Get();
            ListMode();

        }

        //==================================================================================================================
        //Add Mode
        private void AddMode()
        {
            Mode = "Add";

            IsSearchAreaVisible = false;
            IsListAreaVisible = false;
            IsDetailAreaVisible = true;
        }

        //==================================================================================================================
        //Add Mode
        private void EditMode()
        {
            Mode = "Edit";

            IsSearchAreaVisible = false;
            IsListAreaVisible = false;
            IsDetailAreaVisible = true;
        }


        //==================================================================================================================
        // init
        private void Init()
        {
            EventCommand = "List";
            ValidationErrors = new List<KeyValuePair<string, string>>();
            EventArgument = "";
            ListMode();
        }
        //==================================================================================================================

        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchResult);

        }
    }
}
