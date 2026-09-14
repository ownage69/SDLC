using System;
using System.Globalization;
using System.Windows.Forms;
using SuperheroLevelCalculator.Models;
using SuperheroLevelCalculator.Views;

namespace SuperheroLevelCalculator.Controllers
{
    /// <summary>Получает данные от формы, проверяет их и меняет модель.</summary>
    public sealed class SuperheroController
    {
        private readonly SuperheroCalculatorModel model;
        private readonly MainForm mainForm;

        public SuperheroController(SuperheroCalculatorModel model, MainForm mainForm)
        {
            this.model = model;
            this.mainForm = mainForm;
            mainForm.EnterDataRequested += ShowInputForm;
        }

        private void ShowInputForm(object sender, EventArgs e)
        {
            using (InputForm inputForm = new InputForm(model.Data))
            {
                if (inputForm.ShowDialog(mainForm) != DialogResult.OK)
                    return;

                decimal height;
                decimal weight;
                int age;
                int pullUps;
                decimal sleep;
                if (!TryReadInput(inputForm, out height, out weight, out age, out pullUps, out sleep))
                    return;

                SuperheroData data;
                string error;
                if (!SuperheroData.TryCreate(height, weight, age, pullUps, sleep, out data, out error))
                {
                    MessageBox.Show(error, "Некорректные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                model.Update(data);
            }
        }

        private static bool TryReadInput(InputForm form, out decimal height, out decimal weight,
            out int age, out int pullUps, out decimal sleep)
        {
            height = 0;
            weight = 0;
            age = 0;
            pullUps = 0;
            sleep = 0;

            if (!decimal.TryParse(form.HeightText, NumberStyles.Number, CultureInfo.CurrentCulture, out height)
                || !decimal.TryParse(form.WeightText, NumberStyles.Number, CultureInfo.CurrentCulture, out weight)
                || !int.TryParse(form.AgeText, NumberStyles.Integer, CultureInfo.CurrentCulture, out age)
                || !int.TryParse(form.PullUpsText, NumberStyles.Integer, CultureInfo.CurrentCulture, out pullUps)
                || !decimal.TryParse(form.SleepText, NumberStyles.Number, CultureInfo.CurrentCulture, out sleep))
            {
                MessageBox.Show("Заполните все поля числами. Для дробной части используйте запятую или точку.",
                    "Некорректные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
