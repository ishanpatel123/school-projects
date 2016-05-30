#pragma once
#ifndef FIRST_PERSON_PLAYER
#define FIRST_PERSON_PLAYER

#include "Player.h"

class FirstPersonPlayer : public Player
{
public:
	FirstPersonPlayer(const string& name);

	virtual ~FirstPersonPlayer();

	void resolveCollisions();
};

#endif

