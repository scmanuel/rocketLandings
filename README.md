# Exercise:

You need to design a library that will help determine if rockets can land on a platform. Whenever rocket is getting back from the orbit, it needs to check every now and then if it's on a correct trajectory to safely land on a platform. Whole landing area (area that contains landing platform and surroundings) consists of multiple squares that set a perimeter/dimensions that can be described with coordinates (say x and y). Assuming that landing area has size of square 100x100 and landing platform has a size of a square 10x10 and it's top left corner starts at a position 5,5 (please assume that position 1,1 is located at the top left corner of landing area and all positions are relative to it), library should work as follows:
- if rocket asks for position 5,5 it replies `ok for landing`
- if rocket asks for position 16,15, it replies `out of platform`
- if the rocket asks for a position that has previously been checked by another rocket (only last check counts), it replies with `clash`
- if the rocket asks for a position that is located next to a position that has previously been checked by another rocket (say, previous rocket asked for position 7,7 and the rocket asks for 7,8 or 6,7 or 6,6), it replies with `clash`.Given the above.

Please create a library (just library, it doesn't need to be used on any cli/gui) that will support following features:
- rocket can query it to see if it's on a good trajectory to land at any moment
- library can return one of the following values: 'out of platform', 'clash', 'ok for landing'
- more than one rocket can land on the same platform at the same time and rockets need to have at least one unit separation between their landing positions
- platform size can vary and should be configurable

Please, write automated tests for the library
Note: This exercise is prepared to be done in around 1 hour, however you can use as much time as you need.

# Solution proposed:

The different responsibilities have been related to the purpose of the real object:

- *LandingArea*: it has a dimension and it includes a landing platform. As the last layer of the process before to return the result to the rocket, it has the result mapper as dependency as well.
- *LandingPlatform*: it has a dimension and it applies the strategy to the checking of the landing positions. The strategy is a dependency of this class because it is in it where the landing is made.
- *Rocket*: it performs the request about its planned landing position and it receives the result mapped to the right text.
- *Position*: planned landing position of the rocket.
- *Dimension*: size of the landing area/platform. It includes methods used to know if the landing platform is inside of the landing area and if a position is inside of a dimension.
- *ApproachCheckResultMapper*: it performs the mapping between the enum with the different values (out, clash, ok) and the final text receives by the rocket.
- *ZartisExerciseStrategy*: it applies a strategy to evaluate the landing position. This makes easy to apply a different strategy for the landings. 



*Manuel Santos Cortés (sc.manuel@gmail.com) - 2020-10-26*
