using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Drawing;

namespace FurCard.Models
{
    public class Character
    {
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Sex { get; set; } = string.Empty;
        public float Height { get; set; } = 0;
        public float Weight { get; set; } = 0;
        public Color EyeColor { get; set; } = Color.Empty;
        public List<Color> BodyColors { get; set; } = new List<Color>();
        // public List<string> PhysicalTraits { get; set; } = new List<string>();
        // public List<string> MentalTraits { get; set; } = new List<string>();
        // public List<string> Skills { get; set; } = new List<string>();
        // public List<string> Equipment { get; set; } = new List<string>();
        public string Background { get; set; } = string.Empty;

        public override string ToString()
        {
            // Build character card
            StringBuilder Character = new StringBuilder();
            Character.AppendLine($"{Name} ({Species}):");
            Character.AppendLine($"\tAge: {Age}, Sex: ${Sex}");
            Character.AppendLine($"\tHeight: {Height}m, Weight: ${Weight}kg");
            Character.AppendLine($"\tEye Color: ${EyeColor.Name}");
            Character.AppendLine($"\tBody Color(s):");

            // List all body colors, but don't have a comma for the last color.
            for (int i = 0; i <= BodyColors.Count; i++)
            {
                if (i < BodyColors.Count) { Character.AppendLine($"\t\t{BodyColors[i].Name},"); }
                else { Character.AppendLine($"\t\t{BodyColors[i].Name}"); }
            }

            Character.AppendLine($"\tBackground: {Background}");

            // Return character
            return Character.ToString();
        }

        public void Export(string OutPath, JsonSerializerOptions options)
        {
            // Check if OutPath is null or empty
            if (string.IsNullOrEmpty(OutPath)) { throw new ArgumentOutOfRangeException("OutPath cannot be null or empty."); }

            else {
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
    }   
}
