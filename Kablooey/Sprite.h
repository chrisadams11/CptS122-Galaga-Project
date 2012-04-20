/*
 *  Sprite.h
 *  Kablooey
 *
 *  Created by Jason Month on 4/15/12.
 *  Copyright 2012 __MyCompanyName__. All rights reserved.
 *
 */
#pragma once

#include "STDHeader.h"
#include "Globals.h"

class Sprite : public sf::Sprite
{
public:
	Sprite(): sf::Sprite()// The initializer calls the standard Sprite initializer, then sets IsAlive to true.
	{
		this->IsAlive = true;
	}

	~Sprite()
	{
	}

	void DrawSprite(sf::RenderTarget& Screen);
	
protected:
	bool IsAlive;		//Does it get shown or not?
};

void Sprite::DrawSprite(sf::RenderTarget& Screen)	//Checks if the sprite is alive before drawing it.
{
	if (this->IsAlive)
		Screen.Draw(*this);
}