﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Drawing;

namespace FurCard.Models
{
    public class Character(string Name, string Species, CharGender Gender = CharGender.Unknown, int Age = 0, float Height = 0, float Weight = 0)
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = Name;
        public string Species { get; set; } = Species;
        public int Age { get; set; } = Age;
        public CharGender Gender { get; set; } = Gender;
        public float Height { get; set; } = Height;
        public float Weight { get; set; } = Weight;

        // TODO: Create PhysicalAttribute class, describing character's physical characteristics (Eye color, Fur/Scale/Feather coloration, build, etc.)
        // TODO: Create Personality class, describing traits, hobbies, likes, dislikes, etc.
        // TODO: Add contact information class - unrelated to character itself, but needed for card. Can accept a name

        public override string ToString()
        {
            // Build character card
            StringBuilder Character = new();
            Character.AppendLine($"{Name} ({Species}):");
            Character.AppendLine($"\tAge: {Age}, Gender: ${Gender}");
            Character.AppendLine($"\tHeight: {Height}m, Weight: ${Weight}kg");

            // Return character
            return Character.ToString();
        }

        public void Export(string OutPath, JsonSerializerOptions options)
        {
            // Check if OutPath is null or empty
            ArgumentOutOfRangeException.ThrowIfNullOrEmpty(OutPath);

            // Create parent directory
            Directory.CreateDirectory(Path.GetDirectoryName(OutPath)!);

            // Serialize JSON
            string JsonString;
            if (options != null) { JsonString = JsonSerializer.Serialize(this, options); }
            else { JsonString = JsonSerializer.Serialize(this, JsonSerializerOptions.Default); }

            // Write JSON
            File.WriteAllText(OutPath, JsonString);
        }
    }

    public enum CharGender { Unknown, Male, Female, Nonbinary, Other }
}
