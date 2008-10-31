using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace xEmulate
{
    class GamesManager2
    {
        // Games and GameNames must be in the same order.
        public enum Games
        {
            Ut3 = 0,
            Cod4 = 1,
            //Halo3 = 2,
        }

        public static string[] GameNames = new string[]
        { 
            "Unreal Tournament 3 (ut3) (20 sens, 10 accel)",
            "Call of Duty 4 (cod4) (10 sens)",
            //"Halo 3 (halo3)",
        };

        private Dictionary<Games, GameSettings> gameSettings;

        public class GameSettings
        {
            public GameSettings(MouseAlgs.Algorithm XAxis, MouseAlgs.Algorithm YAxis, int deadzone, bool circularDeadzone)
            {
                this.XAxis = XAxis;
                this.YAxis = YAxis;
                this.Circular = circularDeadzone;
                this.Deadzone = deadzone;
            }
            public MouseAlgs.Algorithm XAxis { get; set; }
            public MouseAlgs.Algorithm YAxis { get; set; }
            public bool Circular { get; set; }
            public int Deadzone { get; set; }

        }

        private GamesManager2()
        {
            gameSettings = new Dictionary<Games, GameSettings>();

            gameSettings.Add(Games.Ut3, new GameSettings(new MouseAlgs.PowerFunction(
                                                31075, // Speed
                                                0.4789, // Exp
                                                32000, // Cap
                                                2.5, // Max Speed
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
                                                false // circularDeadzone
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
                                               16513, // Speed
                                               0.3775, // Exp
                                               99999, // Cap
                                               99999, // Max Speed
                                               0 // CarryZone 
                                               ),
                                               /*new MouseAlgs.PolynomialFunction(
                                               0, // x^2 coeff
                                               2000, // x coeff
                                               8038.4, // yintercept
                                               99999, // Cap
                                               99999, // Max Speed
                                               0 // CarryZone 
                                               ),*/
                                               7000, // Deadzone
                                               true //Circular Deadzone
                                            ) // GameSettings
                            ); // Add

        }

        public static GamesManager2 Instance
        {
            get { return Singleton<GamesManager2>.Instance; }
        }

        public GameSettings GetGameSettings(Games game)
        {
            GameSettings settings;
            gameSettings.TryGetValue(game, out settings);
            return settings;
        }
    }
}
