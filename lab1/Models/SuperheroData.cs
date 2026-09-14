namespace SuperheroLevelCalculator.Models
{
    /// <summary>Данные, введённые пользователем.</summary>
    public sealed class SuperheroData
    {
        public decimal HeightCm { get; private set; }
        public decimal WeightKg { get; private set; }
        public int Age { get; private set; }
        public int PullUps { get; private set; }
        public decimal SleepHours { get; private set; }

        private SuperheroData(decimal heightCm, decimal weightKg, int age, int pullUps, decimal sleepHours)
        {
            HeightCm = heightCm;
            WeightKg = weightKg;
            Age = age;
            PullUps = pullUps;
            SleepHours = sleepHours;
        }

        public static bool TryCreate(decimal heightCm, decimal weightKg, int age, int pullUps,
            decimal sleepHours, out SuperheroData data, out string error)
        {
            data = null;
            error = null;

            if (heightCm < 100 || heightCm > 250)
                error = "Рост должен быть от 100 до 250 см.";
            else if (weightKg < 30 || weightKg > 300)
                error = "Вес должен быть от 30 до 300 кг.";
            else if (age < 10 || age > 100)
                error = "Возраст должен быть от 10 до 100 лет.";
            else if (pullUps < 0 || pullUps > 100)
                error = "Количество подтягиваний должно быть от 0 до 100.";
            else if (sleepHours < 0 || sleepHours > 24)
                error = "Количество часов сна должно быть от 0 до 24.";
            else
                data = new SuperheroData(heightCm, weightKg, age, pullUps, sleepHours);

            return data != null;
        }
    }
}
