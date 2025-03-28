using System;

class Player {
    private string name {get; set;}
    private float maxHp {get; set;}
    private float hp {get; set;}

    public Player(string name = "Player", float maxHp = 100f) {
        if (maxHp <= 0) {
            maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        
        this.name = name;
        this.maxHp = maxHp;
        this.hp = maxHp;
    }

    public void PrintHealth() {
        Console.Write($"{name} has {hp} / {maxHp} health\n");
    }

    public delegate void CalculateHealth(float damage);

    public void TakeDamage(float damage) {
        if (damage < 0) {
            damage = 0;
        }
        Console.WriteLine($"{name} takes {damage} damage!");
    }

    public void HealDamage(float heal) {
        if (heal < 0) {
            heal = 0;
        }
        Console.WriteLine($"{name} heals {heal} HP!");
    }
}