# CSC252-Data-Structures
### Solutions for Data Structure Problems in my Data Structures. Problems and Solutions are Outlined below.

## Minimum Spanning Tree/Network Architect
* **Requirements:** Given a graph in an adjacency list format from a text file, find the shortest path to all other vertices without looping.
* **Solution:** Prims Algorithm. 
* **Code Breakdown:** 
  1. Input the location to the text file and store the graph
  2. (start with first vertex) Select a vertex in the our list that hasn't been used yet mark it as used and find an unused edge with the lowest weight and move to the next unused vertex and map it. 
  3. Repeat step 2 recursivly until there are no more graphs that can be connected
  4. Output shortest path to connect all vertices, and the total length needed to connect them all.

## Maze Solver (Graph)
* **Requirements:** Given a graph in an adjacency list format, with a start and end vertex from a text file, find the shortest path between the vertices if possible
*  **Solution:** Dijkstra's algorithm
*  **Code Breakdown:**
 1. Read text File from user and map all graphs
 2. Using Dijkstra's we start at our end vertex and recursivly brute force the shortest path to the start if possible
 3. Ouput shortest path if it was possible to get to the start

## AVL Tree (Auto Balancing Binary Search Tree)
* **Requirements:**
*  **Solution:**
*  **Code Breakdown:**

## Binary Search Tree 
* **Requirements:**
*  **Solution:**
*  **Code Breakdown:**

## Linked List
* **Requirements:**
*  **Solution:**
*  **Code Breakdown:**
