using System;

namespace SuperheroLevelCalculator.Models
{
    /// <summary>
    /// Активная модель: после изменения данных вызывает StateChanged,
    /// чтобы подписанные представления обновились сами.
    /// </summary>
    public sealed class SuperheroCalculatorModel
    {
        public event EventHandler StateChanged;

        public SuperheroData Data { get; private set; }
        public string Level { get; private set; }
        public int Score { get; private set; }

        public void Update(SuperheroData data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            Data = data;
            Score = CalculateScore(data);
            Level = CalculateLevel(data, Score);
            OnStateChanged();
        }

        private static int CalculateScore(SuperheroData data)
        {
            decimal heightInMeters = data.HeightCm / 100m;
            decimal bmi = data.WeightKg / (heightInMeters * heightInMeters);
            int score = 0;

            if (data.PullUps >= 20) score += 30;
            else if (data.PullUps >= 10) score += 20;
            else if (data.PullUps >= 5) score += 10;

            if (data.SleepHours >= 7 && data.SleepHours <= 9) score += 30;
            else if (data.SleepHours >= 6 && data.SleepHours <= 10) score += 20;
            else if (data.SleepHours >= 5 && data.SleepHours <= 11) score += 10;

            if (bmi >= 18.5m && bmi < 30m) score += 20;
            else if (bmi >= 16m && bmi < 35m) score += 10;

            if (data.Age >= 18 && data.Age <= 45) score += 20;
            else if (data.Age >= 14 && data.Age <= 55) score += 10;

            return score;
        }

        private static string CalculateLevel(SuperheroData data, int score)
        {
            // Сон меньше 5 часов — признак переутомления, важнее остальных баллов.
            if (data.SleepHours < 5)
                return "Нужно срочно в отпуск";
            if (score >= 80)
                return "Легенда";
            if (score >= 50)
                return "Герой";
            return "Стажёр";
        }

        private void OnStateChanged()
        {
            EventHandler handler = StateChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        internal static void RunSelfCheck()
        {
            SuperheroData legend;
            string error;
            if (!SuperheroData.TryCreate(180m, 75m, 25, 20, 8m, out legend, out error))
                throw new InvalidOperationException(error);

            SuperheroCalculatorModel model = new SuperheroCalculatorModel();
            bool wasNotified = false;
            model.StateChanged += delegate { wasNotified = true; };
            model.Update(legend);

            if (!wasNotified || model.Level != "Легенда" || model.Score != 100)
                throw new InvalidOperationException("Проверка модели не пройдена.");

            SuperheroData vacation;
            if (!SuperheroData.TryCreate(170m, 65m, 30, 25, 4m, out vacation, out error))
                throw new InvalidOperationException(error);
            model.Update(vacation);
            if (model.Level != "Нужно срочно в отпуск")
                throw new InvalidOperationException("Проверка правила сна не пройдена.");

            SuperheroData invalid;
            if (SuperheroData.TryCreate(90m, 65m, 30, 5, 8m, out invalid, out error))
                throw new InvalidOperationException("Проверка валидации не пройдена.");
        }
    }
}
