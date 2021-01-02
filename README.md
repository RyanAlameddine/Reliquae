<!--
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
-->


# Reliquae

A topdown game built in C# .NET Core with Monogame. Build structures, fight monsters, establish farms, fish, and explore in this story-driven game!

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#implementation">Implementation</a>
      <ul>
        <li><a href="#events">Events</a></li>
        <li><a href="#world">World</a></li>
        <li><a href="#tilemap">Tile Maps</a></li>
        <ul>
          <li><a href="#blockdata">Block Data</a></li>
        </ul>
      </ul>
    </li>
    <li><a href="#gameplay">Gameplay</a></li>
    <li><a href="#installation">Installation</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>


## Implemenatation

### Events

The entire game is run on an event system. Different interactions and events will cause functions to be called in classes with one of the following event interfaces:
 - `IUpdatable`
 - `IPaintable`
 - `IInteractable`

### World

The core of the game data is stored in the `World` class. It contains a `Tape` (custom data structure) of a tuple containing a `TileMap` and an `EntityMap`.
Each node in the `Tape` represents one layer of the world. For example, the starting tilemap is the base ground level and the starting entity map describes all 
static and non-static entities on the ground level. The layer below on the tape might represent the mining area directly underneath ground level.

### Tile-Maps

Time-maps contain a 2D-array of `Tiles`. This map can be saved and loaded from memory. 
When loaded, the blockdata will be used to automatically select the textures based on adjacency patterns.
For example, if there is dirt adjacent to a grass tile, the grass tile will select a texture which shows the intersection of the two tiles.

### Blockdata

In the Content folder there is a set of blockdata json files which contain the information and tilemap patterns for each tile type (dirt, grass, etc.)
The extension of these files determines the file schema. All schemas represent an `BlockModel<T>` where `T` is an `IAdjacencyModel` (which is then converted to the matching `IAdjacencyPattern`).
The available format options are:

 - `DirectAdjacencyModel/Pattern` (*name_d.json*) - Simplest patterns which matches on only the directly adjacent tiles ( W N E S )
 - `SingleAdjacencyModel/Pattern` (*name_s.json*) - Simple patterns which match on all adjacent tiles ( W NW N NE E SE S SW )

## Gameplay

TODO: Insert screenshots here.

## Installation

This project is currently in development. There is no published version, but feel free to download the project and build it yourself!

## Roadmap

See the [open issues](https://github.com/RyanAlameddine/Reliquae/issues) for a list of proposed features (and known issues).

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Acknowledgements
* [Sofia Echvarria](https://github.com/21EchavarriaS) - Game Design and Art
* [Ryan Alameddine](https://github.com/RyanAlameddine) - Game Design and Programming
