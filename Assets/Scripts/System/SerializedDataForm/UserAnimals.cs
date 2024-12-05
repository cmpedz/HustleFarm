
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
    public class UserAnimals
    {
        public static readonly string Id = "UserAnimals";

        public List<string> Animals;

        public UserAnimals() { Animals = new List<string>(); }
    }

