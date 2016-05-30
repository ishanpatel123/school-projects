#pragma once
#ifndef PATROL_BEHAVIOR
#define PATROL_BEHAVIOR
#include "IBehavior.h"

class Patrol :
	public IBehavior
{
public:
	enum State { MOVING_FORWARD, ROTATE_180, MOVING_BACKWARD };

protected:
	State state;
	float maxDistance;
	float distanceMoved;
	float rotate180;
public:
	Patrol(float maxDistance = 10.0f);
	virtual ~Patrol();

	void update(GameObject *object, float elapsedSeconds);
};

#endif


