/*
 *  Kablooey.h
 *  Kablooey
 *
 *  Created by Jason Month on 4/15/12.
 *  Copyright 2012 __MyCompanyName__. All rights reserved.
 *
 */

#include "STDHeader.h"

class Kablooey
{
public:
	Kablooey();
	~Kablooey();
	
	void Update();
	void Draw();
	
sf::Clock GameTime;	// Logically, these belong to the game object.
sf::RenderWindow App;
};

Kablooey::Kablooey()
{
	App.Create(sf::VideoMode(640, 480), "SFML Graphics");	// Creates the window for the game

	Globals::Viewport1.Left = 0.0;				// These blocks initialize the Global "Viewport" variables. They represent the 
	Globals::Viewport1.Top = 0.0;				// First Player's half of the screen, the Second Player's half, and the full size of
	Globals::Viewport1.Right = App.GetWidth() / 2;// the screen.
	Globals::Viewport1.Bottom = App.GetHeight();

	Globals::Viewport2.Left = App.GetWidth() / 2;
	Globals::Viewport2.Top = 0.0;
	Globals::Viewport2.Right = App.GetWidth();
	Globals::Viewport2.Bottom = App.GetHeight();

	Globals::ViewportFull.Left = 0.0;
	Globals::ViewportFull.Top = 0.0;
	Globals::ViewportFull.Right = App.GetWidth();
	Globals::ViewportFull.Bottom = App.GetHeight();


	//Initialize all art and audio assets
	//	All kept in Statics outside
}

Kablooey::~Kablooey()
{
	//Close window
}

void Kablooey::Update()
{
	//Transfer previous input state to old input state variable
	//Create input state. What buttons are currently pushed down
	//Make calls to all independant update methods of all objects
	//	(Player, enemy ships, UI, etc.)
	//	Passing new and old input state to all independant methods
	
}

void Kablooey::Draw()
{
	//Make calls to all independant update methods of all objects
	//	(Player, enemy ships, UI, etc.)
}





//I hate typing at the end of a file