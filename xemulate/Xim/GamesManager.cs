using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace xEmulate
{
    class GamesManager
    {
        // Games and GameNames must be in the same order.
        public enum Games
        {
            Ut3 = 0,
            //Cod4 = 1,
            //Halo3 = 2,
        }

        public static string[] GameNames = new string[]
        { 
            "Unreal Tournament 3 (ut3)",
            //"Call of Duty 4 (cod4)",
            //"Halo 3 (halo3)",
        };

        private Dictionary<Games, Settings> gameSettings;

        public class Settings
        {
            public Settings(double speed, double exponent, int deadzone, int cap, double maxSpeed, bool circularDeadzone, double pitch, double yaw, Vector2 carryZone)
            {
                this.Speed = speed;
                this.Exp = exponent;
                this.Deadzone = deadzone;
                this.Cap = cap;
                this.MaxSpeed = maxSpeed;
                this.Circular = circularDeadzone;
                this.CarryZone = carryZone;
                this.Yaw = yaw;
                this.Pitch = pitch;
            }
            public Vector2 CarryZone { get; set; }
            public double Pitch { get; set; }
            public double Yaw { get; set; }
            public double Speed { get; set; }
            public double Exp { get; set; }
            public int Deadzone { get; set; }
            public int Cap { get; set; }
            public double MaxSpeed { get; set; }
            public bool Circular { get; set; }
        }

        private GamesManager()
        {
            gameSettings = new Dictionary<Games, Settings>();
            
            gameSettings.Add(Games.Ut3, new Settings(
                31075, // Speed
                0.4789, // Exp
                6200, // Deadzone
                32000, // Cap
                2.5, // Max Speed
                false, //Circular Deadzone
                0.22, // Pitch
                0.22, // Yaw
                new Vector2(0, 10000) // CarryZone
                ));

        }

        public static GamesManager Instance
        {
            get { return Singleton<GamesManager>.Instance; }
        }

        public Settings GetGameSettings(Games game)
        {
            Settings settings;
            gameSettings.TryGetValue(game, out settings);
            return settings;
        }
    }
}
