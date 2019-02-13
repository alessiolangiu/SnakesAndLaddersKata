1) How did you approach the problem?
In this case I used TDD methodology, refactoring the code when necessary.

2) How did you make key decisions?
I started developing an Aggregate Root (Board class) with a list of Value objects (Players). All the logic stays in the aggregate root, while the players where changing their properties when the aggregate root needed to chenge them. For the current specifications there is no need to access to the players objects from outside the board object.
After a while it was obvious that I didn't need a proper Player class because that class would be an anemic value object with just the placeHolder information (int): I changed it using just the placeholder information (int)
If I continued the exercise I might needed a more complex object for the player, but in this case it is enough (no overdesign)

3) How do you envision your solution evolving in the future?
After the final refactoring this solution is now very simple. Every time we need to add a new feature, all the parts will change accordingly to the new feature trying to avoid the overdesign.


 