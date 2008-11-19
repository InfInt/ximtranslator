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
            Bio,
            Cod4,
            Gow2,
            Gta4,
            HL2,
            Halo3,
            L4D,
            R6v,
            Ut3,
        }

        public static string[] GameNames = new string[]
        { 
            "Bioshock (bio) (100 sens)",
            "Call of Duty 4 (cod4) (10 sens)",
            "Gears of War 2 (gow2) (High, High, High)",
            "Grand Theft Auto IV (gta4) (High)",
            "Half Life 2 - Orange Box (hl2) (Max) (Max)",
            "Halo 3 (halo3) (10 sens)",
            "Left For Dead (l4d) (Max) (Max)",
            "Rainbow Six - Vegas (r6v) (10 sens)",
            "Unreal Tournament 3 (ut3) (20 sens, 10 accel)",
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
                                                -1, // Min Speed
                                                2.9, // Max Speed
                                                -1 // CarryZone
                                                ),
                                                new MouseAlgs.PowerFunction(
                                                31075, // Speed
                                                0.4789, // Exp
                                                32000, // Cap
                                               -1, // Min Speed
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
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               -1 // CarryZone
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               24220, // Speed
                                               0.4014, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               -1 // CarryZone 
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
                                               -1, // Min Speed
                                               3.5, // Max Speed
                                               -1 // CarryZone 
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               26084, // Speed
                                               .3992, // Exp
                                               31000, // Cap
                                               -1, // Min Speed
                                               2.9, // Max Speed
                                               -1 // CarryZone 
                                               ),
                                               6000, // Deadzone
                                               false, //Circular Deadzone
                                               0.35, // diagonalCoeff
                                               0.25 // Smoothing
                                            ) // GameSettings
                            ); // Add

            gameSettings.Add(Games.Gow2, new GameSettings(
                                               new MouseAlgs.PowerFunction(
                                               30000, // Speed
                                               .9, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               10000 // CarryZone 
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               30000, // Speed
                                               .9, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               10000 // CarryZone 
                                               ),
                                               9400, // Deadzone
                                               false, //Circular Deadzone
                                               0.25, // diagonalCoeff
                                               0 // Smoothing
                                            ) // GameSettings
                            ); // Add

            gameSettings.Add(Games.Gta4, new GameSettings(
                                               new MouseAlgs.PowerFunction(
                                               28000, // Speed
                                               .8, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               -1 // CarryZone 
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               28000, // Speed
                                               .8, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               -1 // CarryZone 
                                               ),
                                               7400, // Deadzone
                                               false, //Circular Deadzone
                                               0.30, // diagonalCoeff
                                               0.1 // Smoothing
                                            ) // GameSettings
                            ); // Add

            
            gameSettings.Add(Games.HL2, new GameSettings(
                                               new MouseAlgs.PowerFunction(
                                               40000, // Speed
                                               1, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               -1 // CarryZone 
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               40000, // Speed
                                               1, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               -1 // CarryZone 
                                               ),
                                               8960, // Deadzone 
                                               false, //Circular Deadzone
                                               0.35, // diagonalCoeff
                                               0 // Smoothing
                                            ) // GameSettings
                            ); // Add
            
            gameSettings.Add(Games.L4D, this.GetGameSettings(Games.HL2));

            gameSettings.Add(Games.R6v, new GameSettings(
                                               new MouseAlgs.PowerFunction(
                                               30000, // Speed
                                               .5, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               -1 // CarryZone 
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               60000, // Speed
                                               .5, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               -1 // CarryZone 
                                               ),
                                               6800, // Deadzone
                                               false, //Circular Deadzone
                                               0.25, // diagonalCoeff
                                               0 // Smoothing
                                            ) // GameSettings
                            ); // Add

            gameSettings.Add(Games.Bio, new GameSettings(
                                               new MouseAlgs.PowerFunction(
                                               28000, // Speed
                                               .8, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               8000 // CarryZone 
                                               ),
                                               new MouseAlgs.PowerFunction(
                                               45000, // Speed
                                               .8, // Exp
                                               -1, // Cap
                                               -1, // Min Speed
                                               -1, // Max Speed
                                               8000 // CarryZone 
                                               ),
                                               5500, // Deadzone
                                               false, //Circular Deadzone
                                               0.30, // diagonalCoeff
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
