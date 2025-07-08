namespace CSharpHangmanGame
{
    
    
        public class Hangman
        {
            private Random _random = new Random();
            private string _ComputersChoice = "";
            private List<char> _displayWord = [];
            private char _playersChoice = '\0';
            private int _incorrectGuesses = 0;
            private int _matchingCharacters = 0;
            private List<char> _playerGuesses = [];


            private List<string> _hiddenWords = [
                        "PROGRAMMING",
                    "COMPUTER",
                    "DEVELOPER",
                    "KEYBOARD",
                    "MONITOR",
                    "ALGORITHM",
                    "VARIABLE",
                    "FUNCTION",
                    "CONSOLE",
                    "LANGUAGE",
                    "SOFTWARE",
                    "DEBUGGING",
                    "CHALLENGE",
                    "SUCCESS",
                    "LEARNING"
            ];


            private int GenerateRandomNumber()
            {
                return _random.Next(0, _hiddenWords.Count);
            }
            public Hangman()
            {



            }
            private void DisplayGuessingState()
            {
                foreach (char item in _displayWord)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
            private void gameInitializerInitializeGameRound()
            {
                _ComputersChoice = _hiddenWords[GenerateRandomNumber()];

                foreach (char word in _ComputersChoice)
                {
                    _displayWord.Add('-');
                }
            }
            private void RestartGame()
            {
                _incorrectGuesses = 0;
                _matchingCharacters = 0;
                _displayWord = [];
                _playerGuesses = [];
            }
            public void RunGame()
            {

                Console.WriteLine("====================================");
                Console.WriteLine("          WELCOME TO HANGMAN!       ");
                Console.WriteLine("====================================");
                bool playAgain = true;
                while (playAgain)
                {
                    RestartGame();
                    gameInitializerInitializeGameRound();
                    bool gameIsOver = false;
                    Console.WriteLine("Starting Hangman...");

                    Console.WriteLine("Choosing secret word...");
                    Console.WriteLine("...");
                    Console.WriteLine("Secret word chosen!");
                    Console.WriteLine("-");

                    while (true)
                    {
                        switch (_incorrectGuesses)
                        {
                            case 0:
                                PrintGallows0();
                                break;
                            case 1:
                                PrintGallows1();
                                break;
                            case 2:
                                PrintGallows2(); break;
                            case 3:
                                PrintGallows3(); break;
                            case 4:
                                PrintGallows4(); break;
                            case 5:
                                PrintGallows5();
                                gameIsOver = true;
                                break;

                        }

                        Console.Write($"Guesses:  ");
                        PrintGuesses();
                        Console.WriteLine();
                        Console.Write("Guess a Letter: ");
                        if (!GetTheInputs())
                        {
                            Console.WriteLine("Invalid Input! Please enter a Letter \n");
                            continue;
                        }
                        if ((_playerGuesses.Contains(_playersChoice)) && (_playersChoice != '-'))
                        {
                            Console.WriteLine($"You already guessed '{_playersChoice}'. Try a different letter.\\n\"");
                            continue;
                        }
                        _playerGuesses.Add(_playersChoice);

                        if (!ProcessGuess())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"There is no '{_playersChoice} in the word.");
                            _incorrectGuesses++;
                            Console.ResetColor();


                            if (gameIsOver)
                            {
                                PrintGallows6();
                                Console.WriteLine($"The HiddenWord was \"{_ComputersChoice}\"");
                                break;
                            }

                            continue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Correct!'{_playersChoice}'is in the word \n");

                            if (_matchingCharacters == _ComputersChoice.Length)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("====================================");
                                Console.WriteLine("              YOU WIN!              ");
                                Console.WriteLine("====================================");

                                DisplayGuessingState();

                                Console.ResetColor();
                                break;
                            }
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                    }


                    Console.WriteLine("Play again? (y/n):");
                    string? playAgainDecision = Console.ReadLine().ToLower().Trim();
                    if (playAgainDecision == "y")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("THANK YOU FOR PLAYING");
                        Console.WriteLine("Exiting...");
                        Console.WriteLine("...");
                        playAgain = false;
                    }
                }





            }
            private void PrintGuesses()
            {
                foreach (var item in _playerGuesses)
                {
                    Console.Write(" ");
                    Console.Write(item);

                }
            }
            private bool GetTheInputs()
            {
                string? input = Console.ReadLine().ToUpper().Trim();
                if (!char.TryParse(input, out _playersChoice))
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }
            private bool ProcessGuess()
            {
                int index = 0;
                int correctionChecker = 0;
                foreach (char letter in _ComputersChoice)
                {
                    if (letter == _playersChoice)
                    {
                        _displayWord[index] = letter;
                        _matchingCharacters++;
                        correctionChecker++;
                    }


                    index++;
                }
                if (correctionChecker > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            private void PrintGallows0()
            {
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========\n\n");

                DisplayGuessingState();
            }
            private void PrintGallows1()
            {
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========\n\n");
                DisplayGuessingState();
            }
            private void PrintGallows2()
            {
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========\n\n");
                DisplayGuessingState();
            }
            private void PrintGallows3()
            {
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine("  |\\  |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========\n\n");
                DisplayGuessingState();
            }
            private void PrintGallows4()
            {
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========\n\n");
                DisplayGuessingState();
            }
            private void PrintGallows5()
            {
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine("   \\  |");
                Console.WriteLine("   /  |");
                Console.WriteLine("=========\n\n");
                DisplayGuessingState();
            }
            private void PrintGallows6()
            {
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine(" / \\  |");
                Console.WriteLine(" \\ /  |");
                Console.WriteLine("=========\n\n");


                Console.ForegroundColor = ConsoleColor.DarkRed;
                DisplayGuessingState();
                Console.WriteLine("     .-=======-.");
                Console.WriteLine("   .`___        |  : !|          ======      ======    .======!   .=====._             ");
                Console.WriteLine("  (_____)       |  | ||        .`  _-_ '.   | ||       | ||```    | ..-,  }    ");
                Console.WriteLine(" (_____ )       |  | ||        | |`   : |   ` ||___,   | ||___    | !!_:  }              ");
                Console.WriteLine("(_____  )       |  | ||        | ||   ! |   `=====-|   |*=====!   |====='`.     ");
                Console.WriteLine("{_____   }>     }  | |!_____   | :. _ ' |   .____| |   | ||___    | ||  \\ \\       ");
                Console.WriteLine(" `-=====\\      ?   !+======/    '======'    !======`   '======!   | ||  | |                ");
                Console.WriteLine("         }    / ");
                Console.WriteLine("         |   | ");
                Console.WriteLine("         \\   \\ ");
                Console.WriteLine("          `- -` ");
                Console.ResetColor();
            }



        }

        internal class Program
        {

            static void Main(string[] args)
            {
                Hangman game = new Hangman();
                game.RunGame();


            }





        }
    }

