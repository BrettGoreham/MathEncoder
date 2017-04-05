# MathWithContextCalculator

This project is a command line project that calculates math equations.

currently the input is of the form
<variable> = [(] [<diffVariable>integer] [+-/*^] [<diffVariable integer] [)]

example
a = 1 + 2
b = a * a
c = ( a + b ) * ( a - b )

It will accept any length equation as long as it is of proper format.

Currently checking for proper input is not being done. Will Crash Out.

After each input it tries to calculate expressions.
If the expression is fully valid it will calculate as soon as enter is pressed
ie. a = 1 + 2 will output ===> a = 3
This will store in the context that a is 3 and this can be used later.

If an equation holds a variable that hasnt been evaluated on the right side. There will be no output.

When this variable gets initialized the equation will evaluate and enter context for future equations.
