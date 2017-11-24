# Dining Philosophers Example

This example is a rectangular table with 9 seats and 9 philosophers.

![The table described in the sample](./Table.png?raw=true "The Seating Plan")

<br/>

|File|Purpose|
|----|-------|
|`Table.png`|Contains an image of a seating plan for the table with the seats numbered.|
|`guests.csv`|Contains the guest list. <br/> Each guest is associated with an ID.|
|`weights.csv`|Contains the influence of each seat at the table. <br/> Seats that are directly adjacent or opposite are given a score of 2. <br/> Seats that are adjacent to the opposite are given a score of 1.|
|`relationships.csv`|Contains the preferences of the philosophers for each other. <br/> Fred likes anyone he sits next to. </br> Tom & Bjarne get along famously. <br/> Sam & Guy can't stand each other.|

<br/>

The table in this example is rectangular and has a single 'head' seat. This makes it asymmetric but easy to reason about. Corner seats clearly have less seats that they can influence so putting someone outgoing and popular in such a seat would be a tragedy.

The philosophers have simple relationships that should enable the reader to infer the affect of the values in the relationship matrix. 

The specific values in each matrix are irrelevant, what is important is the relative scale of those values in comparison to each other. This is why small integer values are used.

To use this example, simply load each of the files in the seating plan optimiser and click optimise. Regrettably, the philosophers are not spiteful enough to have challenging preferences to seat. As such the solver is highly likely to happen upon the correct solution with very few tries.

<br/>

> The story, all names, and incidents portrayed in this sample are fictitious. No identification with actual persons (living or deceased), places, buildings, and products is intended or should be inferred.
