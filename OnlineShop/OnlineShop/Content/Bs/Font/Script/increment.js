// Set counter default to zero
var counter = 0

// Display total
$("#counter").text(counter);

// When button is clicked
$("#add").click(function () {
    //Add 10 to counter
    counter = counter + 1;
    // Display total
    $("#counter").text(counter);
});


//Subtract
$("#subtract").click(function () {
    counter = counter - 1;
    $("#counter").text(counter);
});


// Reset
$("#reset").click(function () {
    counter = 0;
    $("#counter").text(counter);
});

/*
JAVASCRIPT NOTES & THINGS I LEARNED
- How to display a variable's value on the screen
- How to increment / decrement
- How to reset the counter to zero manually
- How to reset the counter automatically if it's greater than 100
- Spent some time exploring the getDate methods to create a clock.
- jQuery / JS Synstax
	- It's not ".cliked" it's ".click"
  - .text displays the variable's value; .html seems to add content into the div (?); .append just adds the counter to the end of the string instead of replacing it.
  - You only need to define the variable once; var counter = 0, var counter = counter + 10; doesn't work. 
  - I'm not sure how the code structure changes if I use a global vs. local varaible. ie. how does the function syntax change? 
  - This solves everything: http://www.webdesignerwall.com/wp-content/uploads/2008/02/jquery-how-it-works.gif
 

NEXT TIME!
- How would you refactor the actions into one function? ie. if this button is pressed, add 10, else that button subtracts 10? 

*/