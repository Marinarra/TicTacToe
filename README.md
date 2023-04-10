## Objective
A Console Application depicting a Tic-Tac-Toe Game , programmed using C#

## Requirements
* Create a User Interface presenting these key pieces of information
    * User Symbol (X or O)
    * System Symbol (X or O)
    * Game Board (Filled and Open Cells)
* Create a Game Menu that achieve these key pieces of information:
    * User coordinate Input
    * Exit
* Game Cycles
    * Startup
        * User selects to go first or not
        * User selects their symbol (X or O)
    * Run-Cycle
        * Each round the user selects a coordinate
        * Each round the system "selects" a coordinate
            > based on RNG placement
        * Win Condition
            * User or System has 3 contiguous symbols on a Row, Column or Diagonal
        * Draw Condition
            * No single Row, Column or Diagonal has three of the same Symbols
        * User can select to prematurely Exit the game
    * Shutdown
        * Return statistics of the Game Results
            > Capture the number of games Won, Draw, or Lost with a symbol.
        * Return Run-Time statistics
            > How much time played in Total
            > How much time played (on average) in each Game
            
---
