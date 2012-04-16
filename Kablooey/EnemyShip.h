/*
 *  EnemyShip.h
 *  Kablooey
 *
 *  Created by Jason Month on 4/15/12.
 *  Copyright 2012 __MyCompanyName__. All rights reserved.
 *
 */

#include "STDHeader.h"

class EnemyShip : public Ship
{
public:
	EnemyShip();
	~EnemyShip();
	
	void virtual Update();
	void virtual Death();
	
protected:
};