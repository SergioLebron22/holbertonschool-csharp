using System;

namespace Enemies {
    /// <summary>
    /// Represents a Zombie enemy character.
    /// </summary>
    public class Zombie {
        //health: represents the zombie's health
        //name: represents the zombie's name
        private int health;
        private string name = "(No name)";

        /// <summary>
        /// Constructor for zombie class
        /// </summary>
        public Zombie() {
            this.health = 0;
        }

        /// <summary>
        /// Constructor for zombie class
        /// </summary>
        public Zombie(int value) {
            if (value >= 0) this.health = value;
            else throw new ArgumentException("Health must be greater than or equal to 0");
        }
        /// <summary>
        /// Getter for zombie health property
        /// </summary>
        public int GetHealth() {
            return this.health;
        }

        /// <summary>
        /// Public property for the name of the zombie
        /// </summary>
        public string Name {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Overrides the toString function for the Zombie class
        /// </summary>
        public override string ToString() {
            return $"Zombie Name: {this.name} / Total Health: {this.health}";
        }
    }
}
