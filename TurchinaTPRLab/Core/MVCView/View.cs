using System;
using DecisionTheory.Core.Error;
using DecisionTheory.Core.MVCModel;

namespace DecisionTheory.Core.MVCView
{
    /// <summary>
    /// MVC View class, provides base interface for all views
    /// </summary>
    public abstract class View
    {
        private Model model;

        /// <summary>
        /// Default constructor for view instances
        /// </summary>
        public View() { }


        /// <summary>
        /// Constructor that sets up model
        /// </summary>
        /// <param name="model">data model</param>
        public View(Model model)
        {
            setModel(model);
        }

        /// <summary>
        /// Updates this view
        /// </summary>
        public void update()
        {
            if (model == null)
                return;
            try
            {
                draw();
            }
            catch (Exception cause)
            {
                throw new ViewException(cause);
            }
        }

        /// <summary>
        /// This method describes how view should look like
        /// </summary>
        abstract protected void draw();

        /// <summary>
        /// Getter for model field
        /// </summary>
        /// <returns>data model</returns>
        public Model getModel()
        {
            return model;
        }

        /// <summary>
        /// Setter for model field
        /// </summary>
        /// <param name="model">data model</param>
        public virtual void setModel(Model model)
        {
            this.model = model;
        }
    }
}
