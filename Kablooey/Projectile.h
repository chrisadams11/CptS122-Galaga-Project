/*
 *  Projectile.h
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

class Projectile : public Sprite
{
public:
	Projectile();
	~Projectile();
	
	void Update(float ElapsedSeconds);// Elapsed Seconds represents the time between each update.
	
protected:
	float Speed;
	sf::Vector2f Direction;
	int Damage;
};

void Projectile::Update(float ElapsedSeconds)
{
	this->Move(this->Direction * this->Speed * ElapsedSeconds );	// Move the object in its set direction by its set speed
																	// The modifier "ElapsedSeconds" regulates the speed of movement
	if ( (this->GetPosition().x >= Globals::ViewportFull.Right) ||		// Across machines with varying clock speeds.
		 (this->GetPosition().x <= Globals::ViewportFull.Left) ||
		 (this->GetPosition().x == Globals::Viewport1.Right) )	// If the object is offscreen, stop it and make it invisible.
	{
		this->IsAlive = false;
		this->Speed = 0;

	}

	else if (	(this->GetPosition().y <= Globals::ViewportFull.Top) ||
				(this->GetPosition().y >= Globals::ViewportFull.Bottom) )
	{
		this->IsAlive = false;
		this->Speed = 0;

	}
}