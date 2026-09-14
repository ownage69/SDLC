using System;
using System.Windows.Forms;
using SuperheroLevelCalculator.Controllers;
using SuperheroLevelCalculator.Models;
using SuperheroLevelCalculator.Views;

namespace SuperheroLevelCalculator
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
#if DEBUG
            SuperheroCalculatorModel.RunSelfCheck();
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SuperheroCalculatorModel model = new SuperheroCalculatorModel();
            MainForm mainForm = new MainForm(model);
            new SuperheroController(model, mainForm);

            Application.Run(mainForm);
        }
    }
}
