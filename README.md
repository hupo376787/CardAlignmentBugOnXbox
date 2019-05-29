# CardAlignmentBugOnXbox

StackOverflow issue on [Move focus on GridView item one by one](https://stackoverflow.com/questions/56321601/move-focus-on-gridview-item-one-by-one/56352249#56352249)

Through a series disscussion with MS tech, we confirmed that:

Xbox Settings> Display&Sound> Video output, under "Advanced" select "Video fidelity & overscan" You will see an option that says "Apps can add a border", turn if off.

This can solve the card alignment problem, but currently there is no api for developers to turn it off using code.
