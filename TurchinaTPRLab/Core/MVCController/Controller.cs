using System.Collections.Generic;
using DecisionTheory.Core.MVCModel;
using DecisionTheory.Core.MVCView;

namespace DecisionTheory.Core.MVCController
{
    /// <summary>
    /// MVC Controller, provides the API for data and view management
    /// </summary>
    public class Controller
    {
        private ICollection<View> views;
        private Model model;

        /// <summary>
        /// Constructor initializes a view collection
        /// </summary>
        public Controller()
        {
            views = new List<View>();
        }

        /// <summary>
        /// This method subscribes each view for updating
        /// </summary>
        /// <param name="views">View instances that want to subscribe to this controller</param>
        public void addView(params View[] views)
        {
            foreach(var view in views)
                this.views.Add(view);
        }

        /// <summary>
        /// This method updates each view which subscribed to this controller
        /// </summary>
        public void update()
        {
            if (model != null)
            {
                foreach (var view in views)
                {
                    view.setModel(model);
                    view.update();
                }
            }
        }

        /// <summary>
        /// This method loads data model from file and updates each view
        /// </summary>
        /// <param name="fileName">the name of file</param>
        public void loadModel(string fileName)
        {
            model = Model.load(fileName);
            update();
        }

        /// <summary>
        /// This method saves data model to file
        /// </summary>
        /// <param name="fileName">the name of file</param>
        public void saveModel(string fileName)
        {
            if(model != null)
                model.save(fileName);
        }
    }
}
