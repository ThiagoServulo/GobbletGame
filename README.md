# Gobblet Game

## Description and Rules
The Gobblet Game is an abstract experience that blends strategy and memory. Each player possesses three sets of pieces, each comprised of four cylinders of staggered sizes that nest within one another, reminiscent of the iconic Matryoshka dolls.

The objective is to place four of your pieces in a horizontal, vertical, or diagonal line on the board. The game starts with all pieces off the board, and on each turn, players can either place a new piece on the board or move an existing one to another position.

**Important:** A larger piece can always cover a smaller one, regardless of whether it belongs to you or your opponent. Thus, in addition to strategy, the game also challenges your memory, as it is crucial to remember which of your pieces are covering others before moving them to avoid inadvertently granting advantages to your opponent.

![Initial board][board_1]

![Game board][board_2]

## Game Details
Before commencing, the user must specify the number of rounds the game will have. This number must be odd and greater than zero. The overall winner will be the player who wins the most rounds.

In round 1, the first player chooses the red pieces. In subsequent rounds, the first player will be the one who lost in the previous round.

## Technical Details
The Gobblet Game was developed in C# with the assistance of Windows Forms to create the visual interfaces. The source code encompasses a range of crucial technical concepts, such as interfaces, class inheritance, polymorphism, method overriding, exception handling, delegates, structs, among others.

To document the code clearly and explanatorily, Doxygen was employed. This tool can generate customized software documentation, making the code more self-explanatory and facilitating understanding of its operation and structure.

## Versions

### V1.0.0

* Date: 2022-08/08. 
* This is the first stable version of the game, incorporating all the functionalities described in the documentation.

### V1.0.1

* Date: 2024-03-21. 
* This version introduces minor changes to the application, addresses small bugs, and translates both the code and documentation into English.

## Author

[@thiagoservulo](https://github.com/ThiagoServulo)

[board_1]: images/board_1.png
[board_2]: images/board_2.png