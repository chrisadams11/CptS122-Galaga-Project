/*
 *  Ship.h
 *  Kablooey
 *
 *  Created by Jason Month on 4/15/12.
 *  Copyright 2012 __MyCompanyName__. All rights reserved.
 *
 */
#pragma once

#include "STDHeader.h"
#include "Globals.h"
#include "Sprite.h"
class Ship : public Sprite
{
public:
	Ship(): Sprite() {}
	~Ship()
	{
	}
	
	//void virtual Death();	//creepy voice
	void InitShip();	//Will take parameters
	void SetDirection(float x, float y);
	//void virtual Shoot();
	
protected:
	int Health;
	int Damage;
	float Speed;
	sf::Vector2f Direction;
};

void Ship::SetDirection(float x, float y)
{
	this->Direction.x = x;
	this->Direction.y = y;
}

