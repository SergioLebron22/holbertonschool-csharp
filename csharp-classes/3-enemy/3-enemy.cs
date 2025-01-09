using System;

namespace Enemies {
    /// <summary>
    /// Represents a Zombie enemy character.
    /// </summary>
    public class Zombie {
        /// <summary>
        /// Represents the health of the zombie
        /// </summary>
        private int health;

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
    }
}
