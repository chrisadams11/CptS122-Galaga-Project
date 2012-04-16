/*
 *  Sprite.h
 *  Kablooey
 *
 *  Created by Jason Month on 4/15/12.
 *  Copyright 2012 __MyCompanyName__. All rights reserved.
 *
 */

#include "STDHeader.h"

class Sprite : public sf::Sprite
{
public:
	Sprite();
	~Sprite();
	
protected:
	bool IsAlive;		//Does it get shown or not?
};