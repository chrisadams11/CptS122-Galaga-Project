/*
 *  Globals.h
 *  Kablooey
 *
 *  Created by Chris Adams on 4/17/12.
 *
 */
// Contains global variables that can be used throughout the program.

// To create a global variable, declare it here as "static", then define it in Globals.cpp
#include <SFML/Graphics.hpp>
#include <SFML/System.hpp>
#include <SFML/Window.hpp>

class Globals
{
public:
	static sf::Rect<float> Viewport1;
	static sf::Rect<float> Viewport2;
	static sf::Rect<float> ViewportFull;
};