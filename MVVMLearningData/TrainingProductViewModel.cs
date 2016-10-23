using MVVMLearningCommon;
using System;
using System.Collections.Generic;

namespace MVVMLearningData
{
    public class TrainingProductViewModel: ViewModelBase
    {
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchResult { get; set; }
        public TrainingProduct Entity { get; set; }

        

        

        // constructor
        public TrainingProductViewModel():base() //call base constructor
        {
            
        }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            SearchResult = new TrainingProduct();
            Entity = new TrainingProduct();
            //visibility
            base.Init();
        }        

        //==================================================================================================================
        protected override void ResetSearch()
        {
            SearchResult = new TrainingProduct();
            base.ResetSearch();
        }                

        //==================================================================================================================
        //Add Method

        protected override void Add()
        {
            
            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            base.Add();
        }

        //==================================================================================================================
        //Edit Method

        protected override void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            base.Edit();
        }

        //==================================================================================================================
        //Delete Method

        protected override void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);

            Get();
            base.Delete();

        }

             
        //==================================================================================================================

        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchResult);
            base.Get();

        }

        //==================================================================================================================
        //Save

        protected override void Save()
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

            base.Save();
        }

        public override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                // add additional cases
                //break;
                default:
                    break;
            }
            base.HandleRequest();
        }
    }
}
