# Dining Philosophers Example

This example is a rectangular table with 9 seats and 9 philosophers.

![The table described in the sample](./Table.png?raw=true "The Seating Plan")

<br/>

|File|Purpose|
|----|-------|
|`Table.png`|An illustration of an ideal seating plan for the table with the seats numbered.|
|`guests.csv`|The guest list.|
|`weights.csv`|The influence of each seat to each other seat at the table. <br/> Seats that are directly adjacent or opposite are given a score of 2. <br/> Seats that are adjacent to the opposite are given a score of 1.|
|`relationships.csv`|The preferences of the philosophers for each other. <br/> Fred likes anyone he sits next to. </br> Tom & Bjarne get along famously. <br/> Sam & Guy can't stand each other.|

<br/>

The table in this example is rectangular with a single 'head' seat. This makes it asymmetric but easy to reason about. E.G: Corner seats clearly have fewer seats to influence, as such putting someone outgoing and popular in a corner seat would be a tragedy.

The philosophers have simple relationships that should enable the reader to infer the affect of the values in the relationship matrix. The preferences can be asymmetric to accurately capture the preferences of the individual, however, the application will impose symmetry.

The specific values in each matrix are irrelevant, what is important is the relative scale of those values in comparison to each other. This is why small integer values are used.

To use this example, simply load each of the files in the seating plan optimiser and click optimise. Regrettably, the philosophers are not spiteful enough to have challenging preferences to seat. As such the solver is highly likely to happen upon an ideal solution with very few tries.

<br/>

> The story, all names, and incidents portrayed in this sample are fictitious. No identification with actual persons (living or deceased), places, buildings, and products is intended or should be inferred.
