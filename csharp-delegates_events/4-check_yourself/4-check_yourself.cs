using System;

public enum Modifier {
    Weak,
    Base,
    Strong
}

public delegate float CalculateModifier(float baseValue, Modifier modifier);

class CurrentHPArgs : EventArgs {
    public float currentHp { get; }

    public CurrentHPArgs(float newHp) {
        currentHp = newHp;
    }
}

class Player {
    private string name {get; set;}
    private float maxHp {get; set;}
    private float hp {get; set;}

    private string status;

    EventHandler<CurrentHPArgs> HPCheck;

    public Player(string name = "Player", float maxHp = 100f) {
        if (maxHp <= 0) {
            maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        
        this.name = name;
        this.maxHp = maxHp;
        this.hp = maxHp;
        this.status = $"{name} is ready to go!";

        HPCheck += CheckStatus;
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
        ValidateHP(hp - damage);
    }

    public void HealDamage(float heal) {
        if (heal < 0) {
            heal = 0;
        }
        Console.WriteLine($"{name} heals {heal} HP!");
        ValidateHP(hp + heal);
    }

    public void ValidateHP(float newHp) {
        if (newHp < 0) {
            hp = 0;
        }
        else if (newHp > maxHp) {
            hp = maxHp;
        }
        else {
            hp = newHp;
        }
        HPCheck(this, new CurrentHPArgs(hp));
    }

    public float ApplyModifier(float baseValue, Modifier modifier) {
        if (modifier == Modifier.Weak) {
            return baseValue / 2;
        }
        if (modifier == Modifier.Base) {
            return baseValue;
        }
        if (modifier == Modifier.Strong) {
            return baseValue * 1.5f;
        }
        return baseValue;
    }

    private void CheckStatus(object sender, CurrentHPArgs e) {
        if (e.currentHp == maxHp) {
            Console.WriteLine($"{name} is in perfect health!");
        }
        else if (e.currentHp >= maxHp / 2 && e.currentHp < maxHp) {
            Console.WriteLine($"{name} is doing well!");
        }
        else if (e.currentHp >= maxHp / 4 && e.currentHp < maxHp / 2) {
            Console.WriteLine($"{name} isn't doing too great...");
        }
        else if (e.currentHp > 0 && e.currentHp < maxHp / 4) {
            Console.WriteLine($"{name} needs help!");
        }
        else if (e.currentHp == 0) {
            Console.WriteLine($"{name} is knocked out!");
        }
    }
    
}

