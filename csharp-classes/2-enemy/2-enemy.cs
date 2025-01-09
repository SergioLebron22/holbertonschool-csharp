using System;

namespace Enemies {
    /// <summary>
    /// Represents a Zombie enemy character.
    /// </summary>
    public class Zombie {
        /// <summary>
        /// Represents the health of the zombie
        /// </summary>
        public int health;

        /// <summary>
        /// Constructor for zombie class
        /// </summary>
        public Zombie() {
            health = 0;
        }
        /// <summary>
        /// Constructor for zombie class
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public Zombie(int value) {
            if (value < 0) throw new ArgumentException("Health must be greater or equal to 0");
            else health = value;
        }
    }
}
