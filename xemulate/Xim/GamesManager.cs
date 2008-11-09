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
            Cod4 = 1,
            Halo3 = 2,
            Gow2 = 3,
            Halo3_tweak = 4,
        }

        public static string[] GameNames = new string[]
        { 
            "Unreal Tournament 3 (ut3) (20 sens, 10 accel)",
            "Call of Duty 4 (cod4) (10 sens)",
            "Halo 3 (halo3) (10 sens)",
            "Gears of War 2(gow2) (High, High, Med)",
            "Halo 3 (halo3_tweak) (10 sens) - (6000 deadzone"
        };

        private Dictionary<Games, GameSettings> gameSettings;

        public class GameSettings
        {
            public GameSettings(MouseAlgs.Algorithm XAxis, MouseAlgs.Algorithm YAxis, int deadzone, bool circularDeadzone, double diagonalCoeff, double smoothing)
            {
                this.XAxis = XAxis;
                this.YAxis = YAxis;
                this.Circular = circularDeadzone;
                this.Deadzone = deadzone;
                this.DiagonalCoeff = diagonalCoeff;
                this.Smoothing = smoothing;
            }
            public MouseAlgs.Algorithm XAxis { get; set; }
            public MouseAlgs.Algorithm YAxis { get; set; }
            public bool Circular { get; set; }
            public int Deadzone { get; set; }
            public double DiagonalCoeff { get; set; }
            public double Smoothing { get; set; }

        }

        private GamesManager()
        {
            gameSettings = new Dictionary<Games, GameSettings>();

            gameSettings.Add(Games.Ut3, new GameSettings(new MouseAlgs.PowerFunction(
                                                31075, // Speed
                                                0.4789, // Exp
                                                32000, // Cap
                                                2.9, // Max Speed
                                                0 // CarryZone
                                                ),
                                                new MouseAlgs.PowerFunction(
                                                31075, // Speed
                                                0.4789, // Exp
                                                32000, // Cap
                                                2.5, // Max Speed
                                                10000 // CarryZone
                                                ),
                                                6200, // deadzone
                                                false, // circularDeadzone
                                                0, // diagonalCoeff
                                                0.1 // smoothing
                                            ) // GameSettings
                            ); // Add

            gameSettings.Add(Games.Cod4, new GameSettings(
                                               new MouseAlgs.PowerFunction(
                                               16513, // Speed
                                               0.3775, // Exp
                                               99999, // Cap
                                               99999, // Max Speed
                                               0 // CarryZone
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               24220, // Speed
                                               0.4014, // Exp
                                               99999, // Cap
                                               99999, // Max Speed
                                               0 // CarryZone 
                                               ),
                                               7000, // Deadzone
                                               true, //Circular Deadzone
                                               0, // diagonalCoeff
                                               0 // smoothing
                                            ) // GameSettings
                            ); // Add
            gameSettings.Add(Games.Halo3, new GameSettings(
                                               new MouseAlgs.PowerFunction(
                                               19044, // Speed
                                               .4544, // Exp
                                               31000, // Cap
                                               3.5, // Max Speed
                                               0 // CarryZone 
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               26084, // Speed
                                               .3992, // Exp
                                               31000, // Cap
                                               2.9, // Max Speed
                                               0 // CarryZone 
                                               ),
                                               7000, // Deadzone
                                               false, //Circular Deadzone
                                               0.35, // diagonalCoeff
                                               0.25 // Smoothing
                                            ) // GameSettings
                            ); // Add

            gameSettings.Add(Games.Halo3_tweak, new GameSettings(
                                               new MouseAlgs.PowerFunction(
                                               19044, // Speed
                                               .4544, // Exp
                                               31000, // Cap
                                               3.5, // Max Speed
                                               0 // CarryZone 
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               26084, // Speed
                                               .3992, // Exp
                                               31000, // Cap
                                               2.9, // Max Speed
                                               0 // CarryZone 
                                               ),
                                               6000, // Deadzone
                                               false, //Circular Deadzone
                                               0.35, // diagonalCoeff
                                               0.25 // Smoothing
                                            ) // GameSettings
                            ); // Add

            gameSettings.Add(Games.Gow2, new GameSettings(
                                               new MouseAlgs.PowerFunction(
                                               19044, // Speed
                                               .4544, // Exp
                                               31000, // Cap
                                               1.5, // Max Speed
                                               0 // CarryZone 
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               26084, // Speed
                                               .3992, // Exp
                                               31000, // Cap
                                               1.5, // Max Speed
                                               0 // CarryZone 
                                               ),
                                               7000, // Deadzone
                                               false, //Circular Deadzone
                                               0.35, // diagonalCoeff
                                               0.1 // Smoothing
                                            ) // GameSettings
                            ); // Add
        }



        public static GamesManager Instance
        {
            get { return Singleton<GamesManager>.Instance; }
        }

        public GameSettings GetGameSettings(Games game)
        {
            GameSettings settings;
            gameSettings.TryGetValue(game, out settings);
            return settings;
        }
    }
}
