/*
 *  PlayerShip.h
 *  Kablooey
 *
 *  Created by Jason Month on 4/15/12.
 *  Copyright 2012 __MyCompanyName__. All rights reserved.
 *
 */
#pragma once

#include "STDHeader.h"
#include "Globals.h"
#include "Ship.h"

class PlayerShip : public Ship
{
public:
	PlayerShip(): Ship() {}
	~PlayerShip()
	{
	}
	
	void Update(float ElapsedSeconds, const sf::Input & Input);
	void InitPlayer(sf::Vector2f startPosition);
	void InitPlayer(float x, float y);
	
protected:
};

void PlayerShip::InitPlayer(sf::Vector2f startPosition)
{
	this->Health = Globals::playerStats::playerHealth;
	this->Damage = Globals::playerStats::playerDamage;
	this->Speed = Globals::playerStats::playerSpeed;
	this->SetPosition(startPosition);
	this->SetDirection(0, 0);
	this->IsAlive = true;
}

void PlayerShip::InitPlayer(float x, float y)
{
	this->Health = Globals::playerStats::playerHealth;
	this->Damage = Globals::playerStats::playerDamage;
	this->Speed = Globals::playerStats::playerSpeed;
	this->SetPosition(x, y);
	this->SetDirection(0, 0);
	this->IsAlive = true;
}

void PlayerShip::Update(float ElapsedSeconds, const sf::Input & Input)
{
	this->Move(this->Direction * this->Speed * ElapsedSeconds );

	if ( Input.IsKeyDown(sf::Key::Up) )
	{
		this->Direction.y = -1;
	}

	else if ( Input.IsKeyDown(sf::Key::Down) )
	{
		this->Direction.y = 1;
	}

	else
	{
		this->Direction.y = 0;
	}

	if ( Input.IsKeyDown(sf::Key::Left) )
	{
		this->Direction.x = -1;
	}

	else if( Input.IsKeyDown(sf::Key::Right) )
	{
		this->Direction.x = 1;
	}

	else
	{
		this->Direction.x = 0;
	}
}