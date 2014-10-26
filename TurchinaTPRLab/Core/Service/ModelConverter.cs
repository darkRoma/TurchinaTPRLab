using DecisionTheory.Core.MVCModel;

namespace DecisionTheory.Core.Service
{
    /// <summary>
    /// This class provides some converting API for data model
    /// </summary>
    public static class ModelConverter
    {
        /// <summary>
        /// This method converts losses matrix to regret matrix data model
        /// </summary>
        /// <param name="model">losses matrix data model</param>
        /// <returns>regret matrix data model</returns>
        public static Model convert(Model model)
        {
            if (model == null)
                return model;

            var rows = model.getDecisionsCount();
            var cols = model.getStatesCount();

            var regret = (Model) model.Clone();
            for (int j = 0; j < cols; ++j)
            {
                int imin = 0;
                for (int i = 0; i < rows; ++i)
                    if (regret.getData(imin, j) > regret.getData(i, j))
                        imin = i;

                var min = regret.getData(imin, j);

                for (int i = 0; i < rows; ++i)
                {
                    var value = regret.getData(i, j) - min;
                    regret.setData(i, j, value);
                }
            }
            return regret;
        }
    }
}
