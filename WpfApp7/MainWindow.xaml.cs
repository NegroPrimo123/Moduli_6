using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp7
{
    public partial class MainWindow : Window
    {
        private Character character;
        private List<Monster> monsters = new List<Monster>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCreateCharacterClick(object sender, RoutedEventArgs e)
        {
            if (ValidateCharacterInput())
            {
                DateTime battleDate = DateTime.Parse(BattleDateTextBox.Text);
                int maxHealth = int.Parse(MaxHealthTextBox.Text);
                double attackLevel = double.Parse(AttackLevelTextBox.Text);
                double initialMoney = double.Parse(InitialMoneyTextBox.Text);
                double healingCost = double.Parse(HealingCostTextBox.Text);

                character = new Character(battleDate, maxHealth, attackLevel, initialMoney, healingCost);
                MessageBox.Show("Персонаж создан!");
            }
        }

        private void OnAddMonsterClick(object sender, RoutedEventArgs e)
        {
            // Пример добавления монстра
            Monster monster = new Monster(100, 100, 1, 10, 1, 50.0, 10.0, 0.2);
            monsters.Add(monster);
            MonstersListBox.Items.Add($"Монстр: НР {monster.CurrentHealth}/{monster.MaxHealth}, Уровень атаки {monster.AttackLevel}");
            MessageBox.Show("Монстр добавлен!");
        }

        private void OnStartBattleClick(object sender, RoutedEventArgs e)
        {
            if (character == null || monsters.Count == 0)
            {
                MessageBox.Show("Создайте персонажа и добавьте монстров перед началом битвы!");
                return;
            }

            Random rand = new Random();
            Monster selectedMonster = monsters[rand.Next(monsters.Count)];

            while (character.CurrentHealth > 0 && selectedMonster.CurrentHealth > 0)
            {
                // Персонаж атакует монстра
                character.Attack(selectedMonster);
                selectedMonster.Recover();
                if (selectedMonster.CurrentHealth > 0)
                {
                    // Монстр атакует персонажа
                    selectedMonster.Attack(character);
                }
            }

            if (character.CurrentHealth > 0)
            {
                MessageBox.Show("Вы победили монстра!");
            }
            else
            {
                MessageBox.Show("Вы проиграли битву!");
            }
        }

        private void OnResetClick(object sender, RoutedEventArgs e)
        {
            BattleDateTextBox.Clear();
            MaxHealthTextBox.Clear();
            AttackLevelTextBox.Clear();
            InitialMoneyTextBox.Clear();
            HealingCostTextBox.Clear();
            monsters.Clear();
            MonstersListBox.Items.Clear();
            character = null;
        }

        private bool ValidateCharacterInput()
        {
            // Валидация вводимых данных
            if (!DateTime.TryParse(BattleDateTextBox.Text, out _))
            {
                MessageBox.Show("Некорректная дата сражения.");
                return false;
            }

            if (!int.TryParse(MaxHealthTextBox.Text, out int maxHealth) || maxHealth <= 0)
            {
                MessageBox.Show("Максимальное НР должно быть положительным целым числом.");
                return false;
            }

            if (!double.TryParse(AttackLevelTextBox.Text, out double attackLevel) || attackLevel <= 0)
            {
                MessageBox.Show("Уровень атаки должен быть положительным числом.");
                return false;
            }

            if (!double.TryParse(InitialMoneyTextBox.Text, out double initialMoney) || initialMoney < 0)
            {
                MessageBox.Show("Начальное число денег должно быть неотрицательным числом.");
                return false;
            }

            if (!double.TryParse(HealingCostTextBox.Text, out double healingCost) || healingCost <= 0)
            {
                MessageBox.Show("Стоимость лечения должна быть положительным числом.");
                return false;
            }

            return true;
        }
    }
}
