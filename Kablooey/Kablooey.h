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
	
private:
};

Kablooey::Kablooey()
{
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