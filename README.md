# C# Hangman Game

This is a console-based implementation of the classic Hangman word-guessing game, built in C#. It provides a simple yet complete example of game logic, user interaction, and basic object-oriented programming.

## Features

* **Random Word Selection:** Chooses a secret word from a predefined list.
* **Guessing Mechanics:** Players guess letters to reveal the hidden word.
* **Incorrect Guess Tracking:** Tracks incorrect guesses and updates the Hangman gallows display.
* **Win/Loss Conditions:** Determines game outcome based on correct guesses or too many incorrect attempts.
* **Play Again Option:** Allows players to restart the game easily.

## How to Play

1.  The game will choose a random secret word.
2.  You will see a series of dashes representing the letters in the word.
3.  Guess one letter at a time.
4.  If your guess is correct, the letter will appear in the word.
5.  If your guess is incorrect, a part of the Hangman figure will be drawn.
6.  You win if you guess all the letters before the Hangman figure is complete.
7.  You lose if the Hangman figure is fully drawn before you guess the word.

## Code Structure

The game's logic is primarily encapsulated within the `Hangman` class, which manages the game state, word selection, input processing, and display.

## Future Enhancements (Ideas)

* Add more words to the list, perhaps from an external file.
* Implement difficulty levels (e.g., longer words, fewer guesses).
* Add categories for words.
* Improve input validation (e.g., ensure only single letters are entered).
* Enhance the visual display of the gallows or game state.

## Contributing

Feel free to suggest improvements or enhancements by opening issues or submitting pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
