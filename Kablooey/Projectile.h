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
	
	void Update();
	
protected:
	float speed;
	int damage;
}