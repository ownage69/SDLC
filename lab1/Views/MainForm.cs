using System;
using System.Drawing;
using System.Windows.Forms;
using SuperheroLevelCalculator.Models;

namespace SuperheroLevelCalculator.Views
{
    /// <summary>Главное представление. Оно наблюдает за активной моделью.</summary>
    public sealed class MainForm : Form
    {
        private readonly SuperheroCalculatorModel model;
        private readonly Label resultLabel;
        private readonly Label scoreLabel;
        private readonly Label dataLabel;

        public event EventHandler EnterDataRequested;

        public MainForm(SuperheroCalculatorModel model)
        {
            this.model = model;
            Text = "Калькулятор уровня супергероя";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(420, 335);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            Label titleLabel = new Label();
            titleLabel.Text = "Калькулятор уровня супергероя";
            titleLabel.Font = new Font(Font, FontStyle.Bold);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(78, 25);

            resultLabel = new Label();
            resultLabel.AutoSize = false;
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            resultLabel.Font = new Font(Font.FontFamily, 16, FontStyle.Bold);
            resultLabel.Location = new Point(25, 65);
            resultLabel.Size = new Size(370, 35);
            resultLabel.Text = "Введите данные для расчёта";

            scoreLabel = new Label();
            scoreLabel.AutoSize = false;
            scoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            scoreLabel.Location = new Point(25, 105);
            scoreLabel.Size = new Size(370, 25);

            dataLabel = new Label();
            dataLabel.AutoSize = false;
            dataLabel.Location = new Point(70, 135);
            dataLabel.Size = new Size(280, 100);

            Button enterButton = new Button();
            enterButton.Text = "Ввести данные";
            enterButton.Size = new Size(140, 32);
            enterButton.Location = new Point(140, 270);
            enterButton.Click += delegate { OnEnterDataRequested(); };

            Controls.Add(titleLabel);
            Controls.Add(resultLabel);
            Controls.Add(scoreLabel);
            Controls.Add(dataLabel);
            Controls.Add(enterButton);

            model.StateChanged += ModelStateChanged;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                model.StateChanged -= ModelStateChanged;
            base.Dispose(disposing);
        }

        private void ModelStateChanged(object sender, EventArgs e)
        {
            resultLabel.Text = model.Level;
            scoreLabel.Text = "Итоговый балл: " + model.Score + " из 100";

            SuperheroData data = model.Data;
            dataLabel.Text = string.Format(
                "Рост: {0:0.##} см\r\nВес: {1:0.##} кг\r\nВозраст: {2} лет\r\nПодтягивания: {3}\r\nСон: {4:0.##} ч.",
                data.HeightCm, data.WeightKg, data.Age, data.PullUps, data.SleepHours);
        }

        private void OnEnterDataRequested()
        {
            EventHandler handler = EnterDataRequested;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
