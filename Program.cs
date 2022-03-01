using System;

namespace mis321_pa2_mdbrown17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Character playerOne = new Character();
            Character playerTwo = new Character();

            string[] myArray = new string[5];
            myArray[0] = ("PlayerOne");
            myArray[1] = ("PlayerTwo");
            myArray[2] = ("1");
            myArray[3] = ("1");
            myArray[4] = ("play");

            myArray = MainMenu();

            while(myArray[4] == "play")
            {
                int p1MaxPwr = MaxPowerGenerator.GetMaxPwr();
                int p1AtkStr = AttackStrengthGenerator.GetAttackStr(p1MaxPwr);
                int p1DefPwr = DefensePowerGenerator.GetDefPower(p1MaxPwr);

                switch(myArray[2])
                {
                    case "1":
                    playerOne = new JackSparrow() {name = myArray[0], maxPower = p1MaxPwr, health = 100, attackStrength = p1AtkStr, defensePower = p1DefPwr};
                    break;

                    case "2":
                    playerOne = new DavyJones() {name = myArray[0], maxPower = p1MaxPwr, health = 100, attackStrength = p1AtkStr, defensePower = p1DefPwr};
                    break;

                    case "3":
                    playerOne = new WillTurner() {name = myArray[0], maxPower = p1MaxPwr, health = 100, attackStrength = p1AtkStr, defensePower = p1DefPwr};
                    break;
                }

                int p2MaxPwr = MaxPowerGenerator.GetMaxPwr();
                int p2AtkStr = AttackStrengthGenerator.GetAttackStr(p2MaxPwr);
                int p2DefPwr = DefensePowerGenerator.GetDefPower(p2MaxPwr);

                switch(myArray[3])
                {
                    case "1":
                    playerTwo = new JackSparrow() {name = myArray[1], maxPower = p2MaxPwr, health = 100, attackStrength = p2AtkStr, defensePower = p2DefPwr};
                    break;

                    case "2":
                    playerTwo = new DavyJones() {name = myArray[1], maxPower = p2MaxPwr, health = 100, attackStrength = p2AtkStr, defensePower = p2DefPwr};
                    break;

                    case "3":
                    playerTwo = new WillTurner() {name = myArray[1], maxPower = p2MaxPwr, health = 100, attackStrength = p2AtkStr, defensePower = p2DefPwr};
                    break;
                }

                Gameplay(playerOne, playerTwo, myArray);

                myArray = MainMenu();
            }
            
        }
        public static string[] MainMenu()
        {
            Console.WriteLine($"Welcome to the Battle of Calypso's Maelstrom");
            Console.WriteLine($" (1) Enter the game");
            Console.WriteLine($" (2) Exit the game");

            string userInput = Console.ReadLine(); // reads user's choice for the main menu

            string[] myArray = new string[5];
            myArray = MainChoiceRoute(userInput); // fills the array from the route menu

            return myArray;
        }
        public static string[] MainChoiceRoute(string mainChoice)
        {
            bool check = false;
            string[] myArray = new string[5];

            string p1Name = "";
            string p2Name = "";

            while (check == false)
            {
                switch(mainChoice)
                {
                    case "1": 
                    p1Name = P1NameInput();
                    p2Name = P2NameInput();

                    string p1Char = CharacterSelect(p1Name);
                    string p2Char = CharacterSelect(p2Name);

                    myArray[0] = p1Name;
                    myArray[1] = p2Name;

                    myArray[2] = p1Char;
                    myArray[3] = p2Char;

                    myArray[4] = "play"; // sets the check statement to true to enter gameplay

                    check = true; // ends the loop to enter the game
                    break;

                    case "2":
                    Console.WriteLine("Thanks for playing!");
                    myArray[4] = "quit";
                    check = true;
                    break;

                    default:
                    Console.WriteLine($"ERROR: Invalid input, please try again.");
                    mainChoice = Console.ReadLine();
                    break;
                }
            }
            return myArray;
        }
        public static string P1NameInput()
        {
            Console.WriteLine($"User one enter your name:");
            return Console.ReadLine();
        }
        public static string P2NameInput()
        {
            Console.WriteLine($"User two enter your name:");
            return Console.ReadLine();
        }
        public static string CharacterSelect(string name)
        {
            bool check = false;
            string userChose = "";
            while(check == false)
            {
                Console.WriteLine(name + " select your character:");
                Console.WriteLine($" (1) Jack Sparrow \n (2) Davy Jones \n (3) Will Turner");
                userChose = Console.ReadLine();
                switch(userChose)
                {
                    case "1": return "1";
                    case "2": return "2";
                    case "3": return "3";
                    default:
                    ErrorMessage();
                    break;
                }
            }
            return userChose; 
        }
        public static void Gameplay(Character p1, Character p2, string[] myArray)
        {
            int firstTurn = PlayersTurn.Turn();
            Console.Clear();

            ReturnStats(p1);
            ReturnStats(p2);

            if(firstTurn == 0)
            {
                if(myArray[2] == "1") p2.health -= SparrowMenu(p1, p2, myArray, 1);
                else if(myArray[2] == "2") p2.health -= JonesMenu(p1, p2, myArray, 1);
                else if(myArray[2] == "3") p2.health -= TurnerMenu(p1, p2, myArray, 1);
                ReturnStats(p2);
                while(p1.health > 0 && p2.health > 0)
                {
                    if(myArray[3] == "1") p1.health -= SparrowMenu(p2, p1, myArray, 2);
                    else if(myArray[3] == "2") p1.health -= JonesMenu(p2, p1, myArray, 2);
                    else if(myArray[3] == "3") p1.health -= TurnerMenu(p2, p1, myArray, 2);
                    ReturnStats(p1);
                    if(p1.health > 0)
                    {
                        if(myArray[2] == "1") p2.health -= SparrowMenu(p1, p2, myArray, 1);
                        else if(myArray[2] == "2") p2.health -= JonesMenu(p1, p2, myArray, 1);
                        else if(myArray[2] == "3") p2.health -= TurnerMenu(p1, p2, myArray, 1);
                        ReturnStats(p2);
                    }
                    else Console.WriteLine(p2.name + " won this time!");
                }
                if(p2.health <= 0) Console.WriteLine(p1.name + " won this time!");
            }
            else
            {
                if(myArray[3] == "1") p1.health -= SparrowMenu(p2, p1, myArray, 2);
                else if(myArray[3] == "2") p1.health -= JonesMenu(p2, p1, myArray, 2);
                else if(myArray[3] == "3") p1.health -= TurnerMenu(p2, p1, myArray, 2);
                ReturnStats(p1);
                while(p1.health > 0 && p2.health > 0)
                {
                    if(myArray[2] == "1") p2.health -= SparrowMenu(p1, p2, myArray, 1);
                    else if(myArray[2] == "2") p2.health -= JonesMenu(p1, p2, myArray, 1);
                    else if(myArray[2] == "3") p2.health -= TurnerMenu(p1, p2, myArray, 1);
                    ReturnStats(p2);
                    if(p1.health > 0)
                    {
                        if(myArray[3] == "1") p1.health -= SparrowMenu(p2, p1, myArray, 2);
                        else if(myArray[3] == "2") p1.health -= JonesMenu(p2, p1, myArray, 2);
                        else if(myArray[3] == "3") p1.health -= TurnerMenu(p2, p1, myArray, 2);
                        ReturnStats(p1);
                    }
                    else Console.WriteLine(p1.name + " won this time!");
                }
                if(p1.health <= 0) Console.WriteLine(p2.name + " won this time!");
            }
        }
        public static double SparrowMenu(Character attacker, Character defender, string[] myArray, int playersTurn)
        {
            bool check = false;
            while(check == false)
            {
                Console.WriteLine(attacker.name + " enter your move:");
                Console.WriteLine($" (1) Distract (Primary Attack) \n (2) Pistol (1 in 10 chance of ending the game)");
                string userChose = Console.ReadLine();

                double bonus = GetEffectiveness(myArray, playersTurn);

                switch(userChose)
                {
                    case "1":
                    int attackDamage = attacker.attackBehavior.Attack(attacker);
                    double damage = ((attackDamage - defender.defensePower) * bonus);
                    if(damage <= 0) damage = 1; // damage cannot be negative will do 1 damage if defender's defense is too high
                    if(damage > 100 || damage > defender.health) damage = defender.health; // damage cannot exceed the defender's health
                    Console.WriteLine(attacker.name + " did " + damage + " damage to " + defender.name + "'s health!");
                    defender.health -= damage;
                    check = true;
                    return damage;
                    
                    case "2":
                    attackDamage = attacker.secondaryBehavior.Secondary(attacker);
                    damage = ((attackDamage - defender.defensePower) * bonus);
                    if(damage <= 0) damage = 0; // damage cannot be negative will do 1 damage if defender's defense is too high        
                    if(damage > 100 || damage > defender.health) damage = defender.health; // damage cannot exceed the defender's health           
                    Console.WriteLine(attacker.name + " did " + damage + " damage to " + defender.name + "'s health!");
                    check = true;
                    return damage;

                    default:
                    ErrorMessage();
                    break;
                }
            }
            return 0;
        }
        public static double JonesMenu(Character attacker, Character defender, string[] myArray, int playersTurn)
        {
            bool check = false;
            while(check == false)
            {
                Console.WriteLine(attacker.name + " enter your move:");
                Console.WriteLine($" (1) Cannon Fire (Primary Attack) \n (2) Buckshot (1 in 3 chance of 2x damage & 2 in 3 of missing)");
                string userChose = Console.ReadLine();

                double bonus = GetEffectiveness(myArray, playersTurn);

                switch(userChose)
                {
                    case "1":
                    int attackDamage = attacker.attackBehavior.Attack(attacker);
                    double damage = ((attackDamage - defender.defensePower) * bonus);
                    if(damage <= 0) damage = 1; // damage cannot be negative will do 1 damage if defender's defense is too high
                    if(damage > 100 || damage > defender.health) damage = defender.health; // damage cannot exceed the defender's health
                    Console.WriteLine(attacker.name + " did " + damage + " damage to " + defender.name + "'s health!");
                    defender.health -= damage;
                    check = true;
                    return damage;
                    
                    case "2":
                    attackDamage = attacker.secondaryBehavior.Secondary(attacker);
                    damage = ((attackDamage - defender.defensePower) * bonus);
                    if(damage <= 0) damage = 0; // damage cannot be negative will do 1 damage if defender's defense is too high        
                    if(damage > 100 || damage > defender.health) damage = defender.health; // damage cannot exceed the defender's health            
                    Console.WriteLine(attacker.name + " did " + damage + " damage to " + defender.name + "'s health!");
                    check = true;
                    return damage;

                    default:
                    ErrorMessage();
                    break;
                }
            }
            return 0;
        }
        public static double TurnerMenu(Character attacker, Character defender, string[] myArray, int playersTurn)
        {
            bool check = false;
            while(check == false)
            {
                Console.WriteLine(attacker.name + " enter your move:");
                Console.WriteLine($" (1) Swing Sword (Primary Attack) \n (2) Kick (1 in 5 chance of 3x damage & 4 in 5 of missing)");
                string userChose = Console.ReadLine();

                double bonus = GetEffectiveness(myArray, playersTurn);

                switch(userChose)
                {
                    case "1":
                    int attackDamage = attacker.attackBehavior.Attack(attacker);
                    double damage = ((attackDamage - defender.defensePower) * bonus);
                    if(damage <= 0) damage = 1; // damage cannot be negative will do 1 damage if defender's defense is too high
                    if(damage > 100 || damage > defender.health) damage = defender.health; // damage cannot exceed the defender's health
                    Console.WriteLine(attacker.name + " did " + damage + " damage to " + defender.name + "'s health!");
                    defender.health -= damage;
                    check = true;
                    return damage;
                    
                    case "2":
                    attackDamage = attacker.secondaryBehavior.Secondary(attacker);
                    damage = ((attackDamage - defender.defensePower) * bonus);
                    if(damage <= 0) damage = 0; // damage cannot be negative will do 1 damage if defender's defense is too high   
                    if(damage > 100 || damage > defender.health) damage = defender.health; // damage cannot exceed the defender's health                 
                    Console.WriteLine(attacker.name + " did " + damage + " damage to " + defender.name + "'s health!");
                    check = true;
                    return damage;

                    default:
                    ErrorMessage();
                    break;
                }
            }
            return 0;
        }
        public static double GetEffectiveness(string[] myArray, int playersTurn)
        {
            if(playersTurn == 1)
            {
                if(myArray[2] == "1" && myArray[3] == "3") // JS beats WT
                {
                    return 1.2;
                } 
                else if(myArray[2] == "3" && myArray[3] == "2") // TW beats DJ
                {
                    return 1.2;
                }
                else if(myArray[2] == "2" && myArray[3] == "1") // DJ beats JS
                {
                    return 1.2;
                }
                else return 1;
            }
            else
            {
                if(myArray[3] == "1" && myArray[2] == "3") // JS beats WT
                {
                    return 1.2;
                } 
                else if(myArray[3] == "3" && myArray[2] == "2") // TW beats DJ
                {
                    return 1.2;
                }
                else if(myArray[3] == "2" && myArray[2] == "1") // DJ beats JS
                {
                    return 1.2;
                }
                else return 1;
            }
            
        }
        public static void ReturnStats(Character myCharacter)
        {
            Console.WriteLine("{0,-10} {1, -13} {2, -8} {3, -18} {4, -15} \n", "Name", "Max Power", "Health", "Attack Strength", "Defense Power");
            Console.WriteLine("{0,-10} {1, -13} {2, -8} {3, -18} {4, -15} \n", myCharacter.name, myCharacter.maxPower, myCharacter.health, myCharacter.attackStrength, myCharacter.defensePower);
        }
        public static void ErrorMessage()
        {
            Console.WriteLine($"ERROR: Invalid input, please try again.");
        }
    }
}