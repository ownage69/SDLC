using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using SuperheroLevelCalculator.Models;

namespace SuperheroLevelCalculator.Views
{
    /// <summary>Окно ввода. Оно не рассчитывает результат и не меняет модель.</summary>
    public sealed class InputForm : Form
    {
        private readonly TextBox heightTextBox;
        private readonly TextBox weightTextBox;
        private readonly TextBox ageTextBox;
        private readonly TextBox pullUpsTextBox;
        private readonly TextBox sleepTextBox;

        public string HeightText { get { return heightTextBox.Text; } }
        public string WeightText { get { return weightTextBox.Text; } }
        public string AgeText { get { return ageTextBox.Text; } }
        public string PullUpsText { get { return pullUpsTextBox.Text; } }
        public string SleepText { get { return sleepTextBox.Text; } }

        public InputForm(SuperheroData previousData)
        {
            Text = "Ввод данных";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(365, 270);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            TableLayoutPanel fields = new TableLayoutPanel();
            fields.ColumnCount = 2;
            fields.RowCount = 5;
            fields.Location = new Point(18, 18);
            fields.Size = new Size(330, 165);
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));

            heightTextBox = AddField(fields, 0, "Рост, см:");
            weightTextBox = AddField(fields, 1, "Вес, кг:");
            ageTextBox = AddField(fields, 2, "Возраст, лет:");
            pullUpsTextBox = AddField(fields, 3, "Подтягивания, раз:");
            sleepTextBox = AddField(fields, 4, "Сон, часов:");

            Button saveButton = new Button();
            saveButton.Text = "Рассчитать";
            saveButton.DialogResult = DialogResult.OK;
            saveButton.Size = new Size(110, 30);
            saveButton.Location = new Point(118, 205);

            Button cancelButton = new Button();
            cancelButton.Text = "Отмена";
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Size = new Size(80, 30);
            cancelButton.Location = new Point(243, 205);

            Controls.Add(fields);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            AcceptButton = saveButton;
            CancelButton = cancelButton;

            if (previousData != null)
                Restore(previousData);
        }

        private static TextBox AddField(TableLayoutPanel fields, int row, string labelText)
        {
            Label label = new Label();
            label.Text = labelText;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Dock = DockStyle.Fill;

            TextBox textBox = new TextBox();
            textBox.Dock = DockStyle.Fill;

            fields.Controls.Add(label, 0, row);
            fields.Controls.Add(textBox, 1, row);
            return textBox;
        }

        private void Restore(SuperheroData data)
        {
            heightTextBox.Text = data.HeightCm.ToString(CultureInfo.CurrentCulture);
            weightTextBox.Text = data.WeightKg.ToString(CultureInfo.CurrentCulture);
            ageTextBox.Text = data.Age.ToString(CultureInfo.CurrentCulture);
            pullUpsTextBox.Text = data.PullUps.ToString(CultureInfo.CurrentCulture);
            sleepTextBox.Text = data.SleepHours.ToString(CultureInfo.CurrentCulture);
        }
    }
}
