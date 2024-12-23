namespace WpfApp7 
{
    public class Monster
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Heads { get; set; }
        public int AttackLevel { get; set; }
        public double Weight { get; set; }
        public double HeadWeight { get; set; }
        public double RecoveryProbability { get; set; } // Вероятность восстановления

        public Monster(int maxHealth, int currentHealth, int heads, int attackLevel, double weight, double headWeight, double recoveryProbability, double v)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            Heads = heads;
            AttackLevel = attackLevel;
            Weight = weight;
            HeadWeight = headWeight;
            RecoveryProbability = recoveryProbability;
        }

        public void Attack(Character character)
        {
            character.CurrentHealth -= AttackLevel; // Уменьшает здоровье персонажа на уровень атаки монстра
            if (character.CurrentHealth < 0) character.CurrentHealth = 0; // Здоровье не может быть отрицательным
        }

        public void Recover()
        {
            if (new Random().NextDouble() < RecoveryProbability) // Если удача
            {
                CurrentHealth = Math.Min(CurrentHealth + 10, MaxHealth); // Восстанавливает 10 НР, не превышая максимум
            }
        }
    }
}
