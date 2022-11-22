# Who Wants to Be a Millionaire!



**The task is from the TV already well-known Who Wants to Be a Millionaire game writing for the console.**

## Rules:

In the game, the goal is to answer 15 successive, increasingly difficult multiple-choice questions. For each question, the correct one has to be chosen from the 4 possible answers. The game ends when the player gives a wrong answer or stops. The player can use 3 aids in the game, each of them no more than 1 time during the entire game. The halving aid takes away 2 of the 4 possible answers. With the help of the audience, a graph is displayed that shows the proportion of the audience who guessed each answer option. (The graph is sufficient if, for example, it is displayed in the form of A 39% B 11% C 0% D 50%.) The more difficult the question, the less likely the audience knows the answer, for the first question everyone knows the answer, while for the second question 14/15 are sure of the solution and 1/15 of the people only have a guess... for the last question only 1/15 know the solution for people is randomly guessed by the others. (Of course, it is permitted to round it up.) Telephone aid in today's world is already quite easy using Google, here it always gives us the correct answer 100% of the time. By answering each question, we win more and more money, which we get if we stop, if we don't stop but answer a question incorrectly, we only get the amount of the previous "sure point" (after questions 5 and 10 there is a "sure point ").


## Prize and Ranking:

The prizes are stored with the corresponding name and date in descending order according to the prize. There should be a menu system with which you can start a new game, view the ranking so far, and exit the program.



## Database:
The questions for the game are sent to the program in an Excel file, the only thing known is that it does not contain ; sign (it is possible to convert Excel to a txt file in which the separator characters are semicolons).

Columns of the Excel:
1. Difficulty – This is an integer from 1-15
2. Question – Series of characters
3. Answer A - Series of characters
4. Answer B - Series of characters
5. Answer C - Series of characters
6. Answer D - Series of characters
7. Correct answer – A character that is a, b, c or d

Unfortunately, Excel does not always arrive flawlessly, filtering out faulty rows is also the task.

If there is no question for the difficulty level, it has to be checked that it has -1. level unused question, if not then it has to be checked that it has +1.  level... and so on. If there is not one, then it has to be checked with the already used questions. (With the "The game must go on" principle, the game can also be played with 1 question)
