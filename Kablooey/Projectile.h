/*
 *  Projectile.h
 *  Kablooey
 *
 *  Created by Jason Month on 4/15/12.
 *  Copyright 2012 __MyCompanyName__. All rights reserved.
 *
 */

#include "STDHeader.h"

class Projectile : public Sprite
{
public:
	Projectile();
	~Projectile();
	
	void Update(float ElapsedSeconds);// Elapsed Seconds represents the time between each update.
	
protected:
	float speed;
	sf::Vector2f direction;
	int damage;
};

void Projectile::Update(float ElapsedSeconds)
{
	this->Move(this->direction * this->speed * ElapsedSeconds );	// Move the object in its set direction by its set speed
																	// The modifier "ElapsedSeconds" regulates the speed of movement
	if ( (this->GetPosition().x >= Globals::ViewportFull.Right) ||		// Across machines with varying clock speeds.
		 (this->GetPosition().x <= Globals::ViewportFull.Left) ||
		 (this->GetPosition().x == Globals::Viewport1.Right) )	// If the object is offscreen, stop it and make it invisible.
	{
		this->IsAlive = false;
		this->speed = 0;

	}

	else if (	(this->GetPosition().y <= Globals::ViewportFull.Top) ||
				(this->GetPosition().y >= Globals::ViewportFull.Bottom) )
	{
		this->IsAlive = false;
		this->speed = 0;

	}
}