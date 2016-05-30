#pragma once
#ifndef FOUR_POINT_PATROL
#define FOUR_POINT_PATROL
#include "IBehavior.h"
class FourPointPatrol :
	public IBehavior
{
public:
	enum State { MOVING_FORWARD, ROTATE, ROTATEb_90, ROTATEL_90, ROTATER_90, MOVING_BACKWARD, MOVING_LEFT, MOVING_RIGHT };

protected:
	State state;
	float maxDistance;
	float distanceMoved;
	float rotate180;
	int changeState = 0;
public:
	FourPointPatrol(float maxDistance = 10.0f);
	virtual ~FourPointPatrol();

	void update(GameObject *object, float elapsedSeconds);
};

#endif

