using System.Collections.Generic;

namespace MVVMLearningCommon
{
    public class ViewModelBase
    {
        public string EventCommand { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }

        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        public ViewModelBase()
        {
            Init();

        }

        //==================================================================================================================
        //List Mode
        protected virtual void ListMode()
        {
            IsValid = true;
            Mode = "List";

            IsSearchAreaVisible = true;
            IsListAreaVisible = true;
            IsDetailAreaVisible = false;


        }

        //==================================================================================================================
        // init
        protected virtual void Init()
        {
            EventCommand = "List";
            ValidationErrors = new List<KeyValuePair<string, string>>();
            EventArgument = "";
            ListMode();
        }

        

        //==================================================================================================================
        protected virtual void ResetSearch()
        {
        }

        //==================================================================================================================
        //Add Mode
        protected virtual void AddMode()
        {
            Mode = "Add";

            IsSearchAreaVisible = false;
            IsListAreaVisible = false;
            IsDetailAreaVisible = true;
        }

        //==================================================================================================================
        //Edit Mode
        protected virtual void EditMode()
        {
            Mode = "Edit";

            IsSearchAreaVisible = false;
            IsListAreaVisible = false;
            IsDetailAreaVisible = true;
        }

        //==================================================================================================================
        // Get
        protected virtual void Get()
        {

        }

        //==================================================================================================================
        //Add 
        protected virtual void Add()
        {
            IsValid = true;
            AddMode();
        }
        
        //==================================================================================================================
        //Edit 
        protected virtual void Edit()
        {
            EditMode();
        }

        //==================================================================================================================
        //Delete
        protected virtual void Delete()
        {
            ListMode();
        }

        //==================================================================================================================
        //Save

        protected virtual void Save()
        {
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
        public virtual void HandleRequest()
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
    }
}
