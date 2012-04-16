/*
 *  Ship.h
 *  Kablooey
 *
 *  Created by Jason Month on 4/15/12.
 *  Copyright 2012 __MyCompanyName__. All rights reserved.
 *
 */

#include "STDHeader.h"

class Ship : public Sprite
{
public:
	Ship();
	~Ship();
	
	void virtual Death();	//creepy voice
	void InitShip();	//Will take parameters
	void virtual Shoot();
	
protected:
	int Health;
	int Damage;
	float Speed;
};