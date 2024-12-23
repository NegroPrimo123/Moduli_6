using System;

namespace WpfApp7 
{
    public class Character
    {
        public DateTime BattleDate { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public double AttackLevel { get; set; }
        public double InitialMoney { get; set; }
        public double HealingCost { get; set; }

        public Character(DateTime battleDate, int maxHealth, double attackLevel, double initialMoney, double healingCost)
        {
            BattleDate = battleDate;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth; // Начальное здоровье равно максимальному
            AttackLevel = attackLevel;
            InitialMoney = initialMoney;
            HealingCost = healingCost;
        }

        public void Heal()
        {
            if (InitialMoney >= HealingCost)
            {
                CurrentHealth = MaxHealth; // Восстанавливает здоровье до максимума
                InitialMoney -= HealingCost; // Уменьшает деньги на стоимость лечения
            }
        }

        public void Attack(Monster monster)
        {
            monster.CurrentHealth -= (int)AttackLevel; // Уменьшает здоровье монстра на уровень атаки
            if (monster.CurrentHealth < 0) monster.CurrentHealth = 0; // Здоровье не может быть отрицательным
        }

        public void SellMeat(int heads)
        {
            InitialMoney += heads * 5; // Примерная цена за голову
        }
    }
}
