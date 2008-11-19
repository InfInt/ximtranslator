using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace xEmulate
{
    class BetaGamesManager
    {

        public static string[] GameNames = new string[]
        { 
            "Unreal Tournament 3 (ut3) (20 sens, 10 accel)",
            "Call of Duty 4 (cod4) (10 sens)",
            "Halo 3 (halo3) (10 sens)",
            "",
            "",
            "Left For Dead"
        };

        private Dictionary<GamesManager.Games, GameSettings> gameSettings;

        public class GameSettings
        {
            public GameSettings(MouseAlgorithm transAlg, int deadzone, bool circularDeadzone, double diagonalCoeff, double smoothing)
            {
                this.TransAlg = transAlg;
                this.Circular = circularDeadzone;
                this.Deadzone = deadzone;
                this.DiagonalCoeff = diagonalCoeff;
                this.Smoothing = smoothing;
            }
            public MouseAlgorithm TransAlg { get; set; }
            public bool Circular { get; set; }
            public int Deadzone { get; set; }
            public double DiagonalCoeff { get; set; }
            public double Smoothing { get; set; }

        }

        private BetaGamesManager()
        {
            gameSettings = new Dictionary<GamesManager.Games, GameSettings>();

            gameSettings.Add(GamesManager.Games.L4D, new GameSettings(
                                               new XYLinkedAlgorithm(
                                                   new XYLinkedTrans[]{
                                                       new XYLinkedPowerTrans(
                                                           new TransAcceleration(0,0),
                                                          68271, // Speed
                                                           1, // Exp
                                                           -1, // Min Speed
                                                           0.25835 // Max Speed
                                                           ),
                                                       new XYLinkedPowerTrans(
                                                           new TransAcceleration( 1 , 1 ),
                                                           40238, // Speed
                                                           1,
                                                           0.5, // Min Speed
                                                           1.69 // Max Speed
                                                           ),
                                                   }),
                                                   8690, // Deadzone
                                                   false, //Circular Deadzone
                                                   0.35, // diagonalCoeff
                                                   0 // Smoothing
                                               ));

                                                   /*new Mouse(
                                                   68271, // Speed
                                                   1, // Exp
                                                   26300, // Cap
                                                   -1, // Min Speed
                                                   0.25835, // Max Speed
                                                   0 // CarryZone 
                                                   ),
                                                   new MouseAlgs.PowerFunction(
                                                   14238, // Speed
                                                   1,
                                                   26300, // Cap
                                                   1.5, // Min Speed
                                                   1.69, // Max Speed
                                                   0 // CarryZone 
                                                   ),
                                                   new MouseAlgs.PowerFunction(
                                                   14238, // Speed
                                                   1,
                                                   26300, // Cap
                                                   1.5, // Min Speed
                                                   1.69, // Max Speed
                                                   0 // CarryZone 
                                                   ),
                                               },*/

           /* gameSettings.Add(GamesManager.Games.L4D, new GameSettings(
                                               new MouseAlgs.Algorithm[]{ 
                                                   new MouseAlgs.PowerFunction(
                                                   68271, // Speed
                                                   1, // Exp
                                                   26300, // Cap
                                                   -1, // Min Speed
                                                   0.25835, // Max Speed
                                                   0 // CarryZone 
                                                   ),
                                                   new MouseAlgs.PowerFunction(
                                                   14238, // Speed
                                                   1,
                                                   26300, // Cap
                                                   1.5, // Min Speed
                                                   1.69, // Max Speed
                                                   0 // CarryZone 
                                                   ),
                                                   new MouseAlgs.PowerFunction(
                                                   14238, // Speed
                                                   1,
                                                   26300, // Cap
                                                   1.5, // Min Speed
                                                   1.69, // Max Speed
                                                   0 // CarryZone 
                                                   ),
                                               },
                                               new MouseAlgs.Algorithm[]{ 
                                                   new MouseAlgs.PowerFunction(
                                                   68271, // Speed
                                                   1, // Exp
                                                   26300, // Cap
                                                   -1, // Min Speed
                                                   0.25835, // Max Speed
                                                   0 // CarryZone 
                                                   ),
                                                   new MouseAlgs.PowerFunction(
                                                   14238, // Speed
                                                   1,
                                                   26300, // Cap
                                                   1.5, // Min Speed
                                                   1.69, // Max Speed
                                                   0 // CarryZone 
                                                   ),
                                               },
                                               8690, // Deadzone
                                               false, //Circular Deadzone
                                               0.35, // diagonalCoeff
                                               0 // Smoothing
                                            ) // GameSettings
                            ); // Add*/
        }



        public static BetaGamesManager Instance
        {
            get { return Singleton<BetaGamesManager>.Instance; }
        }

        public GameSettings GetGameSettings(GamesManager.Games game)
        {
            GameSettings settings;
            gameSettings.TryGetValue(game, out settings);
            return settings;
        }
    }
}
